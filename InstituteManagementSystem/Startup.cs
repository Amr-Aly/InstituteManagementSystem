using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InstituteManagementSystem.Startup))]
namespace InstituteManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
