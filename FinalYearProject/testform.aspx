<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testform.aspx.cs" Inherits="FinalYearProject.testform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CssStyles/style.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="login-card">
    <h1>Log-in</h1>
    <br />
  
    <input type="text" name="user" placeholder="Username" />
    <input type="password" name="pass" placeholder="Password" />
    <input type="submit" name="login" class="login login-submit" value="login" />
  
    
  <div class="login-help">
    <a href="#">Register</a> • <a href="#">Forgot Password</a>
  </div>
</div>

<!-- <div id="error"><img src="https://dl.dropboxusercontent.com/u/23299152/Delete-icon.png" /> Your caps-lock is on.</div> -->
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
<script src='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js'></script>

    </div>
    </form>
</body>
</html>
