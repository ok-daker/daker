using DChat.Framework.Cache;
using DChat.Framework.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DChat.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger _log;
        private readonly IRedisCache _cache;
        
        public TestController(ILogger log)
        {
            _log = log;
        }
        // GET: Test
        public ActionResult Index()
        {

            _log.Error("ERROR:test by fierce");
            _log.Debug("Debug:test by fierce");
            _log.Information("Information:test by fierce");
            _log.Fatal("Fatal:test by fierce");
            //RedisCache cache = new RedisCache();


            return View();
        }
    }
}