using System.Xml.Linq;

namespace SolidSoft.AMFCore.IO.Writers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
    class AMF3XDocumentWriter : IAMFWriter
    {
        public AMF3XDocumentWriter()
        {
        }
        #region IAMFWriter Members

        public bool IsPrimitive { get { return false; } }

        public void WriteData(AMFWriter writer, object data)
        {
            writer.WriteAMF3XDocument(data as XDocument);
        }
        #endregion
    }
}