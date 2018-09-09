using System.Collections;
using System.Xml;

namespace SolidSoft.AMFCore.Messaging.Config
{
    /// <summary>
    /// Contains the properties for configuring MSQM service adapters.
    /// This is the <b>msmq</b> element in the services-config.xml file.
    /// </summary>
    public sealed class MsmqSettings : Hashtable
    {
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string BinaryMessageFormatter = "BinaryMessageFormatter";
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string XmlMessageFormatter = "XmlMessageFormatter";

        private MsmqSettings()
        {
        }

        internal MsmqSettings(XmlNode msmqDefinitionNode)
		{
            foreach (XmlNode propertyNode in msmqDefinitionNode.SelectNodes("*"))
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
        /// Gets the name of the MSMQ queue.
        /// </summary>
        public string Name
        {
            get
            {
                if (this.ContainsKey("name"))
                    return this["name"] as string;
                return null;
            }
        }
        /// <summary>
        /// Gets the message formatter type.
        /// </summary>
        public string Formatter
        {
            get
            {
                if (this.ContainsKey("formatter"))
                    return this["formatter"] as string;
                return null;
            }
        }
        /// <summary>
        /// Gets the message label.
        /// </summary>
        public string Label
        {
            get
            {
                if (this.ContainsKey("label"))
                    return this["label"] as string;
                return null;
            }
        }
    }
}