<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="ManagementPage.aspx.cs" Inherits="ManagementPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Manage</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/Custom-Cs.css" rel="stylesheet" />
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
 <body>
     <form id="form1" runat="server">
    <div>
        <!-- Navbar -->
        <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="Default.aspx">
                            <span><img alt="Logo" src="images/2_Flat_logo_on_transparent_250x75.png" height="30" /></span><asp:Label ID="lbLoginInfo" runat="server" style="margin-left:20px" Font-Size="Small" ForeColor="Black"></asp:Label>

                        </a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li><asp:HyperLink ID="hyperLinkHomePage" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink></li>
                            <li><asp:HyperLink ID="hyperLink_ClassPage" runat="server" NavigateUrl="~/ClassesPage.aspx">Classes</asp:HyperLink></li>
                            <li><asp:HyperLink ID="hyperLink_RegistrationPage" runat="server" NavigateUrl="~/RegistrationPage.aspx">Registration</asp:HyperLink></li>
                            <li><asp:HyperLink ID="hyperLink_SignIn" runat="server" NavigateUrl="~/SignIn.aspx">Sign In</asp:HyperLink></li>
                            <li><asp:HyperLink ID="hyperLink_myAccount" runat="server" NavigateUrl="~/MyAccountPage.aspx">My Account</asp:HyperLink></li>                      
                            <li class="active"><asp:HyperLink ID="hyperLink_Manage" runat="server" NavigateUrl="~/ManagementPage.aspx">Manage</asp:HyperLink></li>
                            <li><asp:LinkButton ID="btLogout" runat="server" CssClass="logout_link" OnClick="btLogout_Click" Font-Bold="true">Sign Out</asp:LinkButton><br /></li>
                            
                        </ul>
                    </div>
                </div>
            </div>
        </div>
         <br />
         <br />
    <div class="container">
        <div class="form-horizontal">
            <h2>Membership Management</h2>
            <hr />
        </div>
        <div class="row">
            <div class="col-xs-6">
                    <div class="text-center">
                        <h4>Registered Members</h4>
                        <asp:ListBox ID="ListBoxRegMember" runat="server" AutoPostBack="True" Height="250px" Width="300px" OnSelectedIndexChanged="ListBoxRegMember_SelectedIndexChanged"></asp:ListBox>
                        <asp:Label ID="LbRegMembers" runat="server" ForeColor="Red"></asp:Label>
                    
                    </div>
                
                    <div class="text-center">
                        <h4>Pending Members</h4>
                        <asp:ListBox ID="ListBoxPendMember" runat="server" AutoPostBack="True" Height="250px" Width="300px" OnSelectedIndexChanged="ListBoxPendMember_SelectedIndexChanged"></asp:ListBox>
                        <asp:Label ID="LbPenMember" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                
            </div>
            <div class="col-xs-6">
                    <div class="text-center">
                        <h4>Member Details</h4>
                        <hr />
                        
                        <table class="table-responsive">
                            <tr>
                                <td>
                                    <asp:Label ID="lbUserId" runat="server" Text="User Id:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbUserId" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbFirstName" runat="server" Text="First name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbLastName" runat="server" Text="Last Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbGender" runat="server" Text="Gender:"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rbGenderFemale" runat="server" value="F" Text="Female" GroupName="Gender" />
                                    <asp:RadioButton ID="rbGenderMale" runat="server" value="M" Text="Male" GroupName="Gender" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbPhone" runat="server" Text="Phone:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbPhone" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbEmail" runat="server" Text="Email:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbUserName" runat="server" Text="Username:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbPassword" runat="server" Text="Password"></asp:Label>
                                    :</td>
                                <td>
                                    <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbRePassword" runat="server" Text="Re-Type Password:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbRePassword" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbRole" runat="server" Text="Role:"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rbRoleUser" runat="server" Text="User" value="user" GroupName="Role" />
                                    <asp:RadioButton ID="rbRoleAdmin" runat="server" Text="Admin" value="administrator" GroupName="Role" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lbRegMemberForm" runat="server" ForeColor="Green"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnew" runat="server" CssClass="btn btn-default" Text="New" OnClick="btnew_Click" />
                                    <asp:Button ID="btAdd" runat="server" CssClass="btn btn-default" Text="Add" OnClick="btAdd_Click" />
                                    <asp:Button ID="btUpdate" runat="server" CssClass="btn btn-default" Text="Update" OnClick="btUpdate_Click" />
                                    <asp:Button ID="btDelete" runat="server" CssClass="btn btn-default" Text="Delete" OnClick="btDelete_Click" />
                                    <asp:Button ID="btRemovePenRequest" runat="server" CssClass="btn btn-default" OnClick="btRemovePenRequest_Click" Text="Remove Req" />
                                </td>
                            </tr>
                        </table>
                        
                    </div>
                
            </div>
        </div>
        <div class="form-horizontal">
            <h2>Class Management</h2>
            <hr />
        </div>

        <div class="row">
            <div class="col-xs-6">
                    <div class="text-center">
                        <h4>Classes</h4>
                        <asp:ListBox ID="ListBoxClasses" runat="server" AutoPostBack="True" Height="250px" Width="300px" OnSelectedIndexChanged="ListBoxClasses_SelectedIndexChanged"></asp:ListBox>
                        <asp:Label ID="LbClassList" runat="server" ForeColor="Red"></asp:Label>
                    
                    </div>   
            </div>
            <div class="col-xs-6">
                <div class="text-center">
                    <h4>Class Details</h4>
                    <hr />
                    
                    <table class="table-responsive">
                        <tr>
                            <td>
                                <asp:Label ID="lbClassId" runat="server" Text="Class Id:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbClassId" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbClassName" runat="server" Text="Class Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbClassName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbWeeklyClasses" runat="server" Text="Weekly Classes:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbWeeklyClasses" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbStartDate" runat="server" Text="Start Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbStartDate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbEndDate" runat="server" Text="End Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbEndDate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Label ID="LbClassReg" runat="server" ForeColor="Green"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="btClassNew" runat="server" CssClass="btn btn-default" Text="New" OnClick="btClassNew_Click" />
                                <asp:Button ID="btClassAdd" runat="server" CssClass="btn btn-default" Text="Add" OnClick="btClassAdd_Click" />
                                <asp:Button ID="btClassUpdate" runat="server" CssClass="btn btn-default" Text="Update" OnClick="btClassUpdate_Click" />
                                <asp:Button ID="btClassDelete" runat="server" CssClass="btn btn-default" Text="Delete" OnClick="btClassDelete_Click" />
                            </td>
                        </tr>
                    </table>
                    
                </div>
            </div>
                
        </div>


    </div>
    </form>

            <!--- Footer  -->

    <hr />

    <footer>
        <div class="container">
            <p class="pull-right"><a href="#">Back to top</a></p>
            <p>&copy; 2016 Nahian Jaydi &middot; <a href="Default.aspx">Home</a> &middot; <a href="#">Contact</a> </p>
        </div>
    </footer>

    <!--- Footer -->


    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
