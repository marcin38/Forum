using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Forum.Startup))]
namespace Forum
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {

            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    //AuthenticationType = DefaultAuthenticationTypes.ExternalCookie,
            //    ////AuthenticationMode = AuthenticationMode.Passive,
            //    //CookieName = "f_user2",
            //    LoginPath = new PathString("/User/Login"),

            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    CookieSecure = CookieSecureOption.SameAsRequest
            //});

            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }            
    }
}