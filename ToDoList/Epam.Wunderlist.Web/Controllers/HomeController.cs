using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Wunderlist.Web.Controllers
{
    [Authorize]
    public class HomeController:Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("AppView");
        }

        [HttpGet]
        public ActionResult AppView()
        {
            return View();
        }
    }
}