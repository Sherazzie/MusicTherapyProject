<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="PatientTrainingRecords.aspx.cs" Inherits="FinalYearProject.PatientTrainingRecords" %>
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
                    &nbsp;</p>
    </asp:Panel>
    <asp:Panel HorizontalAlign="Center" runat="server">
         <a href="ViewPatients.aspx">Patient List</a> > <a href="PatientPersonalProfile.aspx"> <%=this.patientname %></a> > <a href="PatientTrainingRecords.aspx"> View Patient Calendar</a>
        <br />
        <br />
      <h1 style="color:black;">  Patient Training Calendar( <a href="PatientEventsAssignment.aspx">Add Record</a>) </h1>
        <br />
        <br />
        <table style="margin:0 auto">
            <tr>
               <td>
        <asp:Calendar ID="cal_records" runat="server" Height="357px" Width="417px" OnDayRender="cal_records_DayRender" OnSelectionChanged="cal_records_SelectionChanged" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="ShortMonth">

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
           
            
        </table>
        <br />
        <table style="margin:0 auto">
             <tr>
                <td style="border: 3px solid black;border-collapse: collapse; color:black;">Legend - Summary Available:&nbsp;&nbsp;  <img src="siteimages/SummaryAvail.JPG" />  Today&#39;s Date:&nbsp; <img src="siteimages/currentcaldate.JPG" />&nbsp;&nbsp;&nbsp; </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:DataList ID="dl_appoimentinfo" runat="server"  HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="100px" Width="314px">

            <AlternatingItemStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
             <HeaderTemplate>

            Appointment Summaries

         </HeaderTemplate>
            <ItemTemplate>
                <table style="border: 1px solid black;">
                    <tr>
                        <td style="border: 1px solid black;border-collapse: collapse;">Appointment <br />Day</td>
                        <td style="border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lbl_appdate" runat="server" Text='<%#Bind("ApptDate") %>'></asp:Label></td>   
                    </tr>
              
                    <tr>
                        <td style="border: 1px solid black;border-collapse: collapse;">Appointment Summary</td>
                        <td style="border: 1px solid black;border-collapse: collapse;"><asp:Label ID="lbl_apptsummary" runat="server" Text='<%#Bind("ApptSummary") %>'></asp:Label></td>
                    </tr>
                </table>
                
                
                
                
            </ItemTemplate>

            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />

        </asp:DataList>
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

