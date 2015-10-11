<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="PatientPersonalProfile.aspx.cs" Inherits="FinalYearProject.PatientPersonalProfile" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script src="http://code.jquery.com/jquery-1.9.1.min.js" type="text/javascript"></script>  
    <script src="http://code.highcharts.com/highcharts.js" type="text/javascript"></script>

    <script type="text/javascript">  
     $(function ($) {  
      $('#hello').highcharts({  
        chart: {  
          type: 'line'  
        },  
        title: {  
          text: 'Monthly Average Rainfall'  
        },  
        subtitle: {  
          text: 'Source: WorldClimate.com'  
        },  
        xAxis: {  
          categories: [  
            'Jan',  
            'Feb',  
            'Mar',  
            'Apr',  
            'May',  
            'Jun',  
            'Jul',  
            'Aug',  
            'Sep',  
            'Oct',  
            'Nov',
            'Jan',
            'Feb',
            'Mar',
            'Apr',
            'May',
            'Jun',
            'Jul',
            'Aug',
            'Sep',
            'Oct',
            'Nov',
            'Dec'  
          ]  
        },  
        yAxis: {  
          min: 0,  
          title: {  
            text: 'Rainfall (mm)'  
          }  
        },  
        tooltip: {  
          headerFormat: '<span style="font-size:10px">{point.key}</span><table>',  
          pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +  
            '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',  
          footerFormat: '</table>',  
          shared: true,  
          useHTML: true  
        },  
        plotOptions: {  
          column: {  
            pointPadding: 0.2,  
            borderWidth: 0  
          }  
        },  
        series:[{
                 name: 'Tokyo',
                 data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]
             }]   
      });  
    });  
 </script>
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
                    <img src="siteimages/BLmasterpagebanner.jpg" />
                </p>
    </asp:Panel>
      <asp:Panel runat="server" HorizontalAlign="Center">
        <a href="ViewPatients.aspx">Patient List</a> > <a href="PatientPersonalProfile.aspx"> View Patient Details</a>
        <table style="margin:0 auto;">
            <tr>
                <td>
    <asp:DataList ID="dl_patients" runat="server" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" RepeatColumns="3" RepeatDirection="Horizontal">
    <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            <asp:Image ID="img_profileimage" runat="server" Height="200" Width="200" ImageUrl='<%# Bind("PatientImageUrl") %>' style="float:left;"/>
            
        </ItemTemplate>
    </asp:DataList>
                    </td>
                <td>
              <asp:DataList ID="dl_info" runat="server" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" RepeatColumns="3" RepeatDirection="Horizontal">
    <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            
            Name:<asp:Label ID="lbl_patientname" runat="server" Text='<%# Bind("PatientName") %>' Font-Bold="true"></asp:Label>
            <br />
            Paitent IC:<asp:Label ID="lbl_patientic" runat="server" Text='<%# Bind("PatientIC") %>' Font-Bold="true"></asp:Label>
            <br />
            Gender:<asp:Label ID="lbl_Gender" runat="server" Text='<%# Bind("Gender") %>' Font-Bold="true"></asp:Label>
            <br />
            Birthdate:<asp:Label ID="lbl_bday" runat="server" Text='<%# Bind("Birtthdate") %>' Font-Bold="true"></asp:Label>
        </ItemTemplate>
    </asp:DataList>
                    </td>
                </tr>
            </table>
   </asp:Panel>
  <br />
       <div id="hello" style="min-width: 400px; height: 400px; margin: 0 auto"></div> 
    <asp:Panel runat="server" HorizontalAlign="Center">
         Training Records:(<a href="PatientTrainingRecords.aspx">View Details</a>)
        <br />
        <br />
        
   
         <br />
       
        
      
    </asp:Panel>
    <br />
    <br />
    <br />
    <asp:Panel runat="server" HorizontalAlign="Center">
        Music Assigned:
        <br />
        <asp:GridView ID="gv_musicfiles" runat="server"   AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gv_musicfiles_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
        <Columns>

            <asp:TemplateField HeaderText="Song Name">
                <ItemTemplate>
                    <asp:Label ID="lbl_songname" Text='<%#Bind("SongName") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>



            <asp:TemplateField HeaderText="Play">
                <ItemTemplate>
                    <audio controls id="ac_music" runat="server">
                        <source src="<%# Eval("AzureUrl") %>" type="audio/mpeg">
                    </audio>
                </ItemTemplate>
                <asp:ItemTemplate>
                </asp:ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="DeleteSong" Text="Remove Song"/>

        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
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


