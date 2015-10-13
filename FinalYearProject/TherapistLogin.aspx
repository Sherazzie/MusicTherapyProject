<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="TherapistLogin.aspx.cs" Inherits="FinalYearProject.TherapistLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="CssStyles/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div class="navbar navbar-inverse navbar-fixed-top headroom" >
        <div class="container">
            <div>
				<!-- Button for smallest screens -->
				        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                </button>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav pull-left">
                    <li><a href="Home.aspx">Home</a></li>
                </ul>
                <img src="webcss/images/logo.png" alt="Progressus HTML5 template" class="imgiconcss" />
                <ul class="nav navbar-nav pull-right">
                    <li><a href="TherapistSignUp.aspx">Sign Up</a></li>
                    <li><a href="TherapistLogin.aspx">Login</a></li>
                </ul>
            </div>
                    <!--/.nav-collapse -->

		        </div>
    </div>
	<!-- /.navbar -->
            <asp:Panel runat="server" HorizontalAlign="Center" >
                <br />
                <br />
                <br />
                <br />
    </asp:Panel>
         <div>
        <div class="login-card">
            <h1>Login Page</h1>
            <br />
           
            
             <input type="text" name="email" placeholder="Email" runat="server" id="email" />
            <input type="password" name="pass" placeholder="Password" runat="server" id="password" />
            <br />
            <asp:Label ID="lbl_result" runat="server"></asp:Label>
            <input type="submit" name="login" class="login login-submit" value="Login"  runat="server" onServerClick="btnLogin_Click" />
            


            <div class="login-help">
                <a href="SignUp.aspx">Sign Up</a> • <a href="#">Forgot Password</a>
            </div>
        </div>

        <!-- <div id="error"><img src="https://dl.dropboxusercontent.com/u/23299152/Delete-icon.png" /> Your caps-lock is on.</div> -->
        <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js'></script>

    </div>
    <footer id="footer" class="top-space">
        <div class="footer2">
            <div class="container">
                <div class="row">
                    <div class="col-md-6 widget">
                        <div class="widget-body">
                            <p class="text-right">
                                Copyright &copy; 2015,Mohd Sherrez Kader
                            </p>
                        </div>
                    </div>
                </div>
                        <!-- /row of widgets -->
			        </div>
        </div>
    </footer>
		




	<!-- JavaScript libs are placed at the end of the document so the pages load faster -->
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
	<script src="http://netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>
	<script src="webcss/js/headroom.min.js"></script>
	<script src="webcss/js/jQuery.headroom.min.js"></script>
	<script src="webcss/js/template.js"></script>
        </asp:Content>

