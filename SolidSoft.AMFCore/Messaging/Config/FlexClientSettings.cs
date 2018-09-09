using System;
using System.Xml;

namespace SolidSoft.AMFCore.Messaging.Config
{
    /// <summary>
    /// The flex-client element of the services configuration file.
    /// </summary>
    public sealed class FlexClientSettings
    {
        int _timeoutMinutes = 0;//20;

        /// <summary>
        /// Gets or sets the number of minutes before an idle FlexClient is timed out.
        /// </summary>
        public int TimeoutMinutes
        {
            get { return _timeoutMinutes; }
            set { _timeoutMinutes = value; }
        }

        internal FlexClientSettings()
		{
		}

        internal FlexClientSettings(XmlNode flexClientNode)
		{
            XmlNode timeoutNode = flexClientNode.SelectSingleNode("timeout-minutes");
            if (timeoutNode != null)
			{
                _timeoutMinutes = Convert.ToInt32(timeoutNode.InnerXml);
			}
		}
    }
}