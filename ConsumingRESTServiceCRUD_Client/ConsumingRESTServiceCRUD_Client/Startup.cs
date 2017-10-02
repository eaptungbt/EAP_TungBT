using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConsumingRESTServiceCRUD_Client.Startup))]
namespace ConsumingRESTServiceCRUD_Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
