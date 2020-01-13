using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace wch.tool.admin.select
{
    /// <summary>
    /// DeleteCourse 的摘要说明
    /// </summary>
    public class DeleteCourse : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
           
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            try
            {
                string stuID = HttpContext.Current.Session["user"].ToString();
                string timeID = context.Request.Params["TimeID"];
                wch.bll.courseSelect.Delete(stuID,timeID);
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