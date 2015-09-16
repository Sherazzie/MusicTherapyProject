﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="Viewmusicfiles.aspx.cs" Inherits="FinalYearProject.Viewmusicfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CssStyles/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div class="navbar navbar-inverse navbar-fixed-top headroom" >
        <div class="container">
            <div class="navbar-header">
				<!-- Button for smallest screens -->
				        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="index.html">
                <img src="webcss/images/logo.png" alt="Progressus HTML5 template" /></a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav pull-right">
                    <li class="active"><a href="Home.aspx">Home</a></li>
                    <li><a href="About.aspx">About</a></li>
                          <!--  <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">More Pages <b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="sidebar-left.html"></a></li>
                                    <li class="active"><a href="sidebar-right.html">Right Sidebar</a></li>
                                </ul>
                            </li> -->
                            <li><a href="UploadMusic.aspx">Upload Music</a></li>
                    <li><a href="SignUp.aspx">Registration</a></li>
                    <li><a href="Login.aspx">Login</a></li>
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
     <asp:GridView ID="gv_musicfiles" runat="server"  AutoGenerateColumns="false" RowStyle-BackColor="#A1DCF2" Font-Names = "Arial" Font-Size = "10pt" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" HorizontalAlign="Center">
            <Columns>
                <asp:TemplateField HeaderText="Album Art">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="200" Width="200" ImageUrl='<%# Bind("AlbumArtPath", "~/{0}") %>' />
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Song Name">
                <ItemTemplate>
                    <asp:Label ID="lbl_songname" Text='<%#Bind("SongName") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Artist Name">
                <ItemTemplate>
                    <asp:Label ID="lbl_artistname" Text='<%#Bind("ArtistName") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Allbum Name">
                <ItemTemplate>
                    <asp:Label ID="lbl_artistname" Text='<%#Bind("Album") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              
                
                 <asp:TemplateField HeaderText="Play">
                <ItemTemplate>
                    <audio controls runat="server">
                    <source src="<%# Eval("AzureUrl") %>" type="audio/mpeg">
                    </audio >
                </ItemTemplate>
            <asp:ItemTemplate >
              

                
            </asp:ItemTemplate>
            </asp:TemplateField>
              
            </Columns>
        </asp:GridView>
    <br />
    <br />
    <table style="margin:0 auto">
        <tr>
            <td>Enter Artist Name:</td>
            <td><asp:TextBox ID="tb_aname" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btn_searchbyartist" runat="server" Text="Search by artist" OnClick="btn_searchbyartist_Click" /> </td>
            
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Enter Album Name:</td>
            
            <td><asp:TextBox ID="tb_albumname" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btn_searchbyalbum" runat="server" Text="Search by album" OnClick="btn_searchbyalbum_Click" /> </td>
        </tr>
         <tr>
            <td></td>
            <td> </td>
             
        </tr>
        <tr><td>Enter Song Name</td>
            <td><asp:TextBox ID="tb_sname" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btn_searchbysong" runat="server" Text="Search by song" OnClick="btn_searchbysong_Click" /> </td>
        </tr>
        <tr>
            <td>Reset Music List</td>
            
            <td><asp:Button ID="btn_resetmusic" runat="server" Text="Reset Music List" OnClick="btn_resetmusic_Click" /></td>
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

