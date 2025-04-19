<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="WebApplication1.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <section class="row" aria-labelledby="memberTitle">
        <h1 id="memberTitle">Member Page</h1>
    </section>

    <div class="row">
    <section class="col-md-4" aria-labelledby="weatherServiceTitle">
        <h2 id="weatherServiceTitle">Weather Service</h2>
        <p>
            Click here to access Weather Service:       
            <asp:Button ID="weatherServiceBtn" runat="server" Text="Weather Service" OnClick="weatherServiceBtn_Click" />
        </p>
        <p>
            &nbsp;</p>
    </section>
</div>
    </form>
</body>
</html>
