<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="UploadMusic.aspx.cs" Inherits="FinalYearProject.UploadMusic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="CssStyles/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div class="navbar navbar-inverse navbar-fixed-top headroom" >
        <div class="container">
            <div class="navbar-header">
				<!-- Button for smallest screens -->
				        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="index.html">
                <img src="webcss/images/logo.png" alt="Progressus HTML5 template" /></a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav pull-right">
                    <li class="active"><a href="Home.aspx">Home</a></li>
                    <li><a href="About.aspx">About</a></li>
                          <!--  <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">More Pages <b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="sidebar-left.html"></a></li>
                                    <li class="active"><a href="sidebar-right.html">Right Sidebar</a></li>
                                </ul>
                            </li> -->
                            <li><a href="UploadMusic.aspx">Upload Music</a></li>
                    <li><a href="SignUp.aspx">Registration</a></li>
                    <li><a href="Login.aspx">Login</a></li>
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
                <p style="vertical-align:middle;">
                    <img src="siteimages/BLmasterpagebanner.jpg" />
                </p>
    </asp:Panel>
    <div>
             
        <div class="login-card">
            <h1>Upload Your Music</h1>
            <br />
          
             Song Name:
             <input type="text" name="Song Name" placeholder="Song Name" runat="server" id="sname"/>
             Artist Name:
            <input type="text" name="Artist Name" placeholder="Artist Name" runat="server" id="artistname" />
            Album Name:
            <input type="text" name="Album Name" placeholder="Album Name" runat="server" id="albumname" />
            Mp3 File:
            <asp:FileUpload ID="fu_uploadmusic" runat="server" />
            Mp3 Album Art:
            <asp:FileUpload ID="fu_uploadart" runat="server" />
            <br />
            <asp:Label ID="lbl_result" runat="server"></asp:Label>
            <input type="submit" name="Upload Music" class="login login-submit" value="Upload Music"  runat="server" OnServerClick="btn_uploadmusic"/>
            
            

            <div class="login-help">
                <a href="MusicView.aspx">View Music </a> • <a href="#">Forgot Password</a>
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

