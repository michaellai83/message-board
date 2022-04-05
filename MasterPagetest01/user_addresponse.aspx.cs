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
    public partial class user_addresponse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rmessage_title.Text = gettitle();
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_main.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];


            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;
            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法                                                     參數化
            string sql = "INSERT INTO r_message(title, name, main, messageid, [check]) VALUES (@title,@name,@main,@messageid,@check)";
            //3.創建Command物件
            SqlCommand command = new SqlCommand(sql, sqlconnect);
            //4.打開資料庫
            sqlconnect.Open();
            //加入資料進資料庫
            command.Parameters.Add("@title", SqlDbType.NVarChar).Value = rmessage_title.Text.ToString();
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = rmessage_name.Text.ToString();
            command.Parameters.Add("@main", SqlDbType.NVarChar).Value = rmessage_main.Text.ToString();
            command.Parameters.Add("@messageid", SqlDbType.NVarChar).Value = id;
            command.Parameters.Add("@check", SqlDbType.NVarChar).Value = "False";
            //5.記得加
            command.ExecuteNonQuery();
            //6.關閉資料庫
            sqlconnect.Close();
            Response.Write($"<script>alert('回應成功');;location.href='user_response.aspx?ID={id}';</script>");
        }

        private string gettitle()
        {
            string id = Request.QueryString["ID"];
            string title = "R";
            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;

            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法
            string sql = $"SELECT message.*FROM message WHERE (id ={id})";
            //3.創建Command物件
            SqlCommand command = new SqlCommand(sql, sqlconnect);

            sqlconnect.Open();
            //使用dateReader讀資料
            SqlDataReader dataReader = command.ExecuteReader();
            //讀完 會跳出while  把資料存進去label
            while (dataReader.Read())
            {
                title += dataReader["title"].ToString();
            }
            sqlconnect.Close();

            return title;
        }
    }
}