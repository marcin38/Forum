using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Forum.Startup))]
namespace Forum
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {}            
    }
}