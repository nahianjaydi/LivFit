using System;
using System.Collections.Generic;

using System.Data;
using Karis.DatabaseLibrary;


public class MembersDAO
{
	private Database myDatabase;
    private String myConnectionString;
	public MembersDAO()
	{
        myConnectionString = LivFitConnectionString.Text;
        myDatabase = new Database();
	}

    public List<Members> GetAllMembers()
    {
        List<Members> memberList = new List<Members>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(@"Select memberId, lastName, firstName FROM Members ORDER BY memberId");

            resultSet = myDatabase.ExecuteQuery(sqlText);

            while (resultSet.Read() == true)
            {
                Members members = new Members();
                members.MemberId = (int)resultSet["memberId"];
                members.LastName = (String)resultSet["lastName"];
                members.FirstName = (String)resultSet["firstName"];

                memberList.Add(members);
            }

            resultSet.Close();
            return memberList;
        }

        catch(Exception)
        {
            return null;
        }

        finally
        {
            myDatabase.Close();
        }
    }


    public Members GetMemberByMemberId(int memberId)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(@"Select memberId, lastName,firstName,gender,phone,email,username,password,role 
                                                FROM Members
                                                WHERE memberId='"+memberId+"' ORDER BY memberId");

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                Members members = new Members();

                members.MemberId = (int)resultSet["memberId"];
                members.LastName = (String)resultSet["lastName"];
                members.FirstName = (String)resultSet["firstName"];
                members.Gender = (String)resultSet["gender"];
                members.Phone = (String)resultSet["phone"];
                members.Email = (String)resultSet["email"];
                members.UserName = (String)resultSet["username"];
                members.Password = (String)resultSet["password"];
                members.Role = (String)resultSet["role"];

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

    public Members GetMemberByUserName(string userName)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(@"Select memberId, lastName,firstName,gender,phone,email,username,password,role 
                                                FROM Members
                                                WHERE username='" + userName + "' ORDER BY memberId");

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                Members members = new Members();

                members.MemberId = (int)resultSet["memberId"];
                members.LastName = (String)resultSet["lastName"];
                members.FirstName = (String)resultSet["firstName"];
                members.Gender = (String)resultSet["gender"];
                members.Phone = (String)resultSet["phone"];
                members.Email = (String)resultSet["email"];
                members.UserName = (String)resultSet["username"];
                members.Password = (String)resultSet["password"];
                members.Role = (String)resultSet["role"];

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

    public int GetMemberIdByUserName(string userName)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(@"Select memberId 
                                                FROM Members
                                                WHERE username='" + userName + "' ORDER BY memberId");

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {

                int memberId = (int)resultSet["memberId"];

                resultSet.Close();
                return memberId;
            }

            else
            {
                return 1;
            }
        }

        catch (Exception)
        {
            return -1;
        }

        finally
        {
            myDatabase.Close();
        }
    }


    public int DeleteMember(int memberId)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (MemberExistsForClassAttandence(memberId) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
              @"DELETE FROM Members
                 WHERE memberId = {0}", memberId);

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


    public int InsertMember(Members members)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (memberExists(members.MemberId) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
              @"INSERT INTO Members (memberId,lastName,firstName,gender,phone,email,username,password,role)
                VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')",
                members.MemberId,
                members.LastName,
                members.FirstName,
                members.Gender,
                members.Phone,
                members.Email,
                members.UserName,
                members.Password,
                members.Role);

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

    //riderId,familyName,givenName,gender,phone,email,username,password,role
    public int UpdateMember(Members member)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"UPDATE Members
                SET lastName  = '{0}', 
                    firstName   = '{1}',
                    gender      = '{2}',
                    phone       = '{3}',
                    email       = '{4}',
                    username    = '{5}',
                    password    = '{6}',
                    role        = '{7}'
                WHERE memberId   =  {8}",
                member.LastName,
                member.FirstName,
                member.Gender,
                member.Phone,
                member.Email,
                member.UserName,
                member.Password,
                member.Role,
                member.MemberId);

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

    public int GetMemberIdByUsername(string userName)
    {
        IDataReader resultSet;
        int memberId;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(@"Select memberId FROM Members WHERE username='" + userName + "'");

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                memberId = (int)resultSet["memberId"];

                resultSet.Close();
                return memberId;
            }

            else
            {
                return -1;
            }
        }

        catch (Exception)
        {
            return -1;
        }

        finally
        {
            myDatabase.Close();
        }


    }
    private bool memberExists(int memberId)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT memberId 
              FROM Members 
             WHERE memberId = {0}", memberId);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }

    private bool MemberExistsForClassAttandence(int memberId)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT memberId
              FROM Class_Attandents
             WHERE memberId = {0}", memberId);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }
}