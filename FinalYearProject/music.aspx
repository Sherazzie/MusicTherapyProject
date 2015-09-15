<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="music.aspx.cs" Inherits="FinalYearProject.music" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>Upload file</td>
            <td><asp:FileUpload ID="fu_upload" runat="server" /></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:button ID="btn_upload" runat="server" text="upload" OnClick="btn_upload_Click" /></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            
         </tr>
        <tr>
            <td></td>
            <td><asp:Label ID="lbl_result" runat="server" ></asp:Label></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
