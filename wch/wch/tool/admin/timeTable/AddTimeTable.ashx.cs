using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wch.tool.admin.timeTable
{
    /// <summary>
    /// AddTimeTable 的摘要说明
    /// </summary>
    public class AddTimeTable : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            string timeTable = context.Request.Params["val"];
            try
            {
                wch.bll.timeTable.Add(timeTable);
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
                    msg = "出现错误：" + "设置时间或地点发生冲突，请选择其他的时间或地点",
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