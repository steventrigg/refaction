using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Web.Http;

namespace refactor_me
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer windsorContainer;

        internal static IWindsorContainer getIocContainer()
        {
            return windsorContainer;
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            windsorContainer = new WindsorContainer();
            windsorContainer.Install(FromAssembly.This());
        }
    }
}
