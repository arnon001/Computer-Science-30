using MySql.Data.MySqlClient;
using System;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;

namespace WebApplication3
{
    
    public partial class login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MySQLString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                string adminText = "SELECT COUNT(*) FROM theproject WHERE email = @email AND password = @password AND isAdmin = true";
                MySqlCommand adminTxt = new MySqlCommand(adminText, conn);

                string cmdText = "SELECT COUNT(*) FROM theproject WHERE email = @email AND password = @password";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);

                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                adminTxt.Parameters.AddWithValue("@email", txtEmail.Text);
                adminTxt.Parameters.AddWithValue("@Password", txtPassword.Text);

                conn.Open();
                int admin = Convert.ToInt32(adminTxt.ExecuteScalar());
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (admin > 0)
                    Session["IsAdmin"] = true;
                if (count>0)
                {
                    Session["LoggedIn"] = true;
                    Response.Redirect("Game.aspx");
                }
                else
                {
                    // Display error message for incorrect login details
                    lblMessage.Text = "Invalid username or password. Please try again.";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                conn.Close();
            }
        }
    
    }
}
