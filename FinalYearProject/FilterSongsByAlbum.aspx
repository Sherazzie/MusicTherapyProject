<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="FilterSongsByAlbum.aspx.cs" Inherits="FinalYearProject.FilterSongsByAlbum" %>

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
                    &nbsp;<br /> <a href="Home.aspx">Home</a> > <a href="MusicView.aspx">Music List</a> > <a href="FilterSongsByAlbum.aspx">Album Songs List</a>
        </p>
    </asp:Panel>

    <asp:DataList ID="dl_music" runat="server" Font-Names="Verdana" Font-Size="Small" RepeatColumns="3" RepeatDirection="Horizontal" Width="600px" HorizontalAlign="Center" OnItemCommand="dl_music_ItemCommand">
        <ItemStyle ForeColor="Black" />
        <ItemTemplate>
            <div id="pricePlans">
                <ul id="plans">
                    <li class="plan">
                        <ul class="planContainer">
                            <li class="title">
                                <h2>Album Name:
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
                                <asp:LinkButton ID="lb_songs" CommandName="SongInfo" runat="server">Back to albums</asp:LinkButton>

                            </li>
                        </ul>
                    </li>
                </ul>
            </div>







        </ItemTemplate>




    </asp:DataList>
    &nbsp;<asp:GridView ID="gv_musicfiles" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gv_musicfiles_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
            <asp:ButtonField CommandName="Select" Text="Assign Music"/>

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



