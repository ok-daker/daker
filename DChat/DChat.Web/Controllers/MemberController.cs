using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DChat.Core.interfaces;

namespace DChat.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _service;
        //
        // GET: /Member/
        public MemberController(IMemberService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string name, string pwd)
        {
            var member = _service.Login(name, pwd);
            if (member != null)
            {
                Session.Add("user:" + name, member);
                return Json(new { status = 0, Data = member }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { status = 1, message = "用户名或者密码错误" });

            }
        }
    }
}