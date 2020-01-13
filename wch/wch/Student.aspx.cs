using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wch
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"]== null || Session["Identity"].ToString() != "3")
            {
                Response.Redirect("login.aspx");
                return;
            }



        }
    }
}