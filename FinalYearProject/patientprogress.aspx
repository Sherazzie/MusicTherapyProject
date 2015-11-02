<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="patientprogress.aspx.cs" Inherits="FinalYearProject.patientprogress" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="navbar navbar-inverse navbar-fixed-top headroom">
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
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      
         <table style="margin:0 auto;">
             <tr>
                 <td> <asp:DataList ID="dl_progress" runat="server" Height="348px" Width="401px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" GridLines="Both">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="White" />
                <ItemTemplate>
                    <table>
                        <tr>
                            <td style="float: left;">
                                <asp:Image ID="Image1" runat="server" Height="40px" Width="40px" ImageUrl='<%# Bind("PatientProfileImage") %>' />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="lbl_name" runat="server" Text='<%#Bind("PatientName") %>'></asp:Label></td>
                            <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                        <asp:Image ID="infoimg" runat="server" Height="35px" Width="35px" ImageUrl="~/siteimages/downarrowinfo.png" />
                            </td>

                        </tr>

                    </table>
                    <hr />
                    <br />
                    Appointment Summary:<asp:Label ID="lbl_appsumm" runat="server" Text='<%#Bind("ApptSummary") %>'></asp:Label>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <cc1:HoverMenuExtender ID="HoverMenuExtender1" runat="server" PopupControlID="popupImage" TargetControlID="Image1" OffsetX="10" OffsetY="5" PopupPosition="Right" PopDelay="100" HoverDelay="100">
                    </cc1:HoverMenuExtender>
                    <cc1:HoverMenuExtender ID="HoverMenuExtender2" runat="server" PopupControlID="moreinfo" TargetControlID="infoimg" OffsetX="-115" OffsetY="0" PopupPosition="Bottom" PopDelay="100" HoverDelay="100">
                    </cc1:HoverMenuExtender>
                    <asp:Panel runat="server" ID="popupImage" BorderColor="#628BD7"
                        BorderStyle="Solid" BorderWidth="2px">
                        <asp:Image runat="server" ID="mainImage" Height="150px" Width="150px"
                            ImageUrl='<%# Eval("PatientProfileImage") %>' />
                    </asp:Panel>
                    <asp:Panel runat="server" ID="moreinfo" BorderColor="#628BD7"
                        BorderStyle="Solid" BorderWidth="2px" BackColor="White" Height="130px" Width="150px">
                        Patient IC: 
                        <asp:Label ID="lbl_ic" runat="server" Text='<%#Bind("PatientIC") %>'></asp:Label>
                        <br />
                        <hr class="hrblue" />
                        Appointment Date:<asp:Label ID="lbl_apptdate" runat="server" Text='<%#Bind("ApptDate") %>'></asp:Label>
                    </asp:Panel>
                </ItemTemplate>
                <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            </asp:DataList>

                 </td>
                 <td style="float:right;">
                     
                      <asp:GridView ID="gv_highscores" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>

            <asp:TemplateField HeaderText="Patient Name">
                <ItemTemplate>
                    <asp:Label ID="lbl_patientname" Text='<%#Bind("PatientName") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>



            <asp:TemplateField HeaderText="Patient IC">
                <ItemTemplate>
                    <asp:Label ID="lbl_patientic" Text='<%#Bind("PatientIC") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="HighScore">
                <ItemTemplate>
                    <asp:Label ID="lbl_score" Text='<%#Bind("Score") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Date Played">
                <ItemTemplate>
                    <asp:Label ID="lbl_score" Text='<%#Bind("DateOfScore") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
 

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
                 </td>
             </tr>
         </table>
            
           
   

   
       
    
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

