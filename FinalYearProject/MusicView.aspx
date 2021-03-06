﻿ <%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="MusicView.aspx.cs" Inherits="FinalYearProject.MusicView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CssStyles/style.css" rel="stylesheet" />
    <link href="CssStyles/datalist%20css.css" rel="stylesheet" />
    
   
    
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
                    
        </p>
    </asp:Panel>
    <asp:Panel runat="server" HorizontalAlign="Center">
        <div id ="getrektboiss" style="color:black">
        Search Query:<asp:TextBox ID="tb_query" runat="server"></asp:TextBox>
        by
      
        <asp:RadioButton ID="rb_artists"  runat="server" Text="Artists" GroupName="Query" ForeColor="Black" />
        by
        <asp:RadioButton ID="rb_albums" runat="server" Text="Albums" GroupName="Query" ForeColor="Black"  />
   
        <asp:Button ID="btn_queries" runat="server" Text="Search" OnClick="btn_queries_Click" Width="67px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_reset" runat="server" Text="Reset Music View" OnClick="btn_reset_Click" />
        &nbsp;&nbsp;
        
        <br />
        <asp:Label ID="lbl_result" runat="server"></asp:Label>
</div>
        


    </asp:Panel>
    <asp:DataList ID="dl_music" runat="server" Font-Names="Verdana" Font-Size="Small" RepeatColumns="3" RepeatDirection="Horizontal" Width="800px" HorizontalAlign="Center" OnItemCommand="dl_music_ItemCommand">
        <ItemStyle ForeColor="Black" />
        <ItemTemplate>
            <div id="pricePlans">
                <ul id="plans">
                    <li class="plan">
                        <ul class="planContainer">
                            <li class="title">
                                <h2>Album Name:
                                    <br />
                                    <asp:Label ID="lbl_albumname" runat="server" Text='<%#Bind("Album") %>'></asp:Label>
                            </li>
                            <li class="title">
                                <asp:Image ID="img_albumart" runat="server" Height="200" Width="200" ImageUrl='<%# Bind("AlbumArtPath", "~/{0}") %>' />
                            </li>
                            <li>
                                <ul class="options">
                                    <li><span>Artist Name:
                                        <asp:Label ID="lbl_artistname" runat="server" Text='<%#Bind("ArtistName") %>'></asp:Label></span></li>
                                </ul>
                            </li>
                            <li class="button">
                                <asp:LinkButton ID="lb_songs" CommandName="SongInfo" runat="server">Songs</asp:LinkButton>

                            </li>
                        </ul>
                    </li>
                </ul>
            </div>







        </ItemTemplate>
        <FooterTemplate >
           <asp:Panel runat="server" HorizontalAlign="Center">
               <br />
               <br />
               <br />
<asp:Label Visible='<%#bool.Parse((dl_music.Items.Count==0).ToString())%>' runat="server" ID="lblNoRecord" Text="No Record Found!" ForeColor="Black" Font-Size="Large"></asp:Label>
               </asp:Panel>
            <br />
            <br />
            <br />
</FooterTemplate>


    </asp:DataList>    
     <table style="margin:0 auto">
  <tr>
    <td>
        <asp:Button ID="btnfirst" runat="server" Font-Bold="true" Text="<<" Height="31px" 
                    Width="43px" onclick="btnfirst_Click" /></td>
        <td>
            <asp:Button ID="btnprevious" runat="server" Font-Bold="true" Text="<" Height="31px" 
                    Width="43px" onclick="btnprevious_Click" /></td>
            <td>
                <asp:Button ID="btnnext" runat="server" Font-Bold="true" Text=">" Height="31px" 
                    Width="43px" onclick="btnnext_Click" /></td>
                <td>
                    <asp:Button ID="btnlast" runat="server" Font-Bold="true" Text=">>" Height="31px" 
                    Width="43px" onclick="btnlast_Click" /></td>
    </tr>
   </table>                                         
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



