using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.timeTable
{
    /// <summary>
    /// GetTimeTable 的摘要说明
    /// </summary>
    public class GetTimeTable : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            wch.view.bs_TimeTable model = new view.bs_TimeTable();
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
                model.CourseName = context.Request.Params["CourseName"];
            }
            if (context.Request.Params["DepName"] != null)
            {
                model.DepName = context.Request.Params["DepName"];
            }
            if (context.Request.Params["TeaName"] != null)
            {
                model.TeaName = context.Request.Params["TeaName"];
            }
            if (context.Request.Params["TermName"] != null)
            {
                model.TermName = context.Request.Params["TermName"];
            }
            if (context.Request.Params["Site"] != null)
            {
                model.Site = context.Request.Params["Site"];
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