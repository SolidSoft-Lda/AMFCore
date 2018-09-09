using System;
using System.Collections;
using System.Xml;

namespace SolidSoft.AMFCore.Messaging.Config
{
	/// <summary>
    /// Contains the properties for configuring destination metadata.
    /// This is the <b>metadata</b> element in the services-config.xml file.
	/// </summary>
	public sealed class MetadataSettings : Hashtable
	{
		ArrayList _identity = new ArrayList();
		ArrayList _associations = new ArrayList();

        private MetadataSettings()
        {
        }

		internal MetadataSettings(XmlNode metadataDefinitionNode)
		{
			foreach(XmlNode propertyNode in metadataDefinitionNode.SelectNodes("*"))
			{
				if( propertyNode.InnerXml != null && propertyNode.InnerXml != string.Empty )
					this[propertyNode.Name] = propertyNode.InnerXml;
				else
				{
					if( propertyNode.Name == "identity" )
					{
						foreach(XmlAttribute attribute in propertyNode.Attributes)
						{
							_identity.Add(attribute.Value);
						}
					}
					if( propertyNode.Name == "many-to-one" )
					{
						Hashtable association = new Hashtable(3);
						foreach(XmlAttribute attribute in propertyNode.Attributes)
						{
							association[attribute.Name] = attribute.Value;
						}
						_associations.Add(association);
					}
				}
			}
		}
        /// <summary>
        /// Gets the properties to be used to guarantee unique identity among items in a collection of data.
        /// </summary>
		public ArrayList Identity
		{
			get
			{
				return _identity;
			}
		}
	}
}