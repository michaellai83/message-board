using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPagetest01
{
    public partial class admin_register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string EmailId = "";
            string password = exampleInputPassword.Text.ToString();
            if (Regex.IsMatch(exampleInputEmail.Text.ToString(), "[a-zA-Z0-9_]+@[a-zA-Z0-9._]+"))
            {
                EmailId = exampleInputEmail.Text.ToString();
            }
            else
            {
                Response.Write("<script>alert('e-mail錯誤');;location.href='admin_register.aspx';</script>");
            }
            if (exampleRepeatPassword.Text.ToString() != password)
            {
                Response.Write("<script>alert('重複輸入密碼與第一組密碼不同');;location.href='admin_register.aspx';</script>");
            }
            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;
            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法                                                     參數化
            string sql = "INSERT INTO administrator (userid, userpassword, lastname, firstname) VALUES  (@userid, @userpassword, @lastname, @firstname)";
            //3.創建Command物件
            SqlCommand command = new SqlCommand(sql, sqlconnect);
            //4.打開資料庫
            sqlconnect.Open();
            //加入資料進資料庫
            command.Parameters.Add("@userid", SqlDbType.NVarChar).Value = EmailId;
            command.Parameters.Add("@userpassword", SqlDbType.NVarChar).Value = password;
            command.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = exampleLastName.Text.ToString();
            command.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = exampleFirstName.Text.ToString();
            //5.記得加
            command.ExecuteNonQuery();
            //6.關閉資料庫
            sqlconnect.Close();
            Response.Write("<script>alert('註冊成功');;location.href='admin_login.aspx';</script>");
            //Response.Redirect("admin_login.aspx");
        }
    }
}