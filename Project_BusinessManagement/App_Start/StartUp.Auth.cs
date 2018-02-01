using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Project_BusinessManagement.Models;
using Project_BusinessManagement.Security;
using System;

namespace Project_BusinessManagement
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user 
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<CustomUserManager, MUser>(
                    validateInterval: TimeSpan.FromMinutes(1),
                    regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager)),
                },
                SlidingExpiration = true,
                //Use this to customize the timeout duration if the default is too short/long
                ExpireTimeSpan = TimeSpan.FromMinutes(10)
            });
        }
    }
}