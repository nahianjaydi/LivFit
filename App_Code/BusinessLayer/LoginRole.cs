
using System;


public class LoginRole
{
    private String username;
    private String role;

    public LoginRole()
    {
        username = "";
        role = "";
    }

    public String Username
    {
        get { return username; }
        set { username = value; }
    }

    public String Role
    {
        get { return role; }
        set { role = value; }
    }
}
// End