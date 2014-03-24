using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using XYZ.Interfaces.Dependencies;
using XYZ.Utils.DependencyInjection;

namespace XYZ.Ui.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Attributes.AuthorizeAttribute.LoginUrl = "~/Parceiros/Login";
            AreaRegistration.RegisterAllAreas();

            DependencyConfig.RegisterDependencies(DependencyInjectFactory.GetInstance());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
