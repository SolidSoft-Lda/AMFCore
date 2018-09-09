using SolidSoft.AMFCore.Exceptions;

namespace SolidSoft.AMFCore.IO.Readers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMFUnknownTagReader : IAMFReader
	{
		public AMFUnknownTagReader()
		{
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader)
		{
			throw new UnexpectedAMF();
		}

		#endregion
	}
}