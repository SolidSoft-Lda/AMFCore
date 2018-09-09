using System.Xml;
using System.Collections;

namespace SolidSoft.AMFCore.Messaging.Config
{
    /// <summary>
    /// Contains the properties for configuring server settings for message destinations.
    /// This is the <b>server</b> element in the services-config.xml file.
    /// </summary>
    public sealed class ServerSettings : Hashtable
	{
		internal ServerSettings()
		{
		}

        internal ServerSettings(XmlNode severDefinitionNode)
		{
            foreach (XmlNode propertyNode in severDefinitionNode.SelectNodes("*"))
			{
				if( propertyNode.InnerXml != null && propertyNode.InnerXml != string.Empty )
					this[propertyNode.Name] = propertyNode.InnerXml;
				else
				{
					if( propertyNode.Attributes != null )
					{
						foreach(XmlAttribute attribute in propertyNode.Attributes)
						{
							this[propertyNode.Name + "_" + attribute.Name] = attribute.Value;
						}
					}
				}
			}
		}
        /// <summary>
        /// Gets whether subtopics are allowed.
        /// </summary>
		public bool AllowSubtopics
		{
			get
            { 
                if( this.Contains("allow-subtopics") )
                    return (bool)this["allow-subtopics"];
                return false;
            }
		}
	}
}