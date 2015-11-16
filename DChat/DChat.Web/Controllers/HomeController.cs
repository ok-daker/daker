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
            var list = db.MsgItems.ToList();
            //创建表 且将字段加入
            UserInfo userInfo = new UserInfo();
            userInfo.Name = "windfierce";
            //将表加入数据库
            db.UserInfos.Add(userInfo);
            MsgItem msg = new MsgItem();
            msg.Id = Guid.NewGuid();
            msg.MsgContent = "aaa";
            msg.SendTime=DateTime.Now;
            msg.UserId = 1;
            msg.Pre = msg;

            db.MsgItems.Add(msg);
            db.SaveChanges();
            MsgItem msg2 = new MsgItem();
            msg2.Id = Guid.NewGuid();
            msg2.MsgContent = "aaa";
            msg2.SendTime = DateTime.Now;
            msg2.UserId = 1;
            msg2.Pre = msg;
            db.MsgItems.Add(msg2);
            db.SaveChanges();



            return View();
        }
	}
}