using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Security;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    [Authorize]
    public class AccountController:Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult Login()
        //{
        //    throw new NotImplementedException();
        //}

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        
    }
}