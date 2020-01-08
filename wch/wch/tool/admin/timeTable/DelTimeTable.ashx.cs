using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.timeTable
{
    /// <summary>
    /// DelTimeTable 的摘要说明
    /// </summary>
    public class DelTimeTable : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            string timeTable = context.Request.Params["val"];
            try
            {
                wch.bll.timeTable.Delete(timeTable);
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
                    msg = "删除失败：" + "有学生已选此课程",
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