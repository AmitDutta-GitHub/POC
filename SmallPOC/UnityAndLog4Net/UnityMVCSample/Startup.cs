using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnityMVCSample.Startup))]
namespace UnityMVCSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
