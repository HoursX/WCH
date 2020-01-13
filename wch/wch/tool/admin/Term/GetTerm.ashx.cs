using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace wch.tool.admin.Term
{
    /// <summary>
    /// GetTerm 的摘要说明
    /// </summary>
    public class GetTerm : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            wch.view.bs_Term model = new view.bs_Term();
            if (context.Request["page"] != null)
            {
                model.pageIndex = Convert.ToInt32(context.Request.Params["page"]) - 1;
            }
            if (context.Request.Params["limit"] != null)
            {
                model.pageSize = Convert.ToInt32(context.Request.Params["limit"]);
            }

            if (context.Request.Params["termName"] != null)
            {
                model.TermName = context.Request.Params["TermName"];
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