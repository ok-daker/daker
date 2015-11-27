using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DChat.Core.context;
using DChat.Core.interfaces;
using DChat.Model.Models;

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
        public JsonResult Login(string name, string password)
        {
            var member = _service.Login(name, password);
            if (member != null)
            {
                HttpCookie cookie = new HttpCookie("DAKER_USR_ID", member.Id.ToString());
                cookie.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(cookie);
                UsersContext.AddOnLine(member);
                return Json(new { status = 1, Data = member }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { status = 0, message = "用户名或者密码错误" });

            }
        }

        public JsonResult Info()
        {
            if (Request.Cookies.Get("DAKER_USR_ID") != null)
            {
                int id = int.Parse(Request.Cookies.Get("DAKER_USR_ID").Value);
                var member = _service.GetByID(id);
                return Json(new { status = 1, Data = member }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { status = 0},JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Regester()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Regester(UserInfo usr)
        {
            try
            {
                if (!string.IsNullOrEmpty(usr.Name) && !string.IsNullOrEmpty(usr.Password))
                {
                    var ur = _service.Regester(usr);
                    _service.Login(ur.Name, ur.Password);
                    HttpCookie cookie = new HttpCookie("DAKER_USR_ID", ur.Id.ToString());
                    cookie.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(cookie);
                    Response.Redirect("../Home/index");
                }
                return Content("用户名和密码不能为空.");

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }

        public JsonResult Onlines()
        {
            return Json(new { status = 1, Data = UsersContext.Users }, JsonRequestBehavior.AllowGet);

        }

        public void OffLine(int id)
        {
            UsersContext.SetOffLine(id);

        }

        public bool CheckExist(string name)
        {
            return _service.Exsist(name);
        }
    }
}