<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Home</title>

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
                            <li class="active"><asp:HyperLink ID="hyperLinkHomePage" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink></li>
                            <li><asp:HyperLink ID="hyperLink_ClassPage" runat="server" NavigateUrl="~/ClassesPage.aspx">Classes</asp:HyperLink></li>
                            <li><asp:HyperLink ID="hyperLink_RegistrationPage" runat="server" NavigateUrl="~/RegistrationPage.aspx">Registration</asp:HyperLink></li>
                            <li><asp:HyperLink ID="hyperLink_SignIn" runat="server" NavigateUrl="~/SignIn.aspx">Sign In</asp:HyperLink></li>
                            <li><asp:HyperLink ID="hyperLink_myAccount" runat="server" NavigateUrl="~/MyAccountPage.aspx">My Account</asp:HyperLink></li>                      
                            <li><asp:HyperLink ID="hyperLink_Manage" runat="server" NavigateUrl="~/ManagementPage.aspx">Manage</asp:HyperLink></li>
                            <li><asp:LinkButton ID="btLogout" runat="server" CssClass="logout_link" OnClick="btLogout_Click" Font-Bold="true">Sign Out</asp:LinkButton><br /></li>
                            
                        </ul>
                    </div>
                </div>
              </div>
    <!--- Carousel -->
        <div class="container">

 <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
    <div class="item active">
      <img src="images/fitness-strength-strong-male.jpg" alt="..."/>
      <div class="carousel-caption">
       <h3>The Body Achives</h3>
    <p>What The Mind Belives</p>
          <p><a class="btn btn-lg btn-primary" href="RegistrationPage.aspx" role="button">Join Us Today</a></p>
      </div>
    </div>
    <div class="item">
      <img src="images/Weight.jpg" alt="..."/>
      <div class="carousel-caption">
        <h3>I Can I Will</h3>
    <p>End of Story</p>
      </div>
    </div>
    <div class="item">
      <img src="images/bigstock_Woman_Lifting_Free_Weights_4420789.jpg" alt="..."/>
      <div class="carousel-caption">
        <h3>Stay Fit</h3>
    <p>Live Long</p>
      </div>
    </div>
  </div>

  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>

        <!--- Carousel -->


    </div>
        <br/>
        <br/>
        <!--- Middle Contents -->
        <div class="container center">
            <div class="row">
                <div class="col-lg-4">
                    <img class="img-circle" src="images/healthy_eating_vegetables_01.jpg" alt="thumb01" width="200" height="200" />
                    <h2>Eat Healthy</h2>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla eu nunc eu felis mollis suscipit. Vivamus at turpis nisi. Nam a metus ac velit malesuada accumsan vel ut mauris. Proin eleifend orci tempor, faucibus felis sagittis, auctor ante. Fusce quis pellentesque metus, eu dictum est. Quisque finibus urna ac metus placerat, id porttitor ligula luctus. Nullam tincidunt, lorem at tincidunt dignissim, purus nunc tincidunt enim, vitae aliquam ante orci efficitur leo. Vivamus ac pretium libero. Quisque venenatis leo vel nibh pretium malesuada. Phasellus aliquam nunc vel e</p>
                    <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="images/Exercise.jpg" alt="thumb02" width="200" height="200" />
                    <h2>Exercise</h2>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla eu nunc eu felis mollis suscipit. Vivamus at turpis nisi. Nam a metus ac velit malesuada accumsan vel ut mauris. Proin eleifend orci tempor, faucibus felis sagittis, auctor ante. Fusce quis pellentesque metus, eu dictum est. Quisque finibus urna ac metus placerat, id porttitor ligula luctus. Nullam tincidunt, lorem at tincidunt dignissim, purus nunc tincidunt enim, vitae aliquam ante orci efficitur leo. Vivamus ac pretium libero. Quisque venenatis leo vel nibh pretium malesuada. Phasellus aliquam nunc vel e</p>
                    <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="images/have-fun.jpg" alt="thumb03" width="200" height="200" />
                    <h2>Have Fun</h2>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla eu nunc eu felis mollis suscipit. Vivamus at turpis nisi. Nam a metus ac velit malesuada accumsan vel ut mauris. Proin eleifend orci tempor, faucibus felis sagittis, auctor ante. Fusce quis pellentesque metus, eu dictum est. Quisque finibus urna ac metus placerat, id porttitor ligula luctus. Nullam tincidunt, lorem at tincidunt dignissim, purus nunc tincidunt enim, vitae aliquam ante orci efficitur leo. Vivamus ac pretium libero. Quisque venenatis leo vel nibh pretium malesuada. Phasellus aliquam nunc vel e</p>
                    <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                </div>
            </div>
        </div>
        <!--- Middle Contents -->
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

