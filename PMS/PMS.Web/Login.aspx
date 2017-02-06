<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PMS.Web.Login" %>
<!DOCTYPE html>
<html >
<head>
  <meta charset="UTF-8">
  <title>Login Form</title>
      <link rel="stylesheet" href="Content/PMSStyle.css">
</head>

<body>
  <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro' rel='stylesheet' type='text/css'>
<form runat="server">
  <h4> Login Information </h4>
  <asp:TextBox runat="server"  CssClass="name" ID="txtUserName" placeholder="Enter Username"/>
  <asp:TextBox runat="server" CssClass="pw" TextMode="Password" ID="txtPassword" placeholder="Enter Password"/>
  <li><a href="#">Forgot your password?</a></li>
  <asp:Button CssClass="button" runat="server" ID="btnLogin" Text="Log in" OnClick="btnLogin_Click"/>
    <br />
    <br />
    <br />
    <br />
    <p>
      <asp:Label ID="Msg" ForeColor="red" runat="server" />
    </p>
</form>
  
  
</body>
</html>