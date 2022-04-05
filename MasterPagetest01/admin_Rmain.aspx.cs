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
    public partial class admin_Rmain : System.Web.UI.Page
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
            string id = Request.QueryString["ID"].ToString();
            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法
            string sql = $"SELECT *FROM r_message WHERE( messageid = {id}) ";
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


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //取得點擊這列的id
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();


            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;

            //連接 Sql連線 
            SqlConnection connect = new SqlConnection(SqlName);

            //這邊 刪除 會有 PK 和FK的問題  所以要先刪除 FK 的內容                             
            SqlCommand command = new SqlCommand($"DELETE FROM r_message WHERE (messageID = {id})", connect);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
            string url = Request.Url.ToString();
            Response.Redirect(url);
        }
        //protected void Button1_Click1(object sender, EventArgs e)
        //{


        //    string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;
        //    //連接 Sql連線 
        //    SqlConnection sqlconnect = new SqlConnection(SqlName);
        //    //2.SQL語法                                                     參數化
        //    string sql = $"UPDATE  r_message SET [check] = @check ";
        //    //3.創建Command物件
        //    SqlCommand command = new SqlCommand(sql, sqlconnect);
        //    //4.打開資料庫
        //    sqlconnect.Open();
        //    //加入資料進資料庫
        //    command.Parameters.Add("@check", SqlDbType.NVarChar).Value = "True";

        //    //5.記得加
        //    command.ExecuteNonQuery();
        //    //6.關閉資料庫
        //    sqlconnect.Close();
        //}

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }

        public void bind()
        {
            string id = Request.QueryString["ID"].ToString();
            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;
            //string sqlstr = "SELECT * FROM message";
            string sqlstr = $"SELECT* FROM[r_message] WHERE messageid = {id}";
            SqlConnection sqlcon = new SqlConnection(SqlName);
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, sqlcon);
            DataSet myds = new DataSet();
            sqlcon.Open();
            myda.Fill(myds);
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "id" }; //主鍵
            GridView1.DataBind();
            sqlcon.Close();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;
            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法                                                     參數化
            string sql = $"UPDATE  r_message SET [check] = @check WHERE (id = {id})";

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


        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //取得要值的陣列
                GridViewRow row = (GridViewRow)e.Row;
                //取的要改的工具是什麼 這邊是LABEL 
                Label lab = (Label)row.FindControl("Label1") as Label;

                //查詢Label1得到的文字
                if (lab.Text == "True")
                {
                    //更改文字
                    lab.Text = "OK";
                    lab.CssClass = "btn btn-success btn-circle btn-sm";
                }
                else
                {
                    lab.Text = "未審核";
                }
            }
        }
    }
}