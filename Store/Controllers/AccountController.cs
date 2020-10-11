using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> SignInManager;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.SignInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser findedUser = await userManager.FindByNameAsync(registerModel.Name);
                if (findedUser == null)
                {
                    IdentityUser user = new IdentityUser() { UserName = registerModel.Name };
                    await userManager.CreateAsync(user, registerModel.Password);
                    return RedirectToAction(actionName: "Index", controllerName: "Admin");
                }
                ModelState.AddModelError("","this name is taken");
            }
            return View(registerModel);
        }


        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await SignInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult inResult = 
                    await SignInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                    if (inResult.Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "~/Admin/Index");
                    }
                }
            }
            ModelState.AddModelError("","Invalid name or password");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await SignInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

    }
}
