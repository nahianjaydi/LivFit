using System;
using System.Collections.Generic;

using System.Data;
using Karis.DatabaseLibrary;


public class ClassDAO
{
    private Database myDatabase;
    private String myConnectionString;
	public ClassDAO()
	{
        myConnectionString = LivFitConnectionString.Text;
        myDatabase = new Database();
	}

    /// <summary>
    /// Deletes a single Club row by ClubId from the database.
    /// </summary>
    /// <param name="classId"></param>
    /// <returns>0 = OK, 1 = delete not allowed, -1 = error</returns>
    public int DeleteClass(int classId)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (classExistsInClass_Attandents(classId) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
              @"DELETE FROM Classes
                 WHERE classId = {0}", classId);

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

    /// <summary>
    /// Retrieves all Club rows in alphabetical order by Club name from the database.
    /// </summary>
    /// <returns>A List of Club</returns>

    public List<Classes> GetAllClassOrderedByName()
    {
        List<Classes> classList = new List<Classes>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = 
              @"SELECT classId, className, weeklyClasses, startDate, endDate
                  FROM Classes 
              ORDER BY className";

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Classes classes = new Classes();

                classes.ClassId = (int)resultSet["classId"];
                classes.ClassName = (String)resultSet["className"];
                classes.WeeklyClasses=(int)resultSet["weeklyClasses"];
                classes.StartDate = (DateTime)resultSet["startDate"];
                classes.EndDate = (DateTime)resultSet["endDate"];

                classList.Add(classes);
            }

            resultSet.Close();

            return classList;
        }
        catch (Exception)
        {
            return null; // An error occured
        }
        finally
        {
            myDatabase.Close();
        }
    }

    /// <summary>
    /// Retrieves a single Department row by DepartmentId from the database.
    /// </summary>
    /// <param name="ClassId"></param>
    /// <returns>A single Department object</returns>
    public Classes GetClassByClassId(int classId)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"SELECT classId, className, weeklyClasses, startDate, endDate 
                  FROM Classes 
                 WHERE classId = {0}", classId);

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                Classes classes = new Classes();

                classes.ClassId = (int)resultSet["classId"];
                classes.ClassName = (String)resultSet["className"];
                classes.WeeklyClasses = (int)resultSet["weeklyClasses"];
                classes.StartDate = (DateTime)resultSet["startDate"];
                classes.EndDate = (DateTime)resultSet["endDate"];

                return classes;
            }
            else
            {
                return null; // Not found
            }
        }
        catch (Exception)
        {
            return null;  // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }

    /// <summary>
    /// Inserts a single Department row into the database.
    /// </summary>
    /// <param name="Class"></param>
    /// <returns>0 = OK, 1 = insert not allowed, -1 = error</returns>
    public int InsertClass(Classes classes)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (classExists(classes.ClassId) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
              @"INSERT INTO Classes (classId, className, weeklyClasses, startDate, endDate)
                VALUES ({0}, '{1}', '{2}', '{3}', '{4}')",
                classes.ClassId,
                classes.ClassName, 
                classes.WeeklyClasses,
                classes.StartDate,
                classes.EndDate);

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

    /// <summary>
    /// Updates an existing Department row in the database.
    /// </summary>
    /// <param name="Class"></param>
    /// <returns>0 = OK, -1 = error</returns>
    public int UpdateClass(Classes classes)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"UPDATE Classes
                SET className       = '{0}', 
                    weeklyClasses   = '{1}',
                    startDate       = '{2}',
                    endDate         = '{3}'
                WHERE classId       =  {4}",
                classes.ClassName,
                classes.WeeklyClasses,
                classes.StartDate,
                classes.EndDate,
                classes.ClassId);

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

    /// <summary>
    /// Checks if a Department row with the given Department id exists in the database.
    /// </summary>
    /// <param name="classId"></param>
    /// <returns>true = row exists, otherwise false</returns>
    private bool classExists(int classId)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT classId 
              FROM Classes 
             WHERE classId = {0}", classId);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }

    /// <summary>
    /// Checks if the Department row is being referenced by another row. 
    /// </summary>
    /// <param name="clubid"></param>
    /// <returns>true = a child row exists, otherwise false</returns>
    private bool classExistsInClass_Attandents(int classId)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT classId
              FROM Class_Attandents
             WHERE classId = {0}", classId);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }

   
}