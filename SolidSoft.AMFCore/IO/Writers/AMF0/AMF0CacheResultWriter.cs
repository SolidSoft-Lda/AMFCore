namespace SolidSoft.AMFCore.IO.Writers
{
    class AMF0CacheableObjectWriter : IAMFWriter
    {
        public AMF0CacheableObjectWriter()
        {
        }

        #region IAMFWriter Members

        public bool IsPrimitive { get { return true; } }

        public void WriteData(AMFWriter writer, object data)
        {
            writer.WriteData(ObjectEncoding.AMF0, (data as CacheableObject).Object);
        }

        #endregion
    }
}