using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoAspNet.Startup))]
namespace ProjetoAspNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
