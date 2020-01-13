using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.department
{
    /// <summary>
    /// DelDep 的摘要说明
    /// </summary>
    public class DelDep : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            

            
            try
            {
                string depID = context.Request.Params["DepID"];
                wch.bll.departments.Delete(depID);
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
                    msg = "出现错误：" + e.Message,
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