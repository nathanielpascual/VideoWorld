using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoWorld.Startup))]
namespace VideoWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
