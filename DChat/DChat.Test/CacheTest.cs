using DChat.Framework.Cache;
using DChat.Framework.IOC;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.Test
{
    [TestFixture]
    public class CacheTest
    {
        private IRedisCache _cache;
        [SetUp]
      public void  CacheTest2()
        {
            Resolver.configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"config/unity.config"));
            _cache = Resolver.Current.Resolve<IRedisCache>();
        }
        [TestCase("name","zhangsan")]
        public void SetTest(string name,string value)
        {
            _cache.Add("name", "张三");

        }
        [TestCase("name")]
        public void GetTest(string key)
        {
        var value =  _cache.Get<string>(key);
        Assert.AreEqual(value, "张三");
        }

    }
}
