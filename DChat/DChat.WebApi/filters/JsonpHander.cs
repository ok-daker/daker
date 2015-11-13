using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DChat.WebApi.filters
{
    public class JsonpHandler : DelegatingHandler
    {
        protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {

            var response = await base.SendAsync(request, cancellationToken);

            if (true || request.Content.Headers.ContentType.MediaType == "application/jsonp")
            {
                object content;
                response.TryGetContentValue(out content);
                var callback =
                    request.GetQueryNameValuePairs().FirstOrDefault(x => x.Key.ToLower() == "callback").Value;

                if (callback != null)
                {
                    var newResponse = string.Format("{0}({1});", callback,
                        JsonConvert.SerializeObject(content,
                        GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings));
                    response.Content = new StringContent(newResponse);
                }
            }
            response.Headers.Add("Access-Control-Allow-Origin","*");
            return response;
        }
    }
}