<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="CreatePatient.aspx.cs" Inherits="FinalYearProject.CreatePatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <li><a href="About.aspx">Patient</a></li>
                          <!--  <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">More Pages <b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="sidebar-left.html"></a></li>
                                    <li class="active"><a href="sidebar-right.html">Right Sidebar</a></li>
                                </ul>
                            </li> -->
                            <li><a href="UploadMusic.aspx">Music</a></li>
                </ul>
                 <img src="siteimages/logo.png" alt="Progressus HTML5 template" class="imgiconcss" />
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
                    &nbsp;</p>
    </asp:Panel>
    <asp:Panel runat="server" HorizontalAlign="Center">
        <table style="margin:0 auto">
            <tr>
                <td>Patient Name</td>
                <td> <asp:TextBox ID="tb_patientname" runat="server"></asp:TextBox> </td>
            </tr>
            <tr>
                <td>Patient IC</td>
                <td> <asp:TextBox ID="tb_patientic" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Patient Birtdate</td>
                <td><asp:TextBox ID="tb_birthdate" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Patient Gender</td>
                <td><asp:DropDownList ID="ddl_gender" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem Value="Female"></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>Patient Profile Image</td>
                <td><asp:FileUpload ID="fu_patientimage" runat="server" /></td>
                
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" /> <asp:Button ID="btn_reset" runat="server" Text="Reset" OnClick="btn_reset_Click" /></td>
                
            </tr>
            <tr>
                <td></td>
                <td><asp:Label ID="lbl_result" runat="server"></asp:Label></td>
                
            </tr>
        </table>
    </asp:Panel>
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

