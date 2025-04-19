<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to Assignment 5 Web Application</h1>

                <hr />
                <p>
                    This web application demonstrates the integration of local components (hashing library, global event handler) 
                    and remote web services (encryption/decryption service) into an ASP.NET Framework architecture. 
                    You can test each component using the TryIt sections below.
                </p>

                <hr />

               <h2>Navigation</h2>

                <asp:Button ID="btnMemberPage" runat="server" Text="Go to Member Page" OnClick="btnMemberPage_Click" />
                <br /><br />
                <asp:Button ID="btnStaffPage" runat="server" Text="Go to Staff Page" OnClick="btnStaffPage_Click" />

                <hr />


                <hr />

                <h2>TryIt - Hashing DLL</h2>

                <asp:Label ID="lblHashInput" runat="server" Text="Enter Text to Hash:" />
                <br />
                <asp:TextBox ID="txtHashInput" runat="server" Width="300px"></asp:TextBox>
                <br /><br />
                <asp:Button ID="btnHashIt" runat="server" Text="Hash It!" OnClick="btnHashIt_Click" />
                <br /><br />
                <asp:Label ID="lblHashResult" runat="server" Text="" />


                <h2>TryIt - Encryption Service</h2>

                <asp:Label ID="lblEncryptInput" runat="server" Text="Enter Text to Encrypt:" />
                <br /><br />
                <asp:TextBox ID="txtEncryptInput" runat="server" Width="300px" />
                <br /><br />
                <asp:Button ID="btnEncrypt" runat="server" Text="Encrypt!" OnClick="btnEncrypt_Click" />
                <br /><br />
                <asp:Label ID="lblEncryptResult" runat="server" Text="" Font-Bold="True" ForeColor="Blue" />


            <hr />
            <h2>Service Directory</h2>

            <table border="1" style="width:100%; text-align:center;">
                <tr>
                    <th>Provider Name</th>
                    <th>Component Type</th>
                    <th>Operation Name</th>
                    <th>Parameters</th>
                    <th>Return Type</th>
                    <th>Description</th>
                    <th>TryIt Button</th>
                </tr>

                <tr>
                    <td>Manya</td>
                    <td>DLL Library</td>
                    <td>ComputeSha256Hash</td>
                    <td>string input</td>
                    <td>string (hashed text)</td>
                    <td>Hashes a string securely using SHA-256.</td>
                    <td><asp:Button ID="btnTryHash" runat="server" Text="Try Hash" OnClick="btnTryHash_Click" /></td>
                </tr>

                <tr>
                    <td>Manya</td>
                    <td>Web Service (WSDL)</td>
                    <td>Encrypt</td>
                    <td>string text, string key, string method</td>
                    <td>string (encrypted text)</td>
                    <td>Encrypts a string using AES encryption method.</td>
                    <td><asp:Button ID="btnTryEncrypt" runat="server" Text="Try Encrypt" OnClick="btnTryEncrypt_Click" /></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
