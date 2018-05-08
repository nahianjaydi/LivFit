using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class MyAccountPage : System.Web.UI.Page
{
    private MembersDAO memberDAO = new MembersDAO();
    private ClassDAO classDAO = new ClassDAO();
    private Class_AttandentsDAO classAttandentsDAO = new Class_AttandentsDAO();
    protected void Page_Load(object sender, EventArgs e)
    {

        checkLogin(true);

        if (this.IsPostBack == false)
        {
            classViewStateNew();
            createClassList();
            createMemberDetails();
        }
    }

    private void showErrorMessageMember(String message)
    {
        lbUpdateMsg.Text = message;
        lbUpdateMsg.ForeColor = System.Drawing.Color.Red;
    }

    private void showErrorMessageClass(String message)
    {
        LbClassReg.Text = message;
        LbClassReg.ForeColor = System.Drawing.Color.Red;
    }

    private void showNoMessageMember()
    {
        lbUpdateMsg.Text = "";
        lbUpdateMsg.ForeColor = System.Drawing.Color.Black;
    }

    private void showNoMessageClass()
    {
        LbClassReg.Text = "";
        LbClassReg.ForeColor = System.Drawing.Color.Black;
    }

    private void createMemberDetails()
    {
        string userName = "" + Session["username"];
        Members member = memberDAO.GetMemberByUserName(userName);

        if (member != null)
        {
            membersModelToScreen(member);
            showNoMessageMember();
        }
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

                ListItem listItem = new ListItem(text, ""+classes.ClassId);
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
                btClassRegister.Enabled = true;
            }


    }
    protected void btMyAccountUpdate_Click(object sender, EventArgs e)
    {

        Members members = screenToModelMember();
        int updateOk = memberDAO.UpdateMember(members);

        if (updateOk == 0) // Update succeeded
        {
            createMemberDetails();
            lbUpdateMsg.Text = "Update Succeeded!!";
        }
        else
        {
            showErrorMessageMember("No record updated. ");
        }
    }

    protected void btClassRegister_Click(object sender, EventArgs e)
    {
        ClassAttandents classAttandents = classAttandentsscreenToModel();
        int insertOk = classAttandentsDAO.InserClassAttandetns(classAttandents) ;

        if (insertOk == 0) //Insert succeded
        {
            classViewStateNew();
            LbClassReg.Text = "Registration Successfull!!";
        }
        else if (insertOk == 1)
        {
            showErrorMessageClass("You have already register for this Class. No record inserted into the database.");
        }
        else
        {
            showErrorMessageClass("THE DATABASE IS TEMPORARILY OUT OF USE!!");
        }
    }

    private void radioButtonGenderCheckMember(Members member)
    {
        if (member.Gender == "F")
        {
            rbFemale.Checked = true;
            rbMale.Checked = false;
        }

        else
        {
            rbMale.Checked = true;
            rbFemale.Checked = false;
        }
    }

    private void GetRadioButtonGenderValue(Members member)
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

    private ClassAttandents classAttandentsscreenToModel()
    {
        ClassAttandents classAttandents = new ClassAttandents();

        string userName = "" + Session["username"];
        int classId = Convert.ToInt32(ListBoxMyAccount.SelectedValue);

        classAttandents.MemberId = memberDAO.GetMemberIdByUsername(userName);
        classAttandents.ClassId = classId;
        classAttandents.IsCompleted = "N";

        return classAttandents;
    } 

    private void classViewStateNew()
    {
        tbClassId.Enabled = true;

        btClassRegister.Enabled = false;

        resetFormClasses();
        ListBoxMyAccount.SelectedIndex = -1;
        showNoMessageClass();
    }
    private void membersModelToScreen(Members member)
    {
        tbUserId.Text = "" + member.MemberId;
        tbUserId.Enabled = false;
        tbFirstName.Text = member.FirstName;
        tbLastName.Text = member.LastName;
        radioButtonGenderCheckMember(member);
        tbPhone.Text = member.Phone;
        tbEmail.Text = member.Email;
        tbUname.Text = member.UserName;
        tbPass.Text = member.Password;
    }

    private void ClassesModelToScreen(Classes classes)
    {
        tbClassId.Text = "" + classes.ClassId;
        tbClassName.Text = classes.ClassName;
        tbWeeklyClasses.Text = "" + classes.WeeklyClasses;
        tbStartDate.Text = "" + classes.StartDate;
        tbEndDate.Text = "" + classes.EndDate;
    }

    private Members screenToModelMember()
    {
        Members member = new Members();

        member.MemberId = Convert.ToInt32(tbUserId.Text.Trim());
        member.LastName = tbLastName.Text.Trim();
        member.FirstName = tbFirstName.Text.Trim();
        GetRadioButtonGenderValue(member);
        member.Phone = tbPhone.Text.Trim();
        member.Email = tbEmail.Text.Trim();
        member.UserName = tbUname.Text.Trim();
        member.Password = tbPass.Text.Trim();
        return member;
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
    private void resetFormMember()
    {
        tbUserId.Text = "";
        tbLastName.Text = "";
        tbFirstName.Text = "";
        rbFemale.Checked = true;
        tbPhone.Text = "";
        tbEmail.Text = "";
        tbUserId.Text = "";
        tbPass.Text = "";
        tbRePass.Text = "";
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
    private void checkLogin(bool loginRequired)
    {
        Response.Cache.SetNoStore();   // Should disable browser's Back Button

        // (1) Hide all hyperlinks that are available for autenthicated users only
        hyperLink_myAccount.Visible = false;
        hyperLink_Manage.Visible = false;
        btLogout.Visible = false;

        if (loginRequired == true && Session["username"] == null)
        {
            Page.Response.Redirect("HomePage.aspx");  // Jump to the login page.
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