using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace wch.tool.admin.course
{
    /// <summary>
    /// AddCourse 的摘要说明
    /// </summary>
    public class AddCourse : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            string course_json = context.Request.Params["val"];
            try
            {
                wch.bll.Course.Add(course_json);
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
                    msg = "添加失败：" + e.Message,
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