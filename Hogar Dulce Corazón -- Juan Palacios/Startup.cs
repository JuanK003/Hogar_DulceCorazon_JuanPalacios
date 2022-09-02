using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hogar_Dulce_Corazón____Juan_Palacios.Startup))]
namespace Hogar_Dulce_Corazón____Juan_Palacios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
