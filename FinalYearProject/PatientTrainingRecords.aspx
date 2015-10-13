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
                <img src="webcss/images/logo.png" alt="Progressus HTML5 template" class="imgiconcss" />
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
         <a href="ViewPatients.aspx">Patient List</a> > <a href="PatientPersonalProfile.aspx"> View Patient Details</a> > <a href="PatientTrainingRecords.aspx"> View Patient Calendar</a>
        <br />
        <br />
      <h1>  Patient Training Calendar( <a href="PatientEventsAssignment.aspx">Add Record</a>) </h1>
        <br />
        <br />
        <table style="margin:0 auto">
            <tr>
               <td>
        <asp:Calendar ID="cal_records" runat="server" Height="357px" Width="539px" OnDayRender="cal_records_DayRender" OnSelectionChanged="cal_records_SelectionChanged">

        </asp:Calendar>
                   </td>
                </tr>
            
        </table>
        <br />
        <br />
        <asp:GridView ID="gv_apptinfo" runat="server" HorizontalAlign="Center"></asp:GridView>
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

