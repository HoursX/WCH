﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace wch.tool.admin.Term
{
    /// <summary>
    /// DelTerm 的摘要说明
    /// </summary>
    public class DelTerm : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.ContentType = "text/json";
            string termid = context.Request.Params["val"];
            try
            {
                wch.bll.Terms.Delete(termid);
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
                    msg = "删除失败：" + e.Message,
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