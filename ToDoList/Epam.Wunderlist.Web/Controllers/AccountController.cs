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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

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

        [HttpPost]
        public void ChangeName(int id,string name)
        {
            var user = userService.GetById(id);
            user.Name = name;
            userService.Update(user);
        }

        [HttpPost]
        public void ChangePhoto()
        {
            var user = userService.GetByEmail(User.Identity.Name);
            if (Request.Files.Count != 1)
            {
                return;
            }
            var stream = Request.Files.Get(0).InputStream;
            byte[] fileBytes = new byte[stream.Length];
            stream.Read(fileBytes,0,(int)stream.Length);
            userService.SetPhoto(user.Id, fileBytes);
        }

        public ActionResult GetPhoto(string randomString)
        {
            var user = userService.GetByEmail(User.Identity.Name);
            Response.Clear();
            var photo = userService.GetPhoto(user.Id);
            if (photo == null)
                return null;
            Response.OutputStream.Write(photo, 0, photo.Length);
            return null;
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