using System;

public class Members
{
    private int memberId;
    private string lastName;
    private string firstName;
    private string gender;
    private string phone;
    private string email;
    private string userName;
    private string password;
    private string role;
    private ClassAttandents classMember;



    public Members()
    {
        memberId = -1;
        lastName = "";
        firstName = "";
        gender = "";
        email = "";
    }


    public int MemberId
    {
        get { return memberId; }
        set { memberId = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public string Role
    {
        get { return role; }
        set { role = value; }
    }

    public ClassAttandents ClassMember
    {
        get { return classMember; }
        set { classMember = value; }
    }
}