using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectMusic.Web.Startup))]
namespace ProjectMusic.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.MapSignalR();
        }
    }
}
