<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="PatientEventsAssignment.aspx.cs" Inherits="FinalYearProject.PatientEventsAssignment" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 561px;
            height: 40px;
            color: white;
            padding-left: 20px;
            padding-top: 10px;
            background-color: #5d4949;
        }
    </style>
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
    <asp:Panel runat="server" HorizontalAlign="Center">
        <br />
        <br />
        <br />
        <br />
        <p style="vertical-align: middle;">
            &nbsp;
        </p>
    </asp:Panel>
    <asp:Panel runat="server" HorizontalAlign="Center">
        <a href="ViewPatients.aspx">Patient List</a> > <a href="PatientPersonalProfile.aspx"><%=this.patientname %></a> > <a href="PatientTrainingRecords.aspx">View Patient Calendar</a> > <a href="PatientEventsAssignment.aspx">Add Appointment Summary</a>

    </asp:Panel>
    <br />
    <br />
    <div class="container main-container">
        <div class="FoodIntake-container2">
            <div class="auto-style1">
                Add appointment Summary
            </div>
          
            <div class="common-content-containerW">
                  <br />
            <br />
            <br />
                <table style="margin: 0 auto; color: black;">
                    <tr>
                        <td>Patient Name</td>

                        <td>
                            <asp:TextBox ID="tb_patientname" runat="server" TextMode="SingleLine" Enabled="False"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Patient IC</td>
                        <td>
                            <asp:TextBox ID="tb_patientic" runat="server" Enabled="False"></asp:TextBox></td>
                    </tr>
                    <tr>

                        <td>Select Appointment Date</td>
                        <td>
                            <asp:TextBox ID="tb_date" runat="server" Enabled="False"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Calendar ID="cal_patient" runat="server" OnSelectionChanged="cal_patient_SelectionChanged" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                                <DayStyle BackColor="#CCCCCC" />
                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                                <TodayDayStyle BackColor="#999999" ForeColor="White" />
                            </asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Appointment Summary</td>
                        <td>
                            <asp:TextBox ID="tb_summary" runat="server" TextMode="MultiLine" Height="128px" Width="355px"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td></td>

                        <td>
                            <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
                            <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="lbl_result" runat="server"></asp:Label></td>

                    </tr>

                </table>
            </div>
        </div>
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


