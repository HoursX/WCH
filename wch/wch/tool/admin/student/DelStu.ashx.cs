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
            
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            try
            {
                string stuID = context.Request.Params["StuID"];
                wch.bll.students.Delete(stuID);
                var json = new
                {
                    code = 200,
                    msg = "删除成功",
                };
                res.Write(JsonConvert.SerializeObject(json));
            }
            catch (Exception e)
            {
                var json = new
                {
                    code = 500,
                    msg = "出现错误" + e.Message,
                };
                res.Write(JsonConvert.SerializeObject(json));
            }
            
            
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