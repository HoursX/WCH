using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace wch.tool.admin.course
{
    /// <summary>
    /// GetCourse 的摘要说明
    /// </summary>
    public class GetCourse : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            wch.view.bs_Courses model = new view.bs_Courses();
            if (context.Request["page"] != null)
            {
                model.pageIndex = Convert.ToInt32(context.Request.Params["page"]) - 1;
            }
            if (context.Request.Params["limit"] != null)
            {
                model.pageSize = Convert.ToInt32(context.Request.Params["limit"]);
            }

            if (context.Request.Params["CourseName"] != null)
            {
                model.courseName = context.Request.Params["CourseName"];
            }
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            try
            {
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
            catch (Exception ex)
            {
                var json = new
                {
                    code = 0,
                    msg = ex.Message.ToString(),
                    count = 0,
                    data = 0
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