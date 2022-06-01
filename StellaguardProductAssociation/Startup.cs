using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StellaguardProductAssociation.Startup))]
namespace StellaguardProductAssociation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
