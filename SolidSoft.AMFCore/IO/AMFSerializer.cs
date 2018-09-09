using System;
using System.Collections;
using System.IO;
using SolidSoft.AMFCore.Messaging;
using SolidSoft.AMFCore.Messaging.Messages;

namespace SolidSoft.AMFCore.IO
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class AMFSerializer : AMFWriter
	{
		/// <summary>
		/// Initializes a new instance of the AMFSerializer class.
		/// </summary>
		/// <param name="stream"></param>
		public AMFSerializer(Stream stream) : base(stream)
		{
		}
        /// <summary>
        /// Initializes a new instance of the AMFSerializer class.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="stream"></param>
        internal AMFSerializer(AMFWriter writer, Stream stream)
            : base(writer, stream)
        {
        }

        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="amfMessage"></param>
        
        public void WriteMessage(AMFMessage amfMessage)
		{
			try
			{
				base.WriteShort(amfMessage.Version);
				int headerCount = amfMessage.HeaderCount;
				base.WriteShort(headerCount);
				for(int i = 0; i < headerCount; i++)
				{
					this.WriteHeader(amfMessage.GetHeaderAt(i), ObjectEncoding.AMF0);
				}
				int bodyCount = amfMessage.BodyCount;
				base.WriteShort(bodyCount);
				for(int i = 0; i < bodyCount; i++)
				{
					ResponseBody responseBody = amfMessage.GetBodyAt(i) as ResponseBody;
                    if (responseBody != null && !responseBody.IgnoreResults)
                    {
                        //Try to catch serialization errors
                        if (this.BaseStream.CanSeek)
                        {
                            long position = this.BaseStream.Position;

                            try
                            {
                                responseBody.WriteBody(amfMessage.ObjectEncoding, this);
                            }
                            catch (Exception exception)
                            {
                                this.BaseStream.Seek(position, SeekOrigin.Begin);

                                ErrorResponseBody errorResponseBody;
                                if (responseBody.RequestBody.IsEmptyTarget)
                                {
                                    object content = responseBody.RequestBody.Content;
                                    if (content is IList)
                                        content = (content as IList)[0];
                                    IMessage message = content as IMessage;
                                    MessageException messageException = new MessageException(exception);
                                    messageException.FaultCode = __Res.GetString(__Res.Amf_SerializationFail);
                                    errorResponseBody = new ErrorResponseBody(responseBody.RequestBody, message, messageException);
                                }
                                else
                                    errorResponseBody = new ErrorResponseBody(responseBody.RequestBody, exception);

                                try
                                {
                                    errorResponseBody.WriteBody(amfMessage.ObjectEncoding, this);
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                            }
                        }
                        else
                            responseBody.WriteBody(amfMessage.ObjectEncoding, this);
                    }
                    else
                    {
                        AMFBody amfBody = amfMessage.GetBodyAt(i);
                        SolidSoft.AMFCore.Util.ValidationUtils.ObjectNotNull(amfBody, "amfBody");
                        amfBody.WriteBody(amfMessage.ObjectEncoding, this);
                    }
				}
			}
			catch(Exception)
			{
				throw;
			}
        }

		private void WriteHeader(AMFHeader header, ObjectEncoding objectEncoding)
		{
			base.Reset();
			base.WriteUTF(header.Name);
			base.WriteBoolean(header.MustUnderstand);
			base.WriteInt32(-1);
			base.WriteData(objectEncoding, header.Content);
		}
 	}
}