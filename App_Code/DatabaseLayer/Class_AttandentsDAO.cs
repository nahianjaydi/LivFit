using System;
using System.Collections.Generic;

using System.Data;
using Karis.DatabaseLibrary;


public class Class_AttandentsDAO
{
    private Database myDatabase;
    private String myConnectionString;
	public Class_AttandentsDAO()
	{
        myConnectionString = LivFitConnectionString.Text;
        myDatabase = new Database();
	}

    public int InserClassAttandetns(ClassAttandents classAttandents)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (memberAllreadyRegistered(classAttandents.MemberId, classAttandents.ClassId) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
              @"INSERT INTO Class_Attandents (memberId, classId, isCompleted)
                VALUES ({0}, {1}, '{2}')",
                classAttandents.MemberId,
                classAttandents.ClassId,
                classAttandents.IsCompleted);

            myDatabase.ExecuteUpdate(sqlText);

            return 0;
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

    private bool memberAllreadyRegistered(int memberId, int classId)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(@"Select memberId, classId FROM  Class_Attandents WHERE memberId='" + memberId + "' AND classId='" + classId + "'");

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }
}