using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.student
{
    /// <summary>
    /// DelStu 的摘要说明
    /// </summary>
    public class DelStu : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string stuID = context.Request.Params["StuID"];
            HttpResponse res = context.Response;
            
            wch.bll.students.Delete(stuID);
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