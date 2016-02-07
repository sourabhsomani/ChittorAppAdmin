using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChittorAPPAdmin.Startup))]
namespace ChittorAPPAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
