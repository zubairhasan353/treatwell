using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(treatwell.Startup))]
namespace treatwell
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
