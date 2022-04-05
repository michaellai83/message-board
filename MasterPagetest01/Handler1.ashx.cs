using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MasterPagetest01
{
    /// <summary>
    /// Handler1 的摘要描述
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            FormsAuthentication.SignOut();//把票券刪除
            context.Response.Redirect("admin_login.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}