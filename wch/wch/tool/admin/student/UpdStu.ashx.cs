using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.student
{
    /// <summary>
    /// UpdStu 的摘要说明
    /// </summary>
    public class UpdStu : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            string stu = context.Request.Params["val"];
            try
            {
                wch.bll.students.Update(stu);
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