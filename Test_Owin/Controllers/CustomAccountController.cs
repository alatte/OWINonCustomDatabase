using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Test_Owin.Models;
using Test_Owin.Models.Custom;
using Test_Owin.Services.Custom;

namespace Test_Owin.Controllers
{
    public class CustomAccountController : Controller
    {
        private CustomSignInManager _signInManager;
        public CustomSignInManager CustomSignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<CustomSignInManager>();
            }
            private set { _signInManager = value; }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            CustomUser customUser = await new CustomUserStore().FindByNameAsync(model.Login);

            if (CustomSignInManager.CheckUser(model))
            {
                //creates and signs a cookie.
                await CustomSignInManager.SignInAsync(customUser, isPersistent: true, rememberBrowser: false);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Неудачная попытка входа.");
                return View(model);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}