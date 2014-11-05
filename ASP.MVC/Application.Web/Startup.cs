using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Application.Web.Startup))]
namespace Application.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
