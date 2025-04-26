<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="WebApplication1.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Memeber Page</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <section class="row" aria-labelledby="memberTitle">
                <h1 id="memberTitle">Member Page</h1>
                <asp:Label ID="welcomeLbl" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
            </section>
            <div class="row">
                <section class="col-md-4" aria-labelledby="weatherServiceTitle">
                    <h2 id="weatherServiceTitle">Weather Service</h2>
                <p>
                    Click here to access Weather Service:       
                    <asp:Button ID="weatherServiceBtn" runat="server" Text="Weather Service" OnClick="weatherServiceBtn_Click" />
                </p>
                </section>
            </div>

            <div class="row">
                <section class="col-md-4" aria-labelledby="encryptionServiceTitle">
                    <h2 id="encryptionServiceTitle">Encryption Service</h2>
                    <p>
                        Enter Text to Encrypt:  
                        <p />
                            <asp:TextBox ID="txtEncryptInput" runat="server"></asp:TextBox>
                        <p />
                        <asp:Button ID="btnTryEncrypt" runat="server" Text="Encrypt!" OnClick="btnTryEncrypt_Click" />
                    </p>
                    <p />
                        <asp:Label ID="lblEncryptResult" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                    </p>
                </section>
            </div>
        </form>
    </body>
</html>
