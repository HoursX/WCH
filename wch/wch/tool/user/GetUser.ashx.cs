using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.user
{
    /// <summary>
    /// GetUser 的摘要说明
    /// </summary>
    public class GetUser : IHttpHandler
    {
        public int page { get; set; }
        public int limit { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            wch.view.bs_User model = new view.bs_User();
            try
            {
                if (!string.IsNullOrEmpty(context.Request["userID"]))
                {
                    model.userID = context.Request["userID"];
                }

                if (!string.IsNullOrEmpty(context.Request["nickName"]))
                {
                    model.nickName = context.Request["nickName"];
                }
                if (!string.IsNullOrEmpty(context.Request["page"]))
                {
                    model.pageIndex = Convert.ToInt32(context.Request["page"]) -1;
                }
                if (!string.IsNullOrEmpty(context.Request["limit"]))
                {
                    model.pageSize = Convert.ToInt32(context.Request["limit"]);
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
            catch (Exception ex)
            {
                var json = new
                {
                    code = 500,
                    msg = ex.Message,
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