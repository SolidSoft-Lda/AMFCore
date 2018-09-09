using System;
using System.Collections;
using System.Xml;

namespace SolidSoft.AMFCore.Messaging.Config
{
	/// <summary>
    /// Contains the properties for configuring the destination network element.
    /// This is the <b>network</b> element in the services-config.xml file.
	/// </summary>
	public sealed class NetworkSettings : Hashtable
	{
        private NetworkSettings()
        {
        }

		internal NetworkSettings(XmlNode networkDefinitionNode)
		{
			foreach(XmlNode propertyNode in networkDefinitionNode.SelectNodes("*"))
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
        /// Gets whether data paging is enabled for the destination.
        /// </summary>
		public bool PagingEnabled
		{
			get
			{
				if( this.ContainsKey("paging_enabled")  )
					return Convert.ToBoolean(this["paging_enabled"]);
				return false;
			}
		}
        /// <summary>
        /// Gets the paging size. When paging is enabled, this indicates the number of records to be sent to the client when the client-side DataService.fill() method is called.
        /// </summary>
		public int PagingSize
		{
			get
			{
				if( this.ContainsKey("paging_pageSize")  )
					return Convert.ToInt32(this["paging_pageSize"]);
				return 0;
			}
		}
        /// <summary>
        /// Gets the idle time in minutes before a subscriber is unsubscribed.
        /// The value to 0 (zero) means subscribers are not forced to unsubscribe automatically.
        /// </summary>
        /// <remarks>The default value is 20.</remarks>
		public int SessionTimeout
		{
			get
			{
				if( this.ContainsKey("session-timeout")  )
					return Convert.ToInt32(this["session-timeout"]);
				return 20;
			}
		}
	}
}