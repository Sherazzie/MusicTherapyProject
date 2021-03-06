﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="PatientPersonalProfile.aspx.cs" Inherits="FinalYearProject.PatientPersonalProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="chart.js/Chart.js" type="text/javascript"></script>
 <script src="http://code.jquery.com/jquery-1.9.1.min.js" type="text/javascript"></script>  
       <script src="http://code.highcharts.com/highcharts.js" type="text/javascript"></script>
    <script src="http://code.highcharts.com/themes/sand-signika.js"></script>
   
   
    <script type="text/javascript">
       
     $(function ($) {  
      $('#hello').highcharts({  
        chart: {  
          type: 'line'  
        },  
        title: {  
          text: 'Montly Game Scores'
        },  
        subtitle: {  
          text:'Month: <%=this.chartmonthname%> '
        },  
        xAxis: {  
          categories: [  
                <%= this.hclabels%>
          ]  
        },  
        yAxis: {  
          min: 0,  
          title: {  
            text: 'Scores'  
          }  
        },  
        tooltip: {  
          headerFormat: '<span style="font-size:10px">{point.key}</span><table>',  
          pointFormat: '<tr><td style="color:{series.color};padding:0"> Score is: </td>' +  
            '<td style="padding:0"><b>{point.y:.1f}</b></td></tr>',  
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
                name :'<%= this.chartmonthname%>',
                 data:[ <%= this.hcdata%>]
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
      <asp:Panel runat="server" HorizontalAlign="Center">
        <a href="ViewPatients.aspx">Patient List</a> > <a href="PatientPersonalProfile.aspx"> <%=this.patientname %></a>
          <br />
           <h1 style="color:black"> Personal Details:</h1>
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
            Birthdate:<asp:Label ID="lbl_bday" runat="server" Text='<%# Bind("Birtthdate","{0:dd/M/yyyy}") %>' Font-Bold="true"></asp:Label>
        </ItemTemplate>
    </asp:DataList>
                    </td>
                </tr>
            </table>
   </asp:Panel>
  <br />
       
    <asp:Panel runat="server" HorizontalAlign="Center">
        <h1 style="color:black"> Training Records:(<a href="PatientTrainingRecords.aspx">View Details</a>) </h1>
        <br />
        <asp:ImageButton ID="imbPrevious" runat="server" ImageUrl="~/siteimages/leftbutton.png" Height="39px" Width="52px" OnClick="imbPrevious_Click"/>
                            &nbsp;<asp:Label ID="lbLineDateRangeView" runat="server" ForeColor="Black"></asp:Label>
                            &nbsp;<asp:ImageButton ID="imbNext" runat="server" ImageUrl="~/siteimages/rightbutton.png" Height="39px" Width="52px" OnClick="imbNext_Click" />
   
         <br />
        <br />
        <br />
      <div style="color:white">  *If chart empty no data for current month*</div>
        <br />
             <div id="hello" style="min-width: 400px; height: 400px; margin: 0 auto"></div>
          
        
      
    </asp:Panel>
    <br />
    <br />
    <br />
    <asp:Panel runat="server" HorizontalAlign="Center">
       <h1 style="color:black"> Music Assigned:</h1>
        <br />
        <asp:GridView ID="gv_musicfiles" runat="server"   AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gv_musicfiles_RowCommand" EmptyDataText="No music currently assigned to patient" Font-Size="15pt">
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


