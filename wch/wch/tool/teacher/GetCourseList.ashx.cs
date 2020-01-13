using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace wch.tool.teacher
{
    /// <summary>
    /// GetCourseList 的摘要说明
    /// </summary>
    public class GetCourseList : IHttpHandler, IRequiresSessionState
    {
        public int page { get; set; }
        public int limit { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            view.bs_Tea model = new view.bs_Tea();
            try
            {
                page = Convert.ToInt32(context.Request["page"]);
                limit = Convert.ToInt32(context.Request["limit"]);
                model.pageIndex = page - 1;
                model.pageSize = limit;
                model.TeaID = HttpContext.Current.Session["user"] == null ? context.Request["user"] : HttpContext.Current.Session["user"].ToString();
                if (context.Request["courseName"] != null)
                {
                    model.CourseName = context.Request["courseName"].ToString();
                }
                model.search();
                var json = new
                {
                    code = 0,
                    msg = "success",
                    count = model.rowCount,
                    data = model.showData
                };
                res.Write(JsonConvert.SerializeObject(json));
            }
            catch (Exception e)
            {

                var json = new
                {
                    code = 500,
                    msg = "error" + e.Message,
                    count = 0,
                    data = ""
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