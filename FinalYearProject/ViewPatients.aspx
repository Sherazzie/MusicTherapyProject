<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="ViewPatients.aspx.cs" Inherits="FinalYearProject.ViewPatients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CssStyles/IndividualEffects.css" rel="stylesheet" />
   <link href="CssStyles/style.css" rel="stylesheet" />
    <link href="CssStyles/datalist%20css.css" rel="stylesheet" />
    <link href="CssStyles/IndividualEffects.css" rel="stylesheet" />
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
                    <li><a href="patientprogress.aspx">Home</a></li>
                    <li><a href="ViewPatients.aspx">Patient</a></li>
                    <li class="dropdown"><a href="UploadMusic.aspx" class="dropdown-toggle" data-toggle="dropdown">Music</a>
                        <ul class="dropdown-menu">
                            <li class="active"><a href="UploadMusic.aspx">Upload Music</a></li>
                            <li class="active"><a href="MusicView.aspx">View Music</a></li>
                        </ul>
                    </li>
                </ul>
                <img src="siteimages/logo.png" alt="Progressus HTML5 template" class="imgiconcss" />
                <ul class="nav navbar-nav pull-right">
                    <li><a href="Home.aspx">Logout</a></li>
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
                   
    </asp:Panel>
    <asp:DataList ID="dl_patients" runat="server" Font-Names="Verdana" Font-Size="Small" RepeatColumns="3" RepeatDirection="Horizontal" Width="800px" HorizontalAlign="Center" OnItemCommand="dl_patient_ItemCommand">
        <ItemStyle ForeColor="Black" />
        <ItemTemplate>
            <div id="pricePlans">
                <ul id="plans">
                    <li class="plan">
                        <ul class="planContainer">
                            <li class="title">
                                <h2>
                                 <br />
                                  <asp:Label ID="lbl_patientname" runat="server" Text='<%#Bind("PatientName") %>'></asp:Label>
                             <br />
                                    </h2>
                               
                            </li>
                            <li class="title">
                                <asp:Image ID="img_profileimage" runat="server" Height="200" Width="200" ImageUrl='<%# Bind("PatientImageUrl") %>' />
                            </li>
                            <br />
                            <li></li>
                            <li class="button">
                                <asp:LinkButton ID="lbl_profile" CommandName="PatientInfo" runat="server" >View Profile</asp:LinkButton>

                            </li>
                        </ul>
                    </li>
                </ul>
            </div>







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


