using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace wch.tool.admin.Classes
{
    /// <summary>
    /// GetClass 的摘要说明
    /// </summary>
    public class GetClass : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            wch.view.bs_Class model = new view.bs_Class();
            if (!string.IsNullOrEmpty(context.Request.Params["page"]))
            {
                model.pageIndex = Convert.ToInt32(context.Request.Params["page"]) - 1;
            }
            if (!string.IsNullOrEmpty(context.Request.Params["limit"]))
            {
                model.pageSize = Convert.ToInt32(context.Request.Params["limit"]);
            }

            if (!string.IsNullOrEmpty(context.Request.Params["ClassName"]))
            {
                model.className = context.Request.Params["ClassName"];
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