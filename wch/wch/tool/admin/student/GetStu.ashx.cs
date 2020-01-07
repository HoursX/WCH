using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.student
{
    /// <summary>
    /// GetStu 的摘要说明
    /// </summary>
    public class GetStu : IHttpHandler
    {
        public int page { get; set; }
        public int limit { get; set; }
        public string stuname { get; set; }
        public string stuid { get; set; }

        public string classname { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            wch.view.bs_Student model = new view.bs_Student();
            if (context.Request["page"] != null)
            {
                page = Convert.ToInt32(context.Request.Params["page"]);
                model.pageIndex = page - 1;
            }
            if (context.Request.Params["limit"] != null)
            {
                limit = Convert.ToInt32(context.Request.Params["limit"]);
                model.pageSize = limit;
            }

            string a = context.Request.Params["stuName"];
            if (context.Request.Params["stuName"] != null)
            {
                stuname = context.Request.Params["stuName"];
                model.stuName = stuname;
            }
            if (context.Request.Params["stuID"] != null)
            {
                stuid = context.Request.Params["stuID"];
                model.stuID = stuid;
            }

            if (context.Request.Params["className"] != null)
            {
                classname = context.Request.Params["className"];
                model.className = classname;
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