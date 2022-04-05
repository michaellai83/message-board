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
    public partial class admin_maincheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];

            if (!IsPostBack)
            {
                showmain();
               
            }

        }

        
        private void showmain()
        {
            string id = Request.QueryString["ID"];

            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;

            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法
            string sql = $"SELECT *FROM message WHERE (id ={id})";
            //3.創建Command物件
            SqlCommand command = new SqlCommand(sql, sqlconnect);

            sqlconnect.Open();
            //使用dateReader讀資料
            SqlDataReader dataReader = command.ExecuteReader();
            //讀完 會跳出while  把資料存進去label
            while (dataReader.Read())
            {
                Lbl_title.Text += dataReader["title"].ToString();
                Lbl_name.Text += dataReader["name"].ToString();
                Lbl_time.Text += dataReader["initdate"].ToString();
                Lbl_main.Text += dataReader["main"].ToString();
            }
            sqlconnect.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];
            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;
            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法                                                     參數化
            string sql = $"UPDATE  message SET [check] = @check WHERE (id = {id})";

            //3.創建Command物件
            SqlCommand command = new SqlCommand(sql, sqlconnect);
            //4.打開資料庫
            sqlconnect.Open();
            //加入資料進資料庫
            command.Parameters.Add("@check", SqlDbType.NVarChar).Value = "True";

            //5.記得加
            command.ExecuteNonQuery();
            //6.關閉資料庫
            sqlconnect.Close();
            Response.Write("<script>alert('審核成功');;location.href='Admin_main.aspx';</script>");
        }
    }
}