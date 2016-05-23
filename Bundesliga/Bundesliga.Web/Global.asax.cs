using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Bundesliga.Web;
using Microsoft.Practices.Unity;
using Bundesliga.Web.Services;
using Bundesliga.DataAccess;

namespace Bundesliga.Web
{
    public class Global : HttpApplication
    {
        public static IUnityContainer Container { get; private set; }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            Container = CreateContainer();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RegisterRoutes(RouteTable.Routes);
        }

        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Games", "Games", "~/Games.aspx");
        }

        private IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IRankingService, RankingService>();
            container.RegisterType<BundesligaContext, BundesligaContext>();
            container.RegisterType<IRepository<Team>, TeamRepository>();
            container.RegisterType<IRepository<Game>, GameRepository>();
            return container;
        }

        public static T Resolve<T>(string name = null)
        {
            return name == null ? Container.Resolve<T>() : Container.Resolve<T>(name);
        }

        void Application_End(object sender, EventArgs e)
        {
            if (Container != null)
            {
                Container.Dispose();
            }
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        internal static void BuildUp(object obj)
        {
            Container.BuildUp(obj);
        }
    }
}
