using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BagShop.Startup))]
namespace BagShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
