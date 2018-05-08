using System;

public class Classes
{
    private int classId;
    private string className;
    private int weeklyClasses;
    private DateTime startDate;
    private DateTime endDate;


    public Classes()
    {
        classId = -1;
        className = "";
        weeklyClasses = -1;
    }

    public int ClassId
    {
        get { return classId; }
        set { classId = value; }
    }

    public string ClassName
    {
        get { return className; }
        set { className = value; }
    }

    public int WeeklyClasses
    {
        get { return weeklyClasses; }
        set { weeklyClasses = value; }
    }

    public DateTime StartDate
    {
        get { return startDate; }
        set { startDate = value; }
    }

    public DateTime EndDate
    {
        get { return endDate; }
        set { endDate = value; }
    }


}