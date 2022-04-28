using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EldenRing.WebMVC.Startup))]
namespace EldenRing.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
