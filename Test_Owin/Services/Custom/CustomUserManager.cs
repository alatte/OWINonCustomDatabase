using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Owin.Models;
using Test_Owin.Models.Custom;

namespace Test_Owin.Services.Custom
{
    public class CustomUserManager : UserManager<CustomUser>
    {      
        public CustomUserManager(IUserStore<CustomUser> store)
            : base(store)
        {
        }

        public static CustomUserManager Create()
        {
            var manager = new CustomUserManager(new CustomUserStore());
            return manager;
        }
    }
}