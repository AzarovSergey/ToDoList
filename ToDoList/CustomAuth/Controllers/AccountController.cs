using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Security;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    public class AccountController:Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Login()
        //{
        //    throw new NotImplementedException();
        //}
    }
}