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
    public partial class user_response : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];

            if (!IsPostBack)
            {
                showmain();
                showres();
            }

        }

        private void showres()
        {
            string id = Request.QueryString["ID"];
            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;

            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法
            //string sql = "SELECT message.*FROM message";
            string sql = $"SELECT* FROM r_message WHERE (messageID ={id}) AND ([check] = 1)";
            //3.創建Command物件
            SqlCommand command = new SqlCommand(sql, sqlconnect);
            //4.創建適配器(Adapter)離線技術 另一個是一直連線
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            //5.創建一張表         
            DataTable table = new DataTable();
            //6.數據填充表 已經自動開關資料庫完畢
            adapter.Fill(table);

            //來源是誰
            Repeater1.DataSource = table;
            //將資料與介面整合 與webform1裡面創建的表 讓他可以顯現
            Repeater1.DataBind();
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_main.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];
            Response.Redirect($"user_addresponse.aspx?ID={id}");
        }
    }
}