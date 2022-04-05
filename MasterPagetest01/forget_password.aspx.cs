using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPagetest01
{
    public partial class forget_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = exampleInputEmail.Text.ToString();
            string SqlName = WebConfigurationManager.ConnectionStrings["message03ConnectionString"].ConnectionString;

            //連接 Sql連線 
            SqlConnection sqlconnect = new SqlConnection(SqlName);
            //2.SQL語法
            string sql = "SELECT *FROM administrator";
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
                if (dataReader["userid"].ToString() == email )
                {
                    
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
                Response.Write("<script>alert('查無此帳號');;location.href='forget_password.aspx';</script>");
               ;
            }
            else if (i < 0)
            {
                Response.Write("<script>alert('已發送密碼到信箱');;location.href='admin_login.aspx';</script>");
            }
           
        }
    }
}