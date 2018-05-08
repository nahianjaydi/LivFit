using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
    }



    /* **********************************************************************
    * LOGIN MANAGEMENT CODE 
    * - This is the special code for the HOME PAGE only! 
    * - DO NOT change anything else but the HyperLink controls here!
    *********************************************************************** */
    private void checkLogin()
    {
        Response.Cache.SetNoStore();   // Should disable browser's Back Button

        // (1) Hide all hyperlinks that are available for autenthicated users only
        hyperLink_myAccount.Visible = false;
        hyperLink_Manage.Visible = false;
        btLogout.Visible = false;

        if (Session["username"] == null)
        {
            btLogout.Visible = false;

            // LOGIN PAGE only: Enable the login panel
        }

        if (Session["username"] != null)
        {
            lbLoginInfo.Text = "Welcome " + Session["username"] + "!";
            btLogout.Visible = true;

            // LOGIN PAGE only: Disable the login panel

            // (2) Show all hyperlinks that are available for autenthicated users only
            hyperLink_myAccount.Visible = true;
            hyperLink_SignIn.Visible = false;
            hyperLink_RegistrationPage.Visible = false;
        }

        if (Session["administrator"] != null)
        {
            lbLoginInfo.Text = "Welcome " + Session["administrator"] + "!";
            btLogout.Visible = true;
            // (3) In addition, show all hyperlinks that are available for administrators only
            hyperLink_myAccount.Visible = true;
            hyperLink_Manage.Visible = true;
            hyperLink_SignIn.Visible = false;
            hyperLink_RegistrationPage.Visible = false;
        }
    }

    /// <summary>
    /// btLogin_Click: DO LOGOUT
    /// </summary>

    protected void btLogout_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["administrator"] = null;
        Page.Response.Redirect("Default.aspx");
    }
    /* LOGIN MANAGEMENT code ends here  */
}