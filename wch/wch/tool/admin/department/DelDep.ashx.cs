using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.department
{
    /// <summary>
    /// DelDep 的摘要说明
    /// </summary>
    public class DelDep : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string depID = context.Request.Params["DepID"];
            HttpResponse res = context.Response;

            wch.bll.departments.Delete(depID);
            var json = new
            {
                code = 200,
                msg = "success",
            };
            res.ContentType = "text/json";
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