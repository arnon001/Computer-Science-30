using System;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class game : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null || !(bool)Session["LoggedIn"])
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Write(" <script src='game.js'></script>    <link type='text/css' rel='stylesheet' href='style.css'>");
                Response.Write("<script>GAMEboard();</script>");
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["LoggedIn"] = null;
            Session["isAdmin"] = null;
            Response.Redirect("index.aspx");
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }
    }
}