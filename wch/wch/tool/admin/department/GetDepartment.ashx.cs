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
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            try
            {
                page = Convert.ToInt32(context.Request["page"]);
                limit = Convert.ToInt32(context.Request["limit"]);
                string depName = context.Request["DepName"];
            
                wch.view.bs_Department model = new view.bs_Department();
                model.pageIndex = page - 1;
                model.pageSize = limit;
                if (!string.IsNullOrEmpty(depName))
                {
                    model.DepName = depName;
                }

                model.search();
                var json = new
                {
                    code = 0,
                    msg = "",
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
                    msg = e.Message,
                    count = 0,
                    data = ""

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