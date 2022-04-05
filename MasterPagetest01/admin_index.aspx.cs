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
    public partial class admin_index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showtable();
            }
        }

        private void showtable()
        {
            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;

            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法
            string sql = "SELECT message.*FROM message WHERE [check] = 1";
            //string sql = "SELECT* ,(select count(*) from[r_message] where messageID =[message].id)as 回應 FROM[message]";
            //3.創建Command物件
            SqlCommand command = new SqlCommand(sql, sqlconnect);
            //4.創建適配器(Adapter)離線技術 另一個是一直連線
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            //5.創建一張表         
            DataTable table = new DataTable();
            //6.數據填充表 已經自動開關資料庫完畢
            adapter.Fill(table);

            //來源是誰
            GridView1.DataSource = table;
            //將資料與介面整合 與webform1裡面創建的表 讓他可以顯現
            GridView1.DataBind();
        }

        protected void admin_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_addmessage.aspx");
        }
    }
}