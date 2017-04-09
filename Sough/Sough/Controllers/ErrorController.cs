using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sough.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Httpnotfound()
        {
            return View();
        }

        public ActionResult DelaiDepassee()
        {
            return View();
        }


    }
}
