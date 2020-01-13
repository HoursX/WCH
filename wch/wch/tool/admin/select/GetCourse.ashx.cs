using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.SessionState;

namespace wch.tool.admin.select
{
    /// <summary>
    /// GetCourse 的摘要说明
    /// </summary>
    public class GetCourse : IHttpHandler, IRequiresSessionState
    {

        public int page { get; set; }
        public int limit { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request["page"]))
            {
                page = Convert.ToInt32(context.Request["page"]);
            }

            if (!string.IsNullOrEmpty(context.Request["limit"]))
            {
                limit = Convert.ToInt32(context.Request["limit"]);
            }

            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            wch.view.bs_Course model = new view.bs_Course();
            try
            {
                model.pageIndex = page - 1;
                model.pageSize = limit;
                model.stuID = HttpContext.Current.Session["user"].ToString();
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