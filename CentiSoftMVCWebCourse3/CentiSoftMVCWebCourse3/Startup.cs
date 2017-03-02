using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CentiSoftMVCWebCourse3.Startup))]
namespace CentiSoftMVCWebCourse3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
