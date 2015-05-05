using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelBookApplication.Startup))]
namespace TravelBookApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
