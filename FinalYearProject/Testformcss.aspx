<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="Testformcss.aspx.cs" Inherits="FinalYearProject.Testformcss" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CssStyles/IndividualEffects.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div class="navbar navbar-inverse navbar-fixed-top headroom" >
        <div class="container">
            <div class="pull-center">
				<!-- Button for smallest screens -->
				        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                </button>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav pull-left">
                    <li><a href="Home.aspx">Home</a></li>
                    <li><a href="About.aspx">Patient</a></li>
                          <!--  <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">More Pages <b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="sidebar-left.html"></a></li>
                                    <li class="active"><a href="sidebar-right.html">Right Sidebar</a></li>
                                </ul>
                            </li> -->
                            <li><a href="UploadMusic.aspx">Music</a></li>
                </ul>
                <a class="pull-center" href="Home.aspx"g >
                <img src="webcss/images/logo.png" alt="Progressus HTML5 template" /></a>
                <ul class="nav navbar-nav pull-right">
                    <li><a href="Home.aspx">Registration</a></li>
                    <li><a href="About.aspx">Login</a></li>
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
    <asp:Panel runat="server" HorizontalAlign="Center">
       
            <asp:Button ID="Button1" runat="server" Text="Button" CssClass="wowhover" />
        <br />
        <br />
        <br />
        <img src="CssStyles/1c2iItAD.jpeg" class="wowhover"/>

        
    </asp:Panel>
    <footer id="footer" class="top-space">n
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

