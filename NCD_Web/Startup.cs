using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NCD_Web.Startup))]
namespace NCD_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
