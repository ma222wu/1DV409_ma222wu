using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2_1DV409.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Error()
        {
            return View("Error");
        }

        public ActionResult Error403()
        {
            return View("Error");
        }

        public ActionResult Error404()
        {
            return View("Error");
        }

    }
}
