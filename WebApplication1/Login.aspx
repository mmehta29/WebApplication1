<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Login</h2>
        <br />
        <asp:Label ID="usernameLbl" runat="server" Text="Username:   " />
        <asp:TextBox ID="usernameTb" runat="server" />
        <br />
        <asp:Label ID="passwordLbl" runat="server" Text="Password:    " />
        <asp:TextBox ID="passwordTb" runat="server" />
        <br />
        <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click" />
        <div>
            <asp:Label ID="resultLbl" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
