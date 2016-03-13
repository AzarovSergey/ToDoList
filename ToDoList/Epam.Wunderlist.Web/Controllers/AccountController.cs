using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Security;
using System.Web.Mvc;
using Epam.Wunderlist.Web.ViewModels;
using System.Web.Security;
using Epam.Wunderlist.Services.Interface.Services;
using Epam.Wunderlist.Web.Providers;
using System.Diagnostics;

namespace Epam.Wunderlist.Web.Controllers
{
    [Authorize]
    public class AccountController:Controller
    {
        private readonly UserServiceBase userService;
        private readonly RoleServiceBase roleService;

        public AccountController(UserServiceBase userService, RoleServiceBase roleService)
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

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Register viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetByEmail(viewModel.Email);
                if (user != null)
                {
                    ModelState.AddModelError("", "User with this address already registered.");
                    return View(viewModel);
                }
                var membershipUser = ((CustomMembershipProvider)Membership.Provider)
                    .CreateUser(viewModel.Email, viewModel.Password, viewModel.Name);
                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return RedirectToAction("Index", "Home");
        }


        
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }



        [HttpGet]
        public JsonResult UserAccount()
        {
            return Json(userService.GetByEmail(User.Identity.Name), JsonRequestBehavior.AllowGet);
        }

        public string Private()
        {
            return "This is private page.";
        }
        
    }
}