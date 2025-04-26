<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="WebApplication1.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <form id="form1" runat="server">
        <section class="row" aria-labelledby="staffTitle">
            <h1 id="staffTitle">Staff Page</h1>
            <asp:Label ID="welcomeLbl" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
        </section>
        <div class="row">
            <section class="col-md-4" aria-labelledby="addStaffTitle">
                <h2 id="addStaffTitle">Add Staff</h2>
                <p>
                    Enter Username:
                    <asp:TextBox ID="usernameTb" runat="server"></asp:TextBox>
                </p>
                <p>
                    Enter Password:
                    <asp:TextBox ID="passwordTb" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="addStaffBtn" runat="server" Text="Add Staff" OnClick="addStaffBtn_Click" />
                </p>
                <p>
                    <asp:Label ID="resultLbl" runat="server"></asp:Label>
                </p>
            </section>
        </div>

        <div class="row">
            <section class="col-md-4" aria-labelledby="listStaffTitle">
                <h2 id="listStaffTitle">List Staff</h2>
                <p>
                    Click here to List Staff:&nbsp;&nbsp;
                    <asp:Button ID="listStaffBtn" runat="server" Text="List Staff" OnClick="listStaffBtn_Click" />
                </p>
                <p>
                    <asp:ListBox ID="staffLb" runat="server"></asp:ListBox>
                </p>
            </section>
        </div>

    </form>
</body>
</html>
