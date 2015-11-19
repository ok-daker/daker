using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Http;
using System.Web.Http;
using DChat.Model.DTO;
using DChat.Model.Models;

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
            List<MsgItemDTO> msgDTO = new List<MsgItemDTO>();
            MsgItemDTO msg = new MsgItemDTO();
            msg.SendTime = DateTime.Now;
            msg.Id = Guid.NewGuid();
            msg.MsgContent = "哈哈哈，你好啊";
            msg.UserId = 1;
            msg.Sender = new UserInfo()
            {
                HeadImgPath = "../images/2.jpg",
                NickName = "Lisa"

            };

            MsgItemDTO msg2 = new MsgItemDTO();
            msg2.SendTime = DateTime.Now;
            msg2.Id = Guid.NewGuid();
            msg2.MsgContent = "哈哈哈，你也好";
            msg2.UserId = 1;
            msg2.Sender = new UserInfo()
            {
                HeadImgPath = "../images/1.jpg",
                NickName = "Hane"

            };
            msgDTO.Add(msg);
            msgDTO.Add(msg2);
            return msgDTO;
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