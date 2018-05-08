using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClassesPage : System.Web.UI.Page
{
    private ClassDAO classDAO = new ClassDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();

        if (this.IsPostBack == false)
        {
            classViewStateNew();
            createClassList();
        }
    }

    private void showErrorMessageClass(String message)
    {
        LbClassReg.Text = message;
        LbClassReg.ForeColor = System.Drawing.Color.Red;
    }
    private void showNoMessageClass()
    {
        LbClassReg.Text = "";
        LbClassReg.ForeColor = System.Drawing.Color.Black;
    }
    private void createClassList()
    {
        List<Classes> classList = classDAO.GetAllClassOrderedByName();

        ListBoxMyAccount.Items.Clear();
        if (classList == null)
        {
            showErrorMessageClass("DATABASE TEMPORARILY OUT OF USE!");
        }
        else
        {
            foreach (Classes classes in classList)
            {
                String text = classes.ClassName;

                ListItem listItem = new ListItem(text, "" + classes.ClassId);
                ListBoxMyAccount.Items.Add(listItem);
            }
        }
    }

    protected void ListBoxMyAccount_SelectedIndexChanged(object sender, EventArgs e)
    {
        int classId = Convert.ToInt32(ListBoxMyAccount.SelectedValue);

        Classes classes = classDAO.GetClassByClassId(classId);

        if (classes != null)
        {
            ClassesModelToScreen(classes);
            showNoMessageClass();
        }
    }
    private void classViewStateNew()
    {
        tbClassId.Enabled = true;

        resetFormClasses();
        ListBoxMyAccount.SelectedIndex = -1;
        showNoMessageClass();
    }

    private void ClassesModelToScreen(Classes classes)
    {
        tbClassId.Text = "" + classes.ClassId;
        tbClassName.Text = classes.ClassName;
        tbWeeklyClasses.Text = "" + classes.WeeklyClasses;
        tbStartDate.Text = "" + classes.StartDate;
        tbEndDate.Text = "" + classes.EndDate;
    }
    private Classes screenToModelClasses()
    {
        Classes classes = new Classes();

        classes.ClassId = Convert.ToInt32(tbClassId.Text.Trim());
        classes.ClassName = tbClassName.Text;
        classes.WeeklyClasses = Convert.ToInt32(tbWeeklyClasses.Text.Trim());
        classes.StartDate = Convert.ToDateTime(tbStartDate.Text.Trim());
        classes.EndDate = Convert.ToDateTime(tbEndDate.Text.Trim());

        return classes;
    }
    private void resetFormClasses()
    {
        tbClassId.Text = "";
        tbClassName.Text = "";
        tbWeeklyClasses.Text = "";
        tbStartDate.Text = "";
        tbEndDate.Text = "";
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