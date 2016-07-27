using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Facebook.MobileApp.Startup))]

namespace Facebook.MobileApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}