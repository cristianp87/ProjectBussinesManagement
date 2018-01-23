using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Project_BusinessManagement.Startup))]
namespace Project_BusinessManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}