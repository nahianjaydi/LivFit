using System;


public class ClassAttandents
{
    private int classId;
    private int memberId;
    private string isCompleted;

    public ClassAttandents()
    {
        classId = -1;
        memberId = -1;
        isCompleted = "";
    }

    public int ClassId
    {
        get { return classId; }
        set { classId = value; }
    }

    public int MemberId
    {
        get { return memberId; }
        set { memberId = value; }
    }

    public string IsCompleted
    {
        get { return isCompleted; }
        set { isCompleted = value; }
    }

}