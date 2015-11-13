using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DChat.WebApi.Controllers
{
    [RoutePrefix("Message")]
    public class MessageController : ApiController
    {
        static Dictionary<int, string> temps;
        static int index = 1;
        static DateTime uptime;

        // GET api/<controller>
        public MessageController()
        {
            if (temps == null)
            {
                temps = new Dictionary<int, string>();
            }

            uptime = DateTime.Now;
        }
        [HttpGet]
        [Route("Get")]
        public dynamic Get(int id = 0)
        {
            return new { Data = temps.Where(t=>t.Key>id).Select(t => t.Value).ToList<string>(), Index = temps.Count == 0 ? 0 : temps.Max(t => t.Key) };
        }

        // GET api/<controller>/5

        [HttpPost]
        [Route("Push")]
        // POST api/<controller>
        public void post()
        {
            var value = this.Request.Content.ReadAsStringAsync().Result;
            int id = index++;
            if (DateTime.Now - uptime >= TimeSpan.FromSeconds(300))
            {
                temps.Clear();
                uptime = DateTime.Now;

            }
            temps.Add(id, value);

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}