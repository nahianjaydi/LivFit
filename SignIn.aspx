<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Sign In</title>

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
                            <li class="active"><asp:HyperLink ID="hyperLink_SignIn" runat="server" NavigateUrl="~/SignIn.aspx">Sign In</asp:HyperLink></li>
                            <li><asp:HyperLink ID="hyperLink_myAccount" runat="server" NavigateUrl="~/MyAccountPage.aspx">My Account</asp:HyperLink></li>                      
                            <li><asp:HyperLink ID="hyperLink_Manage" runat="server" NavigateUrl="~/ManagementPage.aspx">Manage</asp:HyperLink></li>
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
                <h2>Login</h2>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Username"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="tbUserName" CssClass="form-control" runat="server"></asp:TextBox>
                        
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Password"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="tbPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        
                    </div>
                </div>
                <div class="form-group">
                        <div class="col-md-2"></div>                    
                    <div class="col-md-6">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Remember me ?"></asp:Label>
                    </div>
                </div>
                 <div class="form-group">
                        <div class="col-md-2"></div>                    
                    <div class="col-md-6">
                        <asp:Button ID="btLogin" runat="server" Text="Login" CssClass="btn btn-default" OnClick="Button1_Click"/>
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/RegistrationPage.aspx">Register</asp:LinkButton>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>                    
                    <div class="col-md-6">
                        <asp:Label ID="lbMessage" runat="server" CssClass="text-danger"></asp:Label>
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
