using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentWcfConsume.Startup))]
namespace StudentWcfConsume
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
