using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AquaWorld.Web.Startup))]
namespace AquaWorld.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
