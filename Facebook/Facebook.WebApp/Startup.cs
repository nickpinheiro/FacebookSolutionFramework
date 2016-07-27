using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Facebook.WebApp.Startup))]
namespace Facebook.WebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
