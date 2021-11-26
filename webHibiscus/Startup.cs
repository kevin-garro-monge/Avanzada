using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webHibiscus.Startup))]
namespace webHibiscus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
