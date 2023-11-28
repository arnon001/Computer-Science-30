using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null || !(bool)Session["LoggedIn"]) {} else
            {
                Response.Write("<br><button id='toGame' onclick='location.href=`game.aspx`'>To Game!</button>");
            }
            if (Session["isAdmin"] == null || !(bool)Session["isAdmin"]) { } else
            {
                Response.Write("<br><button id='toAdmin' onclick='location.href=`admin.aspx`'>To Admin Page</button>");
            }


        }

        protected void login_Click(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null || !(bool)Session["LoggedIn"])
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Write("<script>alert('User Logged In transfering to game.')</script>");
                Response.Redirect("game.aspx");
            }
        }

        protected void register_Click(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null || !(bool)Session["LoggedIn"])
            {
                Response.Redirect("Register.aspx");
            }
            else
            {
                Response.Write("<script>alert('User Logged In transfering to game.')</script>");
                Response.Redirect("game.aspx");
            }
        }

        protected void dontTouch_Click(object sender, EventArgs e)
        {
            Response.Write("<video id='video' width='320' height='240' autoplay loop>" +
                "<source src='quack.mp4' type='video/mp4'>" +
                "Your browser does not support the video tag.</video>");
        }
    }
}