using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoslynProofsWeb.Startup))]
namespace RoslynProofsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
