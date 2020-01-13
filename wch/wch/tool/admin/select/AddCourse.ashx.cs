using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace wch.tool.admin.select
{
    /// <summary>
    /// AddCourse 的摘要说明
    /// </summary>
    public class AddCourse : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            string sel = context.Request.Params["timeID"];
            string stuID = HttpContext.Current.Session["user"].ToString();
            try
            {
                wch.bll.courseSelect.Add(stuID,sel);
                var json = new
                {
                    code = 200,
                    msg = "选课成功",
                };
                res.Write(JsonConvert.SerializeObject(json));

            }
            catch (Exception e)
            {
                var json = new
                {
                    code = 500,
                    msg = "该课程与您上课时间有冲突或选课时间未到，选课时间结束：" + e.Message,
                };
                res.Write(JsonConvert.SerializeObject(json));
            }
            finally
            {
                res.End();
            }
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