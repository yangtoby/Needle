
using CommonServiceLocator;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YY.Needle.Data.Context;
using YY.Needle.Data.Context.Interfaces;
using YY.Needle.Web.App_Start;
using YY.Needle.Web.AutoMapperInit;

namespace YY.Needle.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
            // DependencyResolver.SetResolver(new NinjectDependencyResolver());
           // ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
        protected void Application_EndRequest()
        {
            //if (ServiceLocator.Current.GetInstance<IContextManager<LotteryContext>>() is ContextManager<LotteryContext> contextManager)
            //{
            //    contextManager.GetContext().Dispose();
            //}
        }
    }
}
