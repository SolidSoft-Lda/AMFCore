using System.Xml.Linq;

namespace SolidSoft.AMFCore.IO.Writers
{
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    class AMF0XDocumentWriter : IAMFWriter
    {
        public AMF0XDocumentWriter()
        {
        }
        #region IAMFWriter Members

        public bool IsPrimitive { get { return false; } }

        public void WriteData(AMFWriter writer, object data)
        {
            writer.WriteXDocument(data as XDocument);
        }
        #endregion
    }
}