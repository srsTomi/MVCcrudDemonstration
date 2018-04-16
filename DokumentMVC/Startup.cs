using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DokumentMVC.Startup))]
namespace DokumentMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
