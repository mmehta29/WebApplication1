<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HashService.aspx.cs" Inherits="WebApplication1.HashService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <section class="row" aria-labelledby="hashServiceTitle">
            <h1 id="hashServiceTitle">Hash Service TryIt</h1>
            <p>Enter Text to Hash:
                <asp:TextBox ID="txtHashInput" runat="server"></asp:TextBox>
            </p>
            <p />

                <asp:Button ID="btnHashIt" runat="server" Text="Hash It!" OnClick="btnHashIt_Click" />

            <p />

                <asp:Label ID="lblHashResult" runat="server"></asp:Label>

        </section>
    </form>
</body>
</html>
