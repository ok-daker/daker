using DChat.Framework.IOC;
using DChat.WebApi.filters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Unity.WebApi;

namespace DChat.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Resolver.Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config/unity.config"));
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // GlobalConfiguration.Configuration.Filters.Add(new CrossSiteAttribute());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(Resolver.Current.Container);
        }
    }
}
