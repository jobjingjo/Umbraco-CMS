﻿using System.Configuration;

namespace Umbraco.Core.Configuration.UmbracoSettings
{
    internal class UmbracoSettingsSection : ConfigurationSection
    {
        [ConfigurationProperty("backOffice")]
        public BackOfficeElement BackOffice => (BackOfficeElement)this["backOffice"];

        [ConfigurationProperty("content")]
        public ContentElement Content => (ContentElement)this["content"];

        [ConfigurationProperty("security")]
        public SecurityElement Security => (SecurityElement)this["security"];

        [ConfigurationProperty("requestHandler")]
        public RequestHandlerElement RequestHandler => (RequestHandlerElement)this["requestHandler"];

        [ConfigurationProperty("logging")]
        public LoggingElement Logging => (LoggingElement)this["logging"];

        [ConfigurationProperty("web.routing")]
        public WebRoutingElement WebRouting => (WebRoutingElement)this["web.routing"];

        [ConfigurationProperty("keepAlive")]
        internal KeepAliveElement KeepAlive => (KeepAliveElement)this["keepAlive"];
    }
}
