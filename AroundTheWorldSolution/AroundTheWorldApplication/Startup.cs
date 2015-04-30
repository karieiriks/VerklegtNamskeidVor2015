using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AroundTheWorldApplication.Startup))]
namespace AroundTheWorldApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
