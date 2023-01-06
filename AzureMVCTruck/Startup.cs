using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureMVCTruck.Startup))]
namespace AzureMVCTruck
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
