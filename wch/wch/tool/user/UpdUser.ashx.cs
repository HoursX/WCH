using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace wch.tool.user
{
    /// <summary>
    /// UpdUser 的摘要说明
    /// </summary>
    public class UpdUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            string filePath = string.Empty;
            string fileNewName = string.Empty;
            HttpFileCollection files = context.Request.Files;
            string val = context.Request.Params["val"];

            try
            {
                if (files.Count > 0)
                {
                    fileNewName = DateTime.Now.ToString("yyyyMMddHHmmssff") + "_" + System.IO.Path.GetFileName(files[0].FileName);
                    //保存文件
                    filePath = "/upload/" + fileNewName;
                    files[0].SaveAs(context.Server.MapPath("~" + filePath));
                }
                
                
                wch.bll.user.Update(val, filePath);
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