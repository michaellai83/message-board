using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPagetest01
{
    public partial class Admin_main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            string[] level = strUserData.Split(',');

            if (!IsPostBack)
            {
                if(level[1].ToString().Equals("High"))
                {
                    showtable();
                    loadList();
                }
                else
                {
                    Response.Redirect("admin_login.aspx");
                }
                //string user = "michael";
                //string password = "1234";
                //showtable();
                //if (Session["user"] == null  || Session["password"] == null  )
                //if ((Session["user"] == null || string.IsNullOrWhiteSpace(Session["user"].ToString())) && (Session["password"] == null || string.IsNullOrWhiteSpace(Session["password"].ToString())) )
                //{
                //    //Response.Write("請登入帳號密碼");
                //    //Response.Redirect("admin_login.aspx");
                //    Response.Write("<script>alert('請登入帳號密碼');;location.href='admin_login.aspx';</script>");
                //}
                //else if (Session["user"].ToString() == user && Session["password"].ToString() == password)
                //{
                //    showtable();
                //}
                
                //loadList();
                

            }

        }

        private void loadList()
        {
            ////預設為第1頁
            //int page = 1;
            ////判斷網址後有無參數
            ////也可以用String.IsNullorWhiteSpace
            //if (!String.IsNullOrEmpty(Request.QueryString["page"]))
            //{
            //    page = Convert.ToInt32(Request.QueryString["page"]);
            //}
            ////設定頁面參數屬性
            ////設定控制項參數: 一頁幾筆資料
            //GVpage01.limit = 5;
            ////設定控制項參數: 作用頁面完整網頁名稱
            //GVpage01.targetPage = "Admin_main.aspx";

            ////建立計算分頁資料顯示邏輯(每一頁是從第幾筆開始到第幾筆結束)
            ////計算每個分頁的第幾筆到第幾筆
            //var floor = (page - 1) * GVpage01.limit + 1; //每頁的第一筆
            //var ceiling = page * GVpage01.limit; //每頁的最末比筆
            ////將取得的資料數設定給參數count
            //int count = 36; //總資料數 可修改數字測試分頁功能是否正常
            ////設定控制項參數: 總共幾筆資料
            //GVpage01.totalItems = count;
            ////渲染分頁控制項
            //GVpage01.ShowPageControls();
            ////設定模擬資料內容
            //StringBuilder listHtml = new StringBuilder();
            //for(int i = floor;i <= ceiling; i++)
            //{
            //    if(i <= count)
            //    {
            //        listHtml.Append($"<a href=''> ----------第{i}筆資料-------------</a></li><br /><br />");
            //    }
            //}

            //Literal1.Text = listHtml.ToString();

            //預設為第1頁
            int page = 1;
            //判斷網址後有無參數
            //也可以用String.IsNullorWhiteSpace
            if (!String.IsNullOrEmpty(Request.QueryString["page"]))
            {
                page = Convert.ToInt32(Request.QueryString["page"]);
            }
            //設定控制項參數: 一頁幾筆資料
            GVpage01.limit = 5;
            //設定控制項參數: 作用頁面完整網頁名稱
            GVpage01.targetPage = "Admin_main.aspx";
            //建立計算分頁資料顯示邏輯(每一頁是從第幾筆開始到第幾筆結束)
            //計算每個分頁的第幾筆到第幾筆
            var floor = (page - 1) * GVpage01.limit + 1; //每頁的第一筆
            var ceiling = page * GVpage01.limit; //每頁的最末比筆
            //將取得的資料數設定給參數count
            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;

            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法
            //string sql = "SELECT message.*FROM message ";
            string sql = "SELECT count(*) FROM [message]";
            //string sql = $"SELECT* ,(select count(*) from[r_message] where messageID =[message].id)as 回應 FROM[message];with cte as (select ROW_NUMBER() OVER(ORDER BY id ASC) as ROW_ID ,*from message )\r\n\r\nselect* from cte where ROW_ID >= { (page - 1) * 16 + 1} and ROW_ID <= { page * 16}";
            //3.創建Command物件
            SqlCommand command = new SqlCommand(sql, sqlconnect);

            //設定控制項參數: 總共幾筆資料
            sqlconnect.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            sqlconnect.Close();

            GVpage01.totalItems = count;
            //渲染分頁控制項
            GVpage01.ShowPageControls();
            //SQL 語法 讓分頁可以跟畫面連動 CTE寫法  建立兩個CTE 在 inner join
            string pagecontro = $"WITH tempA AS(SELECT ROW_NUMBER() OVER(ORDER BY initdate DESC) AS rowindex, *FROM message),tempB as (SELECT*, (select count(*) from[r_message] where messageID =[message].id)as 回應 FROM[message])SELECT tempA.rowindex, tempA.id, tempA.name, tempA.title, tempA.main, tempA.initdate, tempA.[check],回應 FROM tempA inner join tempB on tempA.id = tempB.id  WHERE rowindex >={ floor} AND rowindex <= {ceiling}";
            SqlCommand pagecommand = new SqlCommand(pagecontro, sqlconnect);
            SqlDataAdapter pageadapter = new SqlDataAdapter(pagecommand);
            DataTable table = new DataTable();
            pageadapter.Fill(table);
            GridView1.DataSource = table;
            GridView1.DataBind();
        }


        private void showtable()
        {
            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;

            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法
            //string sql = "SELECT message.*FROM message ";
            string sql = "SELECT* ,(select count(*) from[r_message] where messageID =[message].id)as 回應 FROM[message]";
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

            //這邊 刪除 會有 PK 和FK的問題  所以要先刪除 FK 的內容                              再刪除 PK 的內容
            SqlCommand command = new SqlCommand($"DELETE FROM r_message WHERE (messageID = {id});DELETE FROM message WHERE (id = {id})", connect);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
            string url = Request.Url.ToString();
            Response.Redirect(url);
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {


            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;
            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法                                                     參數化
            string sql = $"UPDATE  message SET [check] = @check ";
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }

        public void bind()
        {
            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;
            //string sqlstr = "SELECT * FROM message";
            string sqlstr = "SELECT* ,(select count(*) from[r_message] where messageID =[message].id)as 回應 FROM[message]";
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


        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {

                //取得要值的陣列
                GridViewRow row = (GridViewRow)e.Row;
                //取的要改的工具是什麼 這邊是LABEL 
                Label lab = (Label)row.FindControl("Label2") as Label;

                //查詢Label2得到的文字
                if(lab.Text == "True")
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = (GridViewRow)e.Row;
                //RadioButtonList rrl1 = (RadioButtonList)row.FindControl("RadioButtomList1");
                string str = "... (詳情點開)";
                HyperLink hyl = (HyperLink)row.FindControl("HyperLink2") as HyperLink;
                //if (row.Cells[3].Text.Length > 15)
                //{

                //    string str2 = row.Cells[3].Text.Substring(0, 15);
                //    row.Cells[3].Text = str2 + str;
                //}
                if (hyl.Text.Length > 15)
                {

                    string str2 = hyl.Text.Substring(0, 15);
                    hyl.Text = str2 + str;
                }
            }

        }

        
    }
}