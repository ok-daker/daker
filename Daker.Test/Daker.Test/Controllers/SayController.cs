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
        public ActionResult Cry()
        {
            return Content("):--hahha");
        }
        public ActionResult Hi()
        {
            return Content("Hi-hi");
        }
<<<<<<< HEAD
        public ActionResult Wind()
        {
            return Content("hu~~~");
        }
=======
            public ActionResult Wind()
            {
                return Content("abc-at-home");
            }
>>>>>>> 9ab1dbe1cf854738c258f8395c4b41b2a1f90987
	}
}
