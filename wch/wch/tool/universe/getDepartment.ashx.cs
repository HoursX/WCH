using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace wch.tool.universe
{
    /// <summary>
    /// getDepartment 的摘要说明
    /// </summary>
    public class getDepartment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            wchEntities dc = new wchEntities();
            var list = (from p in dc.wch_Department
                select new
                {
                    DepID = p.DepID,
                    DepName = p.DepName
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