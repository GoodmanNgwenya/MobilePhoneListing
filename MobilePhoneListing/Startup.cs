using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobilePhoneListing.Startup))]
namespace MobilePhoneListing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
