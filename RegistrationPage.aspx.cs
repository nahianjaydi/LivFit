using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegistrationPage : System.Web.UI.Page
{
    private RegistrationDAO registationDAO = new RegistrationDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();

        if (this.IsPostBack == false)
        {
            resetRegForm();
        }
    }

    private void showErrorMessageMember(String message)
    {
        lbRegSubmitMsg.Text = message;
        lbRegSubmitMsg.ForeColor = System.Drawing.Color.Red;
    }

    private void showNoMessageMember(String message)
    {
        lbRegSubmitMsg.Text = "";
        lbRegSubmitMsg.ForeColor = System.Drawing.Color.Green;
    }

    protected void btRegSubmit_Click(object sender, EventArgs e)
    {
        Registration member = screenToModelMember();
        int insertOk = registationDAO.InsertMember(member);

        if (insertOk == 0) //Insert succeded
        {
            resetRegForm();
            showErrorMessageMember("Registration request sent!!");
        }
        else if (insertOk == 1)
        {
            showErrorMessageMember("Class id " + member.UserName +
              " is already in use. No record inserted into the database.");
            tbFirstName.Focus();
        }
        else
        {
            showErrorMessageMember("No record inserted into the database. " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    private void GetRadioButtonGenderValue(Registration member)
    {
        if (rbFemale.Checked == true)
        {
            member.Gender = "F";
        }

        else
        {
            member.Gender = "M";
        }
    }

    private Registration screenToModelMember()
    {
        Registration member = new Registration();

        member.LastName = tbLastName.Text.Trim();
        member.FirstName = tbFirstName.Text.Trim();
        GetRadioButtonGenderValue(member);
        member.Phone = tbPhone.Text.Trim();
        member.Email = tbEmail.Text.Trim();
        member.UserName = tbUname.Text.Trim();
        member.Password = tbPass.Text.Trim();
        return member;
    }

    private void resetRegForm()
    {
        tbFirstName.Focus();
        tbFirstName.Text = "";
        tbLastName.Text = "";
        tbPhone.Text = "";
        tbEmail.Text = "";
        tbPass.Text = "";
        tbRePass.Text = "";
        tbUname.Text = "";
        rbFemale.Checked = true;

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
            lbLoginInfo.Text = "Welcome " + Session["username"]+"!";
            btLogout.Visible = true;

            // LOGIN PAGE only: Disable the login panel

            // (2) Show all hyperlinks that are available for autenthicated users only
            hyperLink_myAccount.Visible = true;
            hyperLink_SignIn.Visible = false;
            hyperLink_RegistrationPage.Visible = false;
        }

        if (Session["administrator"] != null)
        {
            lbLoginInfo.Text = "Welcome " + Session["administrator"]+"!";
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