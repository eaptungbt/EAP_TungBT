using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElevationShop.Startup))]
namespace ElevationShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
