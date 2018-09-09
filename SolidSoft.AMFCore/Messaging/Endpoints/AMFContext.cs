using System.IO;
using SolidSoft.AMFCore.IO;

namespace SolidSoft.AMFCore.Messaging.Endpoints
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class AMFContext
	{
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string AMFCoreContextKey = "__@amfcorecontext";

		AMFMessage		_amfMessage;
		MessageOutput	_messageOutput;
		Stream			_inputStream;
		Stream			_outputStream;

		/// <summary>
		/// Initializes a new instance of the AMFContext class.
		/// </summary>
		public AMFContext(Stream inputStream, Stream outputStream)
		{
			_inputStream = inputStream;
			_outputStream = outputStream;
		}


		public AMFMessage AMFMessage
		{
			get{ return _amfMessage; }
			set{ _amfMessage = value; }
		}

		public MessageOutput MessageOutput
		{
			get{ return _messageOutput; }
			set{ _messageOutput = value; }
		}

		public Stream InputStream
		{
			get{ return _inputStream; }
		}

		public Stream OutputStream
		{
			get{ return _outputStream; }
		}      
	}
}