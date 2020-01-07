using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.department
{
    /// <summary>
    /// GetDepartment 的摘要说明
    /// </summary>
    public class GetDepartment : IHttpHandler
    {

        public int page { get; set; }
        public int limit { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            page = Convert.ToInt32(context.Request["page"]);
            limit = Convert.ToInt32(context.Request["limit"]);
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            wch.view.bs_Department model = new view.bs_Department();
            model.pageIndex = page - 1;
            model.pageSize = limit;
            var json = new
            {
                code = 0,
                msg = "",
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