using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPagetest01
{
    public partial class user_addmessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_main.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;
            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法                                                     參數化
            string sql = "INSERT INTO message (title, name, main, [check]) VALUES  (@title, @name, @main, @check)";
            //3.創建Command物件
            SqlCommand command = new SqlCommand(sql, sqlconnect);
            //4.打開資料庫
            sqlconnect.Open();
            //加入資料進資料庫
            command.Parameters.Add("@title", SqlDbType.NVarChar).Value = message_title.Text.ToString();
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = message_name.Text.ToString();
            command.Parameters.Add("@main", SqlDbType.NVarChar).Value = message_main.Text.ToString();
            command.Parameters.Add("@check", SqlDbType.NVarChar).Value = "False";
            //5.記得加
            command.ExecuteNonQuery();
            //6.關閉資料庫
            sqlconnect.Close();
            //JS跳出視窗
            Response.Write("<script>alert('留言成功');;location.href='user_main.aspx';</script>");

        }
    }
}