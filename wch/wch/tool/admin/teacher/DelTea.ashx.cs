using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.teacher
{
    /// <summary>
    /// DelTea 的摘要说明
    /// </summary>
    public class DelTea : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string teaID = context.Request.Params["TeaID"];
            HttpResponse res = context.Response;

            wch.bll.teachers.Delete(teaID);
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