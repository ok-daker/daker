using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Http;
using System.Web.Http;
using DChat.Core.context;
using DChat.Core.interfaces;
using DChat.Model.DTO;
using DChat.Model.Models;

namespace DChat.WebApi.Controllers
{
    [RoutePrefix("Message")]
    public class MessageController : ApiController
    {
        private readonly IMsgHandler _handler;
        static Dictionary<int, string> temps;
        static int index = 1;
        static DateTime uptime;

        // GET api/<controller>
        public MessageController(IMsgHandler handler)
        {
            _handler = handler;
            if (temps == null)
            {
                temps = new Dictionary<int, string>();
            }

            uptime = DateTime.Now;
        }
        [HttpGet]
        [Route("Get")]
        public dynamic Get(Guid? id)
        {
            var msgs = _handler.Get(id);
            var usrs = UsersContext.Users;
            return new { Message = msgs, Users = usrs };
        }

        // GET api/<controller>/5

        [HttpPost]
        [Route("Push")]
        // POST api/<controller>
        public void post()
        {
            var value = this.Request.Content.ReadAsStringAsync().Result;
            MsgItem msg = JsonConvert.DeserializeObject<MsgItem>(value);
            _handler.Push(msg);
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