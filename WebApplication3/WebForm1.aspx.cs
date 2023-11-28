using System;
using MySql.Data.MySqlClient;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        MySqlConnection connect;
        string firstName;
        string lastName;
        string email;
        string password;

        protected void Page_Load(object sender, EventArgs e)
        {
            firstName = Request.Form["fName"];
            lastName = Request.Form["lName"];
            email = Request.Form["email"];
            password = Request.Form["password"];
            Response.Write(firstName + " , " + lastName + " , " + email);
            if (Open())
            {
                insertDB(firstName, lastName, email, password);
            }
        }

        static string host = "localhost";
        static string database = "cs";
        static string userDB = "cs";
        static string passwordDB = "arnon001";
        public static string strProvider = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + passwordDB;

        public bool Open()
        {
            try
            {
                connect = new MySqlConnection(strProvider);
                connect.Open();
                return true;
            }
            catch (Exception er)
            {
                Response.Write(er);
            }
            return false;
        }

        public void insertDB(string fName, string lName, string email, string password)
        {
            try
            {
                int affected;
                MySqlTransaction transaction = connect.BeginTransaction();
                MySqlCommand cmd = connect.CreateCommand();
                // Use parameterized query to prevent SQL injection
                cmd.CommandText = "INSERT INTO theProject (fName, lName, email, password, isAdmin) VALUES (@fName, @lName, @email, @password, false)";
                cmd.Parameters.AddWithValue("@fName", fName);
                cmd.Parameters.AddWithValue("@lName", lName);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                affected = cmd.ExecuteNonQuery();
                transaction.Commit();
                Session["LoggedIn"] = true;
                Response.Redirect("index.aspx");
            }
            catch (Exception err)
            {
                Response.Write("<br><br><br>" + err);
            }
        }
    }
}
