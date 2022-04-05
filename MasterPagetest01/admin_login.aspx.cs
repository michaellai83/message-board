using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPagetest01
{
    public partial class admin_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string user = exampleInputEmail.Text.ToString();
            string password = exampleInputPassword.Text.ToString();

            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;

            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法
            string sql = "SELECT *FROM administrator ";
            //3.創建Command物件
            SqlCommand command = new SqlCommand(sql, sqlconnect);
            //4.創建適配器(Adapter)離線技術 另一個是一直連線
            sqlconnect.Open();
            //使用dateReader讀資料
            SqlDataReader dataReader = command.ExecuteReader();
            //讀完 會跳出while  把資料存進去label
            int i = 0;
            while (dataReader.Read())
            {
                if (dataReader["userid"].ToString() == user && dataReader["userpassword"].ToString() == password)
                {
                    //Session["user"] = user;
                    //Session["password"] = password;
                    string userData = dataReader["userid"].ToString() + "," + dataReader["Authority"].ToString();
                    SetAuthenTicket(userData, exampleInputEmail.Text.Trim());
                    i = -1;
                    break;
                }
                else
                {
                    i++;
                }
            }
            sqlconnect.Close();
            if (i > 0)
            {
                Response.Write("<script>alert('查無此帳號密碼');;location.href='admin_login.aspx';</script>");
                //Response.Write("查無此帳號密碼");
            }
            else if (i < 0)
            {
                Response.Redirect("Admin_main.aspx");
            }
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }

        void SetAuthenTicket(string userData, string userId)
        {
            //宣告一個驗證票
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                userId,
                //發行時間
                DateTime.Now,
                //有效期限
                //DateTime.Now.AddHours(3),
                DateTime.Now.AddMinutes(1),
                //是否將 Cookie 設定成 Session Cookie，如果是則會在瀏覽器關閉後移除
                false,
                userData);
            //加密驗證票
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            //把加密票存入，建立Cookie
            HttpCookie authenticationcookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            authenticationcookie.Expires = DateTime.Now.AddMonths(3);
            //將Cookie寫入回應
            Response.Cookies.Add(authenticationcookie);
        }
    }
}