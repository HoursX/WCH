using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.teacher
{
    /// <summary>
    /// GetTeather 的摘要说明
    /// </summary>
    public class GetTeacher : IHttpHandler
    {
        public string teaname { get; set; }
        public string teaid { get; set; }
        public string depname { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";

            wch.view.bs_Teacher model = new view.bs_Teacher();
            try
            {
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

                string a = context.Request.Params["teaName"];
                if (context.Request.Params["teaName"] != null)
                {
                    teaname = context.Request.Params["teaName"];
                    model.teaName = teaname;
                }
                if (context.Request.Params["teaID"] != null)
                {
                    teaid = context.Request.Params["teaID"];
                    model.teaID = teaid;
                }
                if (context.Request.Params["depName"] != null)
                {
                    depname = context.Request.Params["depName"];
                    model.depName = depname;
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
                    code = 0,
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