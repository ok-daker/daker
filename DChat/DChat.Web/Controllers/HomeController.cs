using DChat.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DChat.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //创建上下文
            ChatDbContext db = new ChatDbContext();
            //创建数据库
            db.Database.CreateIfNotExists();
            //创建表 且将字段加入
            UserInfo userInfo = new UserInfo();
            userInfo.Name = "windfierce";
            //将表加入数据库
            db.UserInfo.Add(userInfo);
            db.SaveChanges();



            return View();
        }
	}
}