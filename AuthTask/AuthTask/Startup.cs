using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthTask.Startup))]
namespace AuthTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
