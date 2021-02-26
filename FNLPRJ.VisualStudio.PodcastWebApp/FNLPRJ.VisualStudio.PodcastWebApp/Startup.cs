using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FNLPRJ.VisualStudio.PodcastWebApp.Startup))]
namespace FNLPRJ.VisualStudio.PodcastWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
