using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Wunderlist.Web.App_Code
{
    public class JsonHelper
    {
        public object RedirectToAuthenticationObject()
        {
            return new { redirect = "/account/login/" };
        }
    }
}