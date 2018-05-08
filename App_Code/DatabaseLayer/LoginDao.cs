
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using Karis.DatabaseLibrary;

public class LoginDAO
{
    private Database myDatabase;
    private String myConnectionString;

    public LoginDAO()
    {
        myConnectionString = LivFitConnectionString.Text;
        myDatabase = new Database();
    }

    public LoginRole GetLoginRole(string username, string password)
    {
        LoginRole loginRole = new LoginRole();
        IDataReader resultSet;
        loginRole.Role = string.Empty;
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(@"Select role FROM Members Where username='" + username + "' AND password='" + password + "'");

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                loginRole.Role = (String)resultSet["role"];


                return loginRole;
            }

            else
            {
                return loginRole;
            }
        }

        catch (Exception)
        {
            return loginRole;
        }

        finally
        {
            myDatabase.Close();
        }

        // ----------------------------------------------------------
        // TO DO: The login role must be retrieved from the database
        //
        // The below is here for testing purposes ONLY.
        // ----------------------------------------------------------
        /*loginRole.Role = null;

        if (username == "user" && password == "user")
        {
            loginRole.Role = "user";
        }
        
        if (username == "admin" && password == "admin")
        {
            loginRole.Role = "administrator";
        }*/

    }
}