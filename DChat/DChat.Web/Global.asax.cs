﻿using DChat.Framework.IOC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity.Mvc5;

namespace DChat.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Resolver.Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config/unity.config"));
            DependencyResolver.SetResolver(new UnityDependencyResolver(Resolver.Current.Container));
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
