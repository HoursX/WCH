using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.universe
{
    /// <summary>
    /// GetTheatre 的摘要说明
    /// </summary>
    public class GetTheatre : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            wchEntities dc = new wchEntities();
            var list = (from p in dc.wch_Theatre
                        select new
                        {
                            TheatreID = p.TheatreID,
                            Site = p.Site
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