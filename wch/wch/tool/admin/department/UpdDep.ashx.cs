using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.department
{
    /// <summary>
    /// UpdDep 的摘要说明
    /// </summary>
    public class UpdDep : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            string dep = context.Request.Params["val"];
            try
            {
                wch.bll.departments.Update(dep);

                var json = new
                {
                    code = 200,
                    msg = "修改成功",
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