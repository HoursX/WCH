using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.teacher
{
    /// <summary>
    /// GetSelectCourse 的摘要说明
    /// </summary>
    public class GetSelectCourse : IHttpHandler
    {
        public int page { get; set; }
        public int limit { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            page = Convert.ToInt32(context.Request["page"]);
            limit = Convert.ToInt32(context.Request["limit"]);
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            wch.view.bs_CourseSelection model = new view.bs_CourseSelection();
            model.pageIndex = page-1;
            model.pageSize = limit;
            model.search();
            var json = new
            {
                code = 0,
                msg = "",
                count = model.rowCount,
                data = model.showData
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