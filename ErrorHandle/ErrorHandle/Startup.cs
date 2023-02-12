using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ErrorHandle.Startup))]
namespace ErrorHandle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
