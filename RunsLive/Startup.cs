using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RunsLive.Startup))]
namespace RunsLive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
