using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.universe
{
    /// <summary>
    /// getClass 的摘要说明
    /// </summary>
    public class getClass : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            wchEntities dc = new wchEntities();
            var list = (from p in dc.wch_Class
                        select new
                        {
                            ClassID = p.ClassID,
                            ClassName = p.ClassName
                        });
            var json = new
            {
                code = 0,
                msg = "success",
                count = list.ToList().Count,
                data = list
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