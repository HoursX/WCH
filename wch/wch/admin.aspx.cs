using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using wch;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace wch
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public string GetStudents()
        {
            wchEntities entity = new wchEntities();
            List<wch.wch_Student> list = entity.wch_Student.ToList<wch.wch_Student>();
            return JsonConvert.SerializeObject(list);

        }
        public void JsOutput(string info)
        {
            string output = "<script>alert('{0}')</script>";
            output = string.Format(output, info);
            Response.Write(output);
        }
        [WebMethod]
        public static string GetForm()
        {
            wchEntities entity = new wchEntities();
            entity.Configuration.ProxyCreationEnabled = false;
            var p = entity.wch_Student.Select(s => new
            {
                s.StuID, s.StuName, s.Gender, s.wch_Class.ClassName, 
                s.wch_Department.DepName, s.StuAge, s.Tel, 
                s.Grade.Value.Year, s.Address
            });

            var json = new
            {
                code = 0,
                msg = "",
                count = p.Count(),
                data = p
            };
            return JsonConvert.SerializeObject(json);
        }

    }
}