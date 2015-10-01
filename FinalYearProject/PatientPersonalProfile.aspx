<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="PatientPersonalProfile.aspx.cs" Inherits="FinalYearProject.PatientPersonalProfile" %>
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
                <img src="webcss/images/logo.png" alt="Progressus HTML5 template" class="imgiconcss" />
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
    <asp:DataList ID="dl_patients" runat="server" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" RepeatColumns="3" RepeatDirection="Horizontal">
    <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            <asp:Image ID="img_profileimage" runat="server" Height="200" Width="200" ImageUrl='<%# Bind("PatientImageUrl") %>' style="float:left;"/>
            <br />
            Name:<asp:Label ID="lbl_patientname" runat="server" Text='<%# Bind("PatientName") %>' Font-Bold="true"></asp:Label>
            <br />
            Paitent IC:<asp:Label ID="lbl_patientic" runat="server" Text='<%# Bind("PatientIC") %>' Font-Bold="true"></asp:Label>
            <br />
            Gender:<asp:Label ID="lbl_Gender" runat="server" Text='<%# Bind("Gender") %>' Font-Bold="true"></asp:Label>
            <br />
            Birthdate:<asp:Label ID="lbl_bday" runat="server" Text='<%# Bind("Birtthdate") %>' Font-Bold="true"></asp:Label>
        </ItemTemplate>
    </asp:DataList>
   
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

