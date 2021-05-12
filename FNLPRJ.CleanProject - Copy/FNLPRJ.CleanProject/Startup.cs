using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FNLPRJ.CleanProject.Startup))]
namespace FNLPRJ.CleanProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
