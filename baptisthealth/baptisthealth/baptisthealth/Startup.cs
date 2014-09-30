using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(baptisthealth.Startup))]
namespace baptisthealth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
