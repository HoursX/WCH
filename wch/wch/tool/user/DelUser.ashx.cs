using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace wch.tool.user
{
    /// <summary>
    /// DelUser 的摘要说明
    /// </summary>
    public class DelUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string UserID = context.Request.Params["UserID"];
            HttpResponse res = context.Response;
            try
            {
                wch.bll.user.Delete(UserID);
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