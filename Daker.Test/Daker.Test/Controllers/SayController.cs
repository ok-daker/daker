using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Daker.Test.Controllers
{
    public class SayController : Controller
    {
        //
        // GET: /Say/
        public ActionResult Hello()
        {
            return View();
        }
            public ActionResult Hi()
        {
            return Content("Hi-hi");
        }
	}
}
