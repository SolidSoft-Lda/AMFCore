using System.Collections;

namespace SolidSoft.AMFCore.Messaging
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class DotNetFactory : IFlexFactory
	{
        /// <summary>
        /// Initializes a new instance of the DotNetFactory class.
        /// </summary>
        public DotNetFactory()
		{
		}

		#region IFlexFactory Members

        /// <summary>
        /// Creates a FactoryInstance.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="properties">Configuration properties for the destination.</param>
        /// <returns></returns>
		public FactoryInstance CreateFactoryInstance(string id, Hashtable properties)
		{
			DotNetFactoryInstance factoryInstance = new DotNetFactoryInstance(this, id, properties);
			factoryInstance.Source = properties["source"] as string;
			factoryInstance.Scope = properties["scope"] as string;
			if( factoryInstance.Scope == null )
				factoryInstance.Scope = "request";
			factoryInstance.AttributeId = properties["attribute-id"] as string;
			return factoryInstance;
		}
        /// <summary>
        /// Return an instance as appropriate for this instance of the given factory.
        /// </summary>
        /// <param name="factoryInstance"></param>
        /// <returns></returns>
		public object Lookup(FactoryInstance factoryInstance)
		{
			DotNetFactoryInstance dotNetFactoryInstance = factoryInstance as DotNetFactoryInstance;
            if (dotNetFactoryInstance.Scope == "application")
                return dotNetFactoryInstance.ApplicationInstance;
            return dotNetFactoryInstance.CreateInstance();
		}

		#endregion
	}
}