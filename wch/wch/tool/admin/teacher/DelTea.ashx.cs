using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.teacher
{
    /// <summary>
    /// DelTea 的摘要说明
    /// </summary>
    public class DelTea : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            try
            {
                string teaID = context.Request.Params["TeaID"];
                wch.bll.teachers.Delete(teaID);
                var json = new
                {
                    code = 200,
                    msg = "删除成功",
                };
            
                res.Write(JsonConvert.SerializeObject(json));
            }
            catch (Exception e)
            {
                var json = new
                {
                    code = 500,
                    msg = "出现错误" + e.Message,
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