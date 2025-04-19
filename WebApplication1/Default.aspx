<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Group 127</h1>
            <p class="lead">TODO: introduce what functinality the application offers, how end users can sign up for the services, how the users (TA/grader) can test this application, and what are the test cases/inputs</p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="createAccountTitle">
                <h2 id="createAccountTitle">Create an Account</h2>
                <p>
                    Click here to create an account:   
                    <asp:Button ID="createAccBtn" runat="server" Text="Create an Account" OnClick="createAccBtn_Click" />
                </p>
                <p>
                    &nbsp;</p>
            </section>
        </div>

        <div class="row">
            <section class="col-md-4" aria-labelledby="loginTitle">
                <h2 id="loginTitle">Login</h2>
            <p>
                Click here to login:   
                <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click"/>
            </p>
            <p>
                &nbsp;</p>
        </section>
    </div>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Access Member and Staff Pages</h2>
                <p>If you are not logged in, clicking the &#39;Member&#39; or &#39;Staff&#39; buttons will take you to the login page. If you do not have access to the Staff page, then you will stay on the Default page.</p>
                <p>
                    Access Member Page:
                    <asp:Button ID="MemberBtn" runat="server" OnClick="Button1_Click" Text="Member" />
                </p>
                <p>
                    Access Staff Page:
                    <asp:Button ID="StaffBtn" runat="server" OnClick="StaffBtn_Click" Text="Staff" />
                    <br />
                    <asp:Label ID="result1Lbl" runat="server" />
                </p>
                <p>
                    &nbsp;</p>
            </section>
        </div>

        <div class="row">
            <section class="col=md-4" aria-labelledby="serviceDirTitle">
                <h2 id="serviceDirTitle">Service Directory Table</h2>
                <p>
                    <table border="1" cellpadding="6">
                        <tr style="background-color: #cccccc;">
                            <th>Provider</th>
                            <th>Component Type</th>
                            <th>Operation Name</th>
                            <th>Parameters</th>
                            <th>Return Type</th>
                            <th>Description</th>
                            <th>TryIt Page</th>
                        </tr>
                        <tr>
                            <td>Carissa Moore</td>
                            <td>WSDL service</td>
                            <td>Weather Service</td>
                            <td>String/Int: Zip</td>
                            <td>List of Strings</td>
                            <td>Return a 5 day weather forecast for the entered zip code</td>
                            <td>In &#39;Member&#39; Page or&nbsp;
                                <asp:Button ID="weatherSvcButton" runat="server" Text="Click Here" OnClick="weatherSvcButton_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>Carissa Moore</td>
                            <td>User Control</td>
                            <td>Create Account and Login</td>
                            <td>Two Strings: username and password</td>
                            <td>Access to Member page</td>
                            <td>Create an account and login in order to access the services</td>
                            <td>Available by clicking the Login or Create Account button above</td>
                        </tr>
                        <tr>
                            <td>Carissa Moore</td>
                            <td>Cookies</td>
                            <td>Logout</td>
                            <td>Button click</td>
                            <td>Removes access to Memeber/Staff pages</td>
                            <td>Logs out the user so they are no longer able to access the services</td>
                            <td>Available by clicking the Logout button below</td>
                        </tr>
                    </table>

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
