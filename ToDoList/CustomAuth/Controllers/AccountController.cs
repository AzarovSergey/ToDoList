using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Security;
using System.Web.Mvc;
using MvcPL.ViewModels;
using System.Web.Security;
using BLL.Interface.Services;

namespace MvcPL.Controllers
{
    [Authorize]
    public class AccountController:Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public AccountController(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login viewModel)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Email, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, true/*remember user*/);
                    //TempData["user"] = userService.GetByEmail(viewModel.Email).ToPlUser();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserAccount()
        {
            return View();
        }

        public string Private()
        {
            return "This is private page.";
        }
        
    }
}