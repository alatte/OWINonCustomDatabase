using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test_Owin.Startup))]
namespace Test_Owin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
