using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace wch.tool.universe
{
    /// <summary>
    /// GetTime 的摘要说明
    /// </summary>
    public class GetTime : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            var json = new
            {
                code = 0,
                msg = "success",
                data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            };

            res.Write(JsonConvert.SerializeObject(json));
            res.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}