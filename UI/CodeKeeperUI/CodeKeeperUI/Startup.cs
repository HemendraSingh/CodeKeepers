using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeKeeperUI.Startup))]
namespace CodeKeeperUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
