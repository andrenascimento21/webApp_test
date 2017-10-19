using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webApp_test.Startup))]
namespace webApp_test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
