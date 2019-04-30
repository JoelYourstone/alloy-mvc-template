using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Globalization;
using EPiServer.ServiceLocation;

namespace AlloyTemplates.Business.Initialization
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class MyInitializer : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
            
        }

        public void Uninitialize(InitializationEngine context)
        {
            
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Intercept<IUpdateCurrentLanguage>((locator, defaultClass) =>
                new CustomUpdateCurrentLanguage(defaultClass));
        }
    }
}
