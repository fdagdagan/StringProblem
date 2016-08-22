using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StringProblem.Startup))]
namespace StringProblem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
