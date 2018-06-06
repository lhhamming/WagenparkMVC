using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WagenparkMVC.Startup))]
namespace WagenparkMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
