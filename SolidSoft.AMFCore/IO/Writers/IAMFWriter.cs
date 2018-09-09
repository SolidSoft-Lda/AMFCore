namespace SolidSoft.AMFCore.IO.Writers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	interface IAMFWriter
	{
		/// <summary>
		/// Gets a value indicating whether the AMFWriter Type is one of the primitive types.
		/// </summary>
		/// <remarks>The primitive types are those serialized as String, Number, Boolean, Date (CacheResult is treated also as a primitive type)</remarks>
		bool IsPrimitive{ get; }
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="data"></param>
		void WriteData(AMFWriter writer, object data);
	}
}