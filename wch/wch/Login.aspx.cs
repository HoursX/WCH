using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace wch
{
    public partial class Login : System.Web.UI.Page
    {
        public int Identity { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_pwd.Text) || string.IsNullOrEmpty(tb_pwd.Text))
            {
                JsOutput("请输入工号或密码");
                return;
            }
            string user = tb_user.Text;
            string psw = wch.lib.DBHelper.GenerateMD5(tb_pwd.Text.Trim());
            //string output = "<script>alert('{0}')</script>";
            //output = string.Format(output, user, psw);
            //Response.Write(output);
            int test = wch.lib.DBHelper.ConnectionTest();
            if (test == -1)
            {
                JsOutput("数据库连接出错");
                return;
            }
            if (TryLogin(user, psw))
            {
                JsOutput("登录成功,标识符" + Identity);
                Session["Identity"] = Identity;
                Session["user"] = user;
                Session.Timeout = 720;
                if (chk_login.Checked)
                {
                    Response.Cookies["user"].Value = user.ToString();
                    Response.Cookies["user"].Expires = DateTime.Now.AddDays(7);
                    Response.Cookies["Identity"].Value = Identity.ToString();
                    Response.Cookies["Identity"].Expires = DateTime.Now.AddDays(7);
                }
                else
                {
                    Response.Cookies["user"].Value = user.ToString();
                    Response.Cookies["user"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["Identity"].Value = Identity.ToString();
                    Response.Cookies["Identity"].Expires = DateTime.Now.AddDays(1);
                }

                switch (Identity)
                {
                    case 1:
                        Response.Redirect("~/admin.aspx");
                        break;
                    case 2:
                        Response.Redirect("~/Teacher.aspx");
                        break;
                    case 3:
                        Response.Redirect("~/Student.aspx");
                        break;
                }
                return;


            }
            else 
            {
                JsOutput("用户名或密码错误");
            }
            
        }
        public void JsOutput(string info)
        {
            string output = "<script>alert('{0}')</script>";
            output = string.Format(output, info);
            Response.Write(output);
        }
        public bool TryLogin(string user, string psw)
        {
            string sql = "SELECT [wch_Login].[Identity] FROM wch_Login WHERE UserID  = @UserID AND Passwd = @Passwd";
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                wch.lib.DBHelper.CreatePara("@UserID",SqlDbType.NChar,ParameterDirection.Input, user),
                wch.lib.DBHelper.CreatePara("@Passwd",SqlDbType.NChar,ParameterDirection.Input, psw),
            };

            int identity;
            try
            {
                identity = (int)wch.lib.DBHelper.ExecuteScalar(sql, sqlParameters);

                if (identity != -1)
                {
                    Identity = identity;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                
            }

            return false;

            
        }



    }
}