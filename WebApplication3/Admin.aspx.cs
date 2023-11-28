using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI;

namespace WebApplication3
{
    public partial class Admin : System.Web.UI.Page
    {
        protected MySqlConnection myConnection;
        protected MySqlDataAdapter adapterKinds;
        protected MySqlDataAdapter adapterWords;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["isAdmin"] = null;
            Session["LoggedIn"] = null;
            Response.Redirect("index.aspx");
        }

        protected void showDbAsTable(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLString"].ConnectionString;
            myConnection = new MySqlConnection(connectionString);

            try
            {
                myConnection.Open();
                MySqlCommand myCommand = new MySqlCommand("SELECT * FROM theproject", myConnection);
                MySqlDataReader dataReader = myCommand.ExecuteReader();

                Response.Write("<table border='1' style='background-color:yellow;'>");
                Response.Write("<tr>");
                // Add other table headers here...

                while (dataReader.Read())
                {
                    Response.Write("<tr>");
                    for (int i = 0; i < 5; i++)
                    {
                        Response.Write("<td>");
                        Response.Write(dataReader[i].ToString());
                        Response.Write("</td>");
                    }
                    Response.Write("</tr>");
                }
                Response.Write("</table>");
            }
            catch (Exception ex)
            {
                Response.Write(ex + "<br><br><br><br>");
            }
            finally
            {
                myConnection.Close();
            }
        }

        protected void showDbAsText(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLString"].ConnectionString;
            myConnection = new MySqlConnection(connectionString);

            try
            {
                myConnection.Open();
                MySqlCommand myCommand = new MySqlCommand("SELECT * FROM theproject", myConnection);
                MySqlDataReader dataReader = myCommand.ExecuteReader();
                string allText = "";

                while (dataReader.Read())
                {
                    for (int i = 0; i < 5; i++)
                        allText += dataReader[i].ToString() + "  ";
                    allText += "<br/>";
                }
                Response.Write(allText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConnection.Close();
            }
        }

        protected void updateUserPermission(object sender, EventArgs e)
        {
            string username = hdnfldUserName.Value;
            bool doesUserNameExist = false;
            string userPermission = "";
            int permissionAfterChange = 0;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLString"].ConnectionString;
            doesUserNameExist = checkIfUserNameExists(username, connectionString);

            if (doesUserNameExist)
            {
                userPermission = getUserPermission(username, connectionString);

                if (userPermission == "0")
                {
                    permissionAfterChange = 1;
                }
                else
                {
                    permissionAfterChange = 0;
                }

                myConnection = new MySqlConnection(connectionString);

                MySqlCommand myCommand = new MySqlCommand("UPDATE theproject SET isAdmin=@Permission WHERE email=@Username", myConnection);
                myCommand.Parameters.AddWithValue("@Permission", permissionAfterChange);
                myCommand.Parameters.AddWithValue("@Username", username);

                try
                {
                    myConnection.Open();
                    int n = myCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write("WRONG!!!!");
                    Response.Write(ex.ToString());
                }
                finally
                {
                    myConnection.Close();
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('error-username is not in DB so can't change its permission')", true);
            }
        }

        protected bool checkIfUserNameExists(string username, string connectionString)
        {
            myConnection = new MySqlConnection(connectionString);

            try
            {
                MySqlCommand myCommand = new MySqlCommand("SELECT COUNT(*) FROM theproject WHERE email=@Username", myConnection);
                myCommand.Parameters.AddWithValue("@Username", username);

                myConnection.Open();
                int result = Convert.ToInt32(myCommand.ExecuteScalar());

                if (result > 0)
                {
                    Response.Write("USER EXISTS!!!!");
                    return true;
                }
                else
                {
                    Response.Write("USER does not EXISTS!!!!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConnection.Close();
            }
        }
        
        protected string getUserPermission(string username, string connectionString)
        {
            string permission = "";
            myConnection = new MySqlConnection(connectionString);

            MySqlCommand myCommand = new MySqlCommand("SELECT isAdmin FROM theproject WHERE email=@Username", myConnection);
            myCommand.Parameters.AddWithValue("@Username", username);

            myConnection.Open();

            try
            {
                MySqlDataReader dataReader = myCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    permission = dataReader[0].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("WRONG!!!!");
                Response.Write(ex.ToString());
            }
            finally
            {
                myConnection.Close();
            }
            return permission;
        }
    }
}
