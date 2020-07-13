using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Owin.Models;
using Test_Owin.Models.Custom;

namespace Test_Owin.Services.Custom
{
    public class CustomSignInManager : SignInManager<CustomUser, string>
    {
        public CustomSignInManager(CustomUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public static CustomSignInManager Create(IdentityFactoryOptions<CustomSignInManager> options, IOwinContext context)
        {
            return new CustomSignInManager(context.GetUserManager<CustomUserManager>(), context.Authentication);
        }

        public bool CheckUser(LoginViewModel model)
        {
            nemo_freshEntities db = new nemo_freshEntities();
            var user = db.Users.Where(x => x.Username == model.Login && x.Password == model.Password).FirstOrDefault();

            return user != null;
        }
    }
}