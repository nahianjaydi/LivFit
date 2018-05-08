using System;
using System.Collections.Generic;

using System.Data;
using Karis.DatabaseLibrary;


public class RegistrationDAO
{
    private Database myDatabase;
    private String myConnectionString;
	public RegistrationDAO()
	{
        myConnectionString = LivFitConnectionString.Text;
        myDatabase = new Database();
	}

    public int InsertMember(Registration members)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (memberRegistered(members.UserName) == true)
            {
                return 1;
            }

            String sqlText = String.Format(@"INSERT INTO Registration(uName, lastName, firstName, gender, phone, email, password) VALUES 
('"+members.UserName+"', '"+members.LastName+"', '"+members.FirstName+"','"+members.Gender+"','"+members.Phone+"', '"+members.Email+"','"+members.Password+"')");

            myDatabase.ExecuteUpdate(sqlText);

            return 0;  // OK
        }
        catch (Exception)
        {
            return -1; // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }

    public List<Registration> GetAllPenMembers()
    {
        List<Registration> memberList = new List<Registration>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(@"Select lastName, firstName, gender, uName FROM Registration ORDER BY firstName");

            resultSet = myDatabase.ExecuteQuery(sqlText);

            while (resultSet.Read() == true)
            {
                Registration members = new Registration();
                members.LastName = (String)resultSet["lastName"];
                members.FirstName = (String)resultSet["firstName"];
                members.Gender = (String)resultSet["gender"];
                members.UserName = (String)resultSet["uName"];

                memberList.Add(members);
            }

            resultSet.Close();
            return memberList;
        }

        catch (Exception)
        {
            return null;
        }

        finally
        {
            myDatabase.Close();
        }
    }

    public Registration GetMemberByUserName(string userName)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(@"Select lastName,firstName,gender,phone,email,uName,password 
                                                FROM Registration
                                                WHERE uName='" + userName+ "' ORDER BY firstName");

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                Registration members = new Registration();

                members.LastName = (String)resultSet["lastName"];
                members.FirstName = (String)resultSet["firstName"];
                members.Gender = (String)resultSet["gender"];
                members.Phone = (String)resultSet["phone"];
                members.Email = (String)resultSet["email"];
                members.UserName = (String)resultSet["uName"];
                members.Password = (String)resultSet["password"];

                resultSet.Close();
                return members;
            }

            else
            {
                return null;
            }
        }

        catch (Exception)
        {
            return null;
        }

        finally
        {
            myDatabase.Close();
        }
    }

    public int DeletePenMember(string userName)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"DELETE FROM Registration
                 WHERE uName = '{0}'", userName);

            myDatabase.ExecuteUpdate(sqlText);

            return 0;   // OK
        }
        catch (Exception)
        {
            return -1; // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }

    private bool memberRegistered(string userName)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT uName 
              FROM Registration 
             WHERE uName = '"+userName+"'");

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }

}