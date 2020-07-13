using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Owin.Models.Custom
{
    public class CustomUser : IUser<string>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}