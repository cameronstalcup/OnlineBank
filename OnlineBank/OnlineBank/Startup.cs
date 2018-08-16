using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineBank.Startup))]
namespace OnlineBank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
