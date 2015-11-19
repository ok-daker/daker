using DChat.DataAccess;
using DChat.Model.Models;
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
            //ChatDbContext db = new ChatDbContext();
            ////创建数据库
            ////db.Database.CreateIfNotExists();
            //IEnumerable<MsgItem> list = db.MsgItems.ToList();


            ////创建表 且将字段加入
            //UserInfo userInfo = new UserInfo();
            //userInfo.Name = "windfierce";
            ////将表加入数据库
            //db.UserInfos.Add(userInfo);
            //MsgItem msg = new MsgItem
            //{
            //    Id = Guid.NewGuid(),
            //    MsgContent = "aaa",
            //    SendTime = DateTime.Now,
            //    UserId = 1
            //};
            //msg.Pre = msg;

            //db.MsgItems.Add(msg);
            //db.SaveChanges();
            //MsgItem msg2 = new MsgItem
            //{
            //    Id = Guid.NewGuid(),
            //    MsgContent = "aaa",
            //    SendTime = DateTime.Now,
            //    UserId = 1,
            //    Pre = msg
            //};
            //db.MsgItems.Add(msg2);
            //db.SaveChanges();



            return View();
        }
	}
}