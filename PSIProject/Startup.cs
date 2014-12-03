using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PSIProject.Startup))]
namespace PSIProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
