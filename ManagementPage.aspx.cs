using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagementPage : System.Web.UI.Page
{
    private MembersDAO memberDAO = new MembersDAO();
    private ClassDAO classDAO = new ClassDAO();
    private RegistrationDAO registationDAO = new RegistrationDAO();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin(true);

        if (this.IsPostBack == false)
        {
            classViewStateNew();
            MemberviewStateNew();
            createMemberList(); // Populate Department List for the first time
            createClassList();
            createPendMemberList();
        }

        addButtonScripts();
    }

    private void addButtonScripts()
    {
        btDelete.Attributes.Add("onclick",
          "return confirm('Are you sure you want to delete the data?');");
        btClassDelete.Attributes.Add("onclick",
            "return confirm('Are you sure you want to delete the data?');");
    }

    private void createMemberList()
    {
        List<Members> memberList = memberDAO.GetAllMembers();

        ListBoxRegMember.Items.Clear();
        if (memberList == null)
        {
            showErrorMessageMember("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        else
        {
            foreach (Members member in memberList)
            {
                String text = "Mider Id: " + member.MemberId + ", Name: " + member.FirstName + " " + member.LastName;

                ListItem listItem = new ListItem(text, "" + member.MemberId);
                ListBoxRegMember.Items.Add(listItem);
            }
        }
    }

    private void createClassList()
    {
        List<Classes> classList = classDAO.GetAllClassOrderedByName();

        ListBoxClasses.Items.Clear();
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
                ListBoxClasses.Items.Add(listItem);
            }
        }
    }

    private void createPendMemberList()
    {
        List<Registration> registrationList = registationDAO.GetAllPenMembers();

        ListBoxPendMember.Items.Clear();
        if (registrationList == null)
        {
            showErrorMessageMember("DATABASE TEMPORARILY OUT OF USE!");
        }

        else
        {
            foreach (Registration member in registrationList)
            {
                String text = "Name: " + member.FirstName + " " + member.LastName + ", " + member.Gender;
                ListItem listItem = new ListItem(text, "" + member.UserName);
                ListBoxPendMember.Items.Add(listItem);
            }
        }
    }

    private void showErrorMessageMember(String message)
    {
        LbRegMembers.Text = message;
        LbPenMember.Text = message;
        lbRegMemberForm.ForeColor = System.Drawing.Color.Green;
    }

    private void showErrorMessageClass(String message)
    {
        LbClassList.Text = message;
        LbClassReg.ForeColor = System.Drawing.Color.Green;
    }

    private void showNoMessageMember()
    {
        LbRegMembers.Text = "";
        LbPenMember.Text = "";
        lbRegMemberForm.ForeColor = System.Drawing.Color.Black;
    }

    private void showNoMessageClass()
    {
        LbClassReg.Text = "";
        LbClassReg.ForeColor = System.Drawing.Color.Black;
    }

    protected void ListBoxRegMember_SelectedIndexChanged(object sender, EventArgs e)
    {
        int memberId = Convert.ToInt32(ListBoxRegMember.SelectedValue);

        Members member = memberDAO.GetMemberByMemberId(memberId);

        if (member != null)
        {
            membersModelToScreen(member);
            memberViewStateDetailsDisplayed();
            showNoMessageMember();
        }
    }

    protected void ListBoxPendMember_SelectedIndexChanged(object sender, EventArgs e)
    {
        String uName = ListBoxPendMember.SelectedValue;
        Registration member = registationDAO.GetMemberByUserName(uName);

        if(member != null) 
        {
            resetFormMember();
            membersRegistrationModelToScreen(member);
            PenmemberViewStateDetailsDisplayed();
            showNoMessageMember();
        }

    }

    protected void ListBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
        int classId = Convert.ToInt32(ListBoxClasses.SelectedValue);

        Classes classes = classDAO.GetClassByClassId(classId);

        if (classes != null)
        {
            ClassesModelToScreen(classes);
            classViewStateDetailsDisplayed();
            showNoMessageClass();
        }
    }


    protected void btRemovePenRequest_Click(object sender, EventArgs e)
    {
        string userName = ListBoxPendMember.SelectedValue;
        int deleteOk = registationDAO.DeletePenMember(userName);

        if (deleteOk == 0) // Delete succeeded
        {
            createPendMemberList();
            MemberviewStateNew();
            showNoMessageMember();
        }
        else
        {
            showErrorMessageMember("No record deleted. " +
             "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }
    protected void btnew_Click(object sender, EventArgs e)
    {
        MemberviewStateNew();
    }
    protected void btAdd_Click(object sender, EventArgs e)
    {
        Members members = screenToModelMember();
        int insertOk = memberDAO.InsertMember(members);

        if (insertOk == 0) //Insert succeded
        {
            createMemberList();
            ListBoxRegMember.SelectedValue = members.MemberId.ToString();
            memberViewStateDetailsDisplayed();
            showNoMessageMember();
        }
        else if (insertOk == 1)
        {
            showErrorMessageMember("User id " + members.MemberId +
              " is already in use. No record inserted into the database.");
            tbUserId.Focus();
        }
        else
        {
            showErrorMessageMember("No record inserted into the database.");
        }
    }
    protected void btUpdate_Click(object sender, EventArgs e)
    {
        Members members = screenToModelMember();
        int updateOk = memberDAO.UpdateMember(members);

        if (updateOk == 0) // Update succeeded
        {
            String selectedValue = ListBoxRegMember.SelectedValue;

            createMemberList();
            ListBoxRegMember.SelectedValue = selectedValue;
            LbRegMembers.Text = "Update Succeeded!!";
        }
        else
        {
            showErrorMessageMember("No record updated. ");
        }
    }
    protected void btDelete_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(ListBoxRegMember.SelectedValue);
        int deleteOk = memberDAO.DeleteMember(userId);

        if (deleteOk == 0) // Delete succeeded
        {
            createMemberList();
            MemberviewStateNew();
            showNoMessageMember();
        }
        else if (deleteOk == 1)
        {
            showErrorMessageMember("No record deleted. " +
              "Please delete the Member's entry from the Class Attandence first.");
        }
        else
        {
            showErrorMessageMember("No record deleted. " +
             "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }


    protected void btClassNew_Click(object sender, EventArgs e)
    {
        classViewStateNew();
    }
    protected void btClassAdd_Click(object sender, EventArgs e)
    {
        Classes classes = screenToModelClasses();
        int insertOk = classDAO.InsertClass(classes);

        if (insertOk == 0) //Insert succeded
        {
            createClassList();
            ListBoxClasses.SelectedValue = classes.ClassId.ToString();
            classViewStateDetailsDisplayed();
            showNoMessageClass();
        }
        else if (insertOk == 1)
        {
            showErrorMessageClass("Class id " + classes.ClassId +
              " is already in use. No record inserted into the database.");
            tbClassId.Focus();
        }
        else
        {
            showErrorMessageClass("No record inserted into the database. " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }
    protected void btClassUpdate_Click(object sender, EventArgs e)
    {
        Classes classes = screenToModelClasses();
        int updateOk = classDAO.UpdateClass(classes);

        if (updateOk == 0) // Update succeeded
        {
            String selectedValue = ListBoxClasses.SelectedValue;

            createClassList();
            ListBoxClasses.SelectedValue = selectedValue;
            LbClassReg.Text = "Update Succeeded!!";
        }
        else
        {
            showErrorMessageClass("No record updated. " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }
    protected void btClassDelete_Click(object sender, EventArgs e)
    {
        int classId = Convert.ToInt32(ListBoxClasses.SelectedValue);
        int deleteOk = classDAO.DeleteClass(classId);

        if (deleteOk == 0) // Delete succeeded
        {
            createClassList();
            classViewStateNew();
            showNoMessageClass();
        }
        else if (deleteOk == 1)
        {
            showErrorMessageClass("No record deleted. " +
              "Please delete the Classe's entry from the Class Attandence first.");
        }
        else
        {
            showErrorMessageMember("No record deleted. " +
             "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    private void radioButtonGenderCheckMember(Members member)
    {
        if (member.Gender == "F")
        {
            rbGenderFemale.Checked = true;
            rbGenderMale.Checked = false;
        }

        else
        {
            rbGenderMale.Checked=true;
            rbGenderFemale.Checked = false;
        }
    }
    private void radioButtonGenderCheckRegistration(Registration member)
    {
        if (member.Gender == "F")
        {
            rbGenderFemale.Checked = true;
            rbGenderMale.Checked = false;
        }

        else
        {
            rbGenderMale.Checked = true;
            rbGenderFemale.Checked = false;
        }
    }

    private void radioButtonRoleCheck(Members member)
    {
        if (member.Role == "user")
        {
            rbRoleUser.Checked = true;
            rbRoleAdmin.Checked= false;
        }

        else
        {
            rbRoleAdmin.Checked = true;
            rbRoleUser.Checked = false;
        }
    }

    private void GetRadioButtonGenderValue(Members member)
    {
        if (rbGenderFemale.Checked==true)
        {
            member.Gender = "F";
        }

        else
        {
            member.Gender = "M";
        }
    }

    private void GetRadioButtonRole(Members member)
    {
        if (rbRoleUser.Checked==true)
        {
           member.Role="user";
        }

        else
        {
            member.Role = "administrator";
        }
    }
   
    private void membersModelToScreen(Members member)
    {
        tbUserId.Text = "" + member.MemberId;
        tbFirstName.Text = member.FirstName;
        tbLastName.Text = member.LastName;
        radioButtonGenderCheckMember(member);
        tbPhone.Text = member.Phone;
        tbEmail.Text = member.Email;
        tbUserName.Text = member.UserName;
        tbPassword.Text = member.Password;
        radioButtonRoleCheck(member);
    }

    private void ClassesModelToScreen(Classes classes)
    {
        tbClassId.Text = "" + classes.ClassId;
        tbClassName.Text = classes.ClassName;
        tbWeeklyClasses.Text = "" + classes.WeeklyClasses;
        tbStartDate.Text = "" + classes.StartDate;
        tbEndDate.Text = "" + classes.EndDate;
    }

    private void membersRegistrationModelToScreen(Registration member)
    {
        tbFirstName.Text = member.FirstName;
        tbLastName.Text = member.LastName;
        radioButtonGenderCheckRegistration(member);
        tbPhone.Text = member.Phone;
        tbEmail.Text = member.Email;
        tbUserName.Text = member.UserName;
        tbPassword.Text = member.Password;
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
        member.UserName = tbUserName.Text.Trim();
        member.Password = tbPassword.Text.Trim();
        GetRadioButtonRole(member);
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
        rbGenderFemale.Checked=true;
        tbPhone.Text = "";
        tbEmail.Text = "";
        tbUserId.Text = "";
        tbPassword.Text = "";
        tbRePassword.Text = "";
        rbRoleUser.Checked=true;
    }

    private void resetFormClasses()
    {
        tbClassId.Text = "";
        tbClassName.Text = "";
        tbWeeklyClasses.Text = "";
        tbStartDate.Text = "";
        tbEndDate.Text = "";
    }

    private void MemberviewStateNew()
    {
        tbUserId.Enabled = true;

        btAdd.Enabled = true;
        btDelete.Enabled = false;
        btnew.Enabled = true;
        btUpdate.Enabled = false;
        btRemovePenRequest.Enabled = false;

        resetFormMember();
        ListBoxRegMember.SelectedIndex = -1;
        ListBoxPendMember.SelectedIndex = -1;
        showNoMessageMember();
    }

    private void classViewStateNew()
    {
        tbClassId.Enabled = true;

        btClassAdd.Enabled = true;
        btClassDelete.Enabled = false;
        btClassNew.Enabled = true;
        btClassUpdate.Enabled = false;

        resetFormClasses();
        ListBoxClasses.SelectedIndex = -1;
        showNoMessageClass();
    }

    private void PenmemberViewStateDetailsDisplayed()
    {
        tbUserId.Enabled = true;
        tbUserId.Focus();

        btAdd.Enabled = true;
        btRemovePenRequest.Enabled = true;
        btDelete.Enabled = false;
        btnew.Enabled = false;
        btUpdate.Enabled = false;

        ListBoxRegMember.SelectedIndex = -1;
    }

    private void memberViewStateDetailsDisplayed()
    {
        tbUserId.Enabled = false;
        tbUserId.Focus();

        btAdd.Enabled = false;
        btRemovePenRequest.Enabled = false;
        btDelete.Enabled = true;
        btnew.Enabled = true;
        btUpdate.Enabled = true;

        ListBoxPendMember.SelectedIndex = -1;
    }

    private void classViewStateDetailsDisplayed()
    {
        tbClassId.Enabled = false;
        tbUserId.Focus();

        btClassAdd.Enabled = false;
        btClassDelete.Enabled = true;
        btClassNew.Enabled = true;
        btUpdate.Enabled = true;
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