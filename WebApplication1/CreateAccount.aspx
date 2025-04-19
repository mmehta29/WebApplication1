<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="WebApplication1.CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create an Account</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Create an Account</h2>
        <br />
        <asp:Label ID="usernameLbl" runat="server" Text="Username:   " />
        <asp:TextBox ID="usernameTb" runat="server" />
        <br />
        <asp:Label ID="passwordLbl" runat="server" Text="Password:    " />
        <asp:TextBox ID="passwordTb" runat="server" />
        <br />
        <asp:Label ID="repassLbl" runat="server" Text="Re-Enter Password:    " />
        <asp:TextBox ID="repassTb" runat="server" />
<br />
        <asp:Button ID="createAccountBtn" runat="server" Text="Create Account" OnClick="createAccountBtn_Click" />
 <br />
        <div>
             <asp:Label ID="resultLbl" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
