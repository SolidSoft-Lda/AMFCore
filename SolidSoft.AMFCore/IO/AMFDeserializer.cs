using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace SolidSoft.AMFCore.IO
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class AMFDeserializer : AMFReader
	{
        List<AMFBody> _failedAMFBodies = new List<AMFBody>(1);

        /// <summary>
		/// Initializes a new instance of the AMFDeserializer class.
		/// </summary>
		/// <param name="stream"></param>
		public AMFDeserializer(Stream stream) : base(stream)
		{
            this.FaultTolerancy = true;
		}
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <returns></returns>
        
        public AMFMessage ReadAMFMessage()
		{
			// Version stored in the first two bytes.
			ushort version = base.ReadUInt16();
			AMFMessage message = new AMFMessage(version);
			// Read header count.
			int headerCount = base.ReadUInt16();
			for (int i = 0; i < headerCount; i++)
			{
				message.AddHeader(this.ReadHeader());
			}
			// Read header count.
			int bodyCount = base.ReadUInt16();
			for (int i = 0; i < bodyCount; i++)
			{
                AMFBody amfBody = this.ReadBody();
				if( amfBody != null )//not failed
					message.AddBody(amfBody);
			}
			return message;
		}

		private AMFHeader ReadHeader()
		{
            this.Reset();
			// Read name.
			string name = base.ReadString();
			// Read must understand flag.
			bool mustUnderstand = base.ReadBoolean();
			// Read the length of the header.
			int length = base.ReadInt32();
			// Read content.
			object content = base.ReadData();
			return new AMFHeader(name, mustUnderstand, content);
		}

		private AMFBody ReadBody()
		{
			this.Reset();
			string target = base.ReadString();

			// Response that the client understands.
			string response = base.ReadString();
			int length = base.ReadInt32();
			if( base.BaseStream.CanSeek )
			{
				long position = base.BaseStream.Position;
				// Read content.
				try
				{
					object content = base.ReadData();
                    AMFBody amfBody = new AMFBody(target, response, content);
                    Exception exception = this.LastError;
                    if (exception != null)
                    {
                        ErrorResponseBody errorResponseBody = GetErrorBody(amfBody, exception);
                        _failedAMFBodies.Add(errorResponseBody);
                        return null;
                    }
                    return amfBody;
				}
				catch(Exception exception)
				{
					base.BaseStream.Position = position + length;
                    //Try to build a valid response from partialy deserialized amf body
                    AMFBody amfBody = new AMFBody(target, response, null);
                    ErrorResponseBody errorResponseBody = GetErrorBody(amfBody, exception);
                    _failedAMFBodies.Add(errorResponseBody);
					return null;
				}
			}
			else
			{
				try
				{
					object content = base.ReadData();
                    AMFBody amfBody = new AMFBody(target, response, content);
                    Exception exception = this.LastError;
                    if (exception != null)
                    {
                        ErrorResponseBody errorResponseBody = GetErrorBody(amfBody, exception);
                        _failedAMFBodies.Add(errorResponseBody);
                        return null;
                    }
                    return amfBody;
                }
				catch(Exception exception)
				{
                    //Try to build a valid response from partialy deserialized amf body
                    AMFBody amfBody = new AMFBody(target, response, null);
                    ErrorResponseBody errorResponseBody = GetErrorBody(amfBody, exception);
                    _failedAMFBodies.Add(errorResponseBody);
					throw;
				}
			}
		}

        private ErrorResponseBody GetErrorBody(AMFBody amfBody, Exception exception)
        {
            ErrorResponseBody errorResponseBody = null;
            try
            {
                object content = amfBody.Content;
                if (content is IList)
                    content = (content as IList)[0];
                if (content is SolidSoft.AMFCore.Messaging.Messages.IMessage)
                    errorResponseBody = new ErrorResponseBody(amfBody, content as SolidSoft.AMFCore.Messaging.Messages.IMessage, exception);
                else
                    errorResponseBody = new ErrorResponseBody(amfBody, exception);
            }
            catch
            {
                errorResponseBody = new ErrorResponseBody(amfBody, exception);
            }
            return errorResponseBody;
        }

        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        
        public AMFBody[] FailedAMFBodies
		{ 
			get
			{
                return _failedAMFBodies.ToArray();
			}
		}
	}
}