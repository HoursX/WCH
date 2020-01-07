using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.teacher
{
    /// <summary>
    /// AddTea 的摘要说明
    /// </summary>
    public class AddTea : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            string tea = context.Request.Params["val"];
            try
            {
                wch.bll.teachers.Add(tea);
                var json = new
                {
                    code = 200,
                    msg = "添加成功",
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