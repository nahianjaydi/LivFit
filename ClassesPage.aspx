<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="ClassesPage.aspx.cs" Inherits="ClassesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Classes</title>

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
                                <li class="active"><asp:HyperLink ID="hyperLink_ClassPage" runat="server" NavigateUrl="~/ClassesPage.aspx">Classes</asp:HyperLink></li>
                                <li><asp:HyperLink ID="hyperLink_RegistrationPage" runat="server" NavigateUrl="~/RegistrationPage.aspx">Registration</asp:HyperLink></li>
                                <li><asp:HyperLink ID="hyperLink_SignIn" runat="server" NavigateUrl="~/SignIn.aspx">Sign In</asp:HyperLink></li>
                                <li><asp:HyperLink ID="hyperLink_myAccount" runat="server" NavigateUrl="~/MyAccountPage.aspx">My Account</asp:HyperLink></li>                      
                                <li><asp:HyperLink ID="hyperLink_Manage" runat="server" NavigateUrl="~/ManagementPage.aspx">Manage</asp:HyperLink></li>
                                <li><asp:LinkButton ID="btLogout" runat="server" CssClass="logout_link" OnClick="btLogout_Click" Font-Bold="true">Sign Out</asp:LinkButton><br /></li>
                            
                            </ul>
                        </div>
                </div>
            </div>
            <br />
            <br />

            <!--- Middle Contents -->
            <div class="container center">

                <div class="form-horizontal">
                    <h2>Providing Classes</h2>
                    <hr />
                </div>
                <div class="row">
                    <div class="col-lg-4">
                        <img class="img-rounded" src="images/Body-attack-prograam.jpg" alt="thumb01" width="200" height="200" />
                        <h3>Body Attack Program</h3>
                        <p>Nam a metus ac velit malesuada accumsan vel ut mauris. Proin eleifend orci tempor, faucibus felis sagittis, auctor ante. Fusce quis pellentesque metus, eu dictum est. Quisque finibus urna ac metus placerat, id porttitor ligula luctus. Nullam tincidunt, lorem at tincidunt dignissim, purus nunc tincidunt enim, vitae aliquam ante orci efficitur leo. Vivamus ac pretium libero. Quisque venenatis leo vel nibh pretium malesuada. Phasellus aliquam nunc vel e</p>
                        <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                    </div>
                    <div class="col-lg-4">
                        <img class="img-rounded" src="images/yoga_Image.jpg" alt="thumb02" width="200" height="200" />
                        <h3>Yoga</h3>
                        <p>Nam a metus ac velit malesuada accumsan vel ut mauris. Proin eleifend orci tempor, faucibus felis sagittis, auctor ante. Fusce quis pellentesque metus, eu dictum est. Quisque finibus urna ac metus placerat, id porttitor ligula luctus. Nullam tincidunt, lorem at tincidunt dignissim, purus nunc tincidunt enim, vitae aliquam ante orci efficitur leo. Vivamus ac pretium libero. Quisque venenatis leo vel nibh pretium malesuada. Phasellus aliquam nunc vel e</p>
                        <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                    </div>
                    <div class="col-lg-4">
                        <img class="img-rounded" src="images/cardio.jpg" alt="thumb03" width="200" height="200" />
                        <h3>Cardio</h3>
                        <p>Nam a metus ac velit malesuada accumsan vel ut mauris. Proin eleifend orci tempor, faucibus felis sagittis, auctor ante. Fusce quis pellentesque metus, eu dictum est. Quisque finibus urna ac metus placerat, id porttitor ligula luctus. Nullam tincidunt, lorem at tincidunt dignissim, purus nunc tincidunt enim, vitae aliquam ante orci efficitur leo. Vivamus ac pretium libero. Quisque venenatis leo vel nibh pretium malesuada. Phasellus aliquam nunc vel e</p>
                        <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                    </div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col-lg-4">
                        <img class="img-rounded" src="images/meditation-field.jpg" alt="thumb01" width="200" height="200" />
                        <h3>Meditation</h3>
                        <p>Nam a metus ac velit malesuada accumsan vel ut mauris. Proin eleifend orci tempor, faucibus felis sagittis, auctor ante. Fusce quis pellentesque metus, eu dictum est. Quisque finibus urna ac metus placerat, id porttitor ligula luctus. Nullam tincidunt, lorem at tincidunt dignissim, purus nunc tincidunt enim, vitae aliquam ante orci efficitur leo. Vivamus ac pretium libero. Quisque venenatis leo vel nibh pretium malesuada. Phasellus aliquam nunc vel e</p>
                        <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                    </div>
                    <div class="col-lg-4">
                        <img class="img-rounded" src="images/weight_loosing.jpg" alt="thumb02" width="200" height="200" />
                        <h3>Weight Loosing</h3>
                        <p>Nam a metus ac velit malesuada accumsan vel ut mauris. Proin eleifend orci tempor, faucibus felis sagittis, auctor ante. Fusce quis pellentesque metus, eu dictum est. Quisque finibus urna ac metus placerat, id porttitor ligula luctus. Nullam tincidunt, lorem at tincidunt dignissim, purus nunc tincidunt enim, vitae aliquam ante orci efficitur leo. Vivamus ac pretium libero. Quisque venenatis leo vel nibh pretium malesuada. Phasellus aliquam nunc vel e</p>
                        <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                    </div>
                    <div class="col-lg-4">
                        <img class="img-rounded" src="images/Muscle-Building.jpg" alt="thumb03" width="200" height="200" />
                        <h3>Body Building</h3>
                        <p>Num a metus ac velit malesuada accumsan vel ut mauris. Proin eleifend orci tempor, faucibus felis sagittis, auctor ante. Fusce quis pellentesque metus, eu dictum est. Quisque finibus urna ac metus placerat, id porttitor ligula luctus. Nullam tincidunt, lorem at tincidunt dignissim, purus nunc tincidunt enim, vitae aliquam ante orci efficitur leo. Vivamus ac pretium libero. Quisque venenatis leo vel nibh pretium malesuada. Phasellus aliquam nunc vel e</p>
                        <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                    </div>
                </div>
            </div>
            <!--- Middle Contents -->
            <br />
            <br />
            <div class="container">
              <div class="row">
                <div class="col-xs-6">
                        <div class="text-center">
                            <h4>Ongoing Classes</h4>
                            <hr />
                            <asp:ListBox ID="ListBoxMyAccount" runat="server" AutoPostBack="True" Height="250px" OnSelectedIndexChanged="ListBoxMyAccount_SelectedIndexChanged" Width="300px"></asp:ListBox>
                            <asp:Label ID="LbClassList" runat="server" ForeColor="Red"></asp:Label>
                    
                        </div>   
                </div>
                <div class="col-xs-6">
                    <div class="text-center">
                        <h4>Class Details</h4>
                        <hr />
                    
                        <table class="table-responsive" style="margin-right:auto; margin-left:auto">
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
                            </table>
                    
                    </div>
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
