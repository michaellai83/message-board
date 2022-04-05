using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPagetest01
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //驗證票券
            if (Page.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("admin_login.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}