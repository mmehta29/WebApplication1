<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Group 127</h1>
            <p class="lead">This application allows users to create an account and access weather forecast and encryption services. To get started, create an account below.
                For access to Staff page, use Username: &#39;TA&#39; and Password: &#39;Cse445!&#39;</p>
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
        <br />

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
                        <tr>
                            <td>Carissa Moore</td>
                            <td>User control</td>
                            <td>Image verifier captcha</td>
                            <td>String: enteredCaptcha</td>
                            <td>Verifies that the user correctly entered the captcha and allows them to create an account if correct</td>
                            <td>Generates an image verifier and prompts the user to enter the string that it shows</td>
                            <td>Located in the 'Create Account' Page</td>
                        </tr>
                        <tr>
                            <td>Manya</td>
                            <td>DLL Library</td>
                            <td>ComputeSha256Hash</td>
                            <td>string input</td>
                            <td>string (hashed text)</td>
                            <td>Hashes a string securely using SHA-256.</td>
                            <td>
                                <asp:Button ID="encryptionTryItBtn" runat="server" OnClick="encryptionTryItBtn_Click" Text="Click Here" />
                            </td>
                        </tr>

                        <tr>
                           <td>Manya</td>
                           <td>Web Service (WSDL)</td>
                           <td>Encrypt</td>
                           <td>string text, string key, string method</td>
                           <td>string (encrypted text)</td>
                           <td>Encrypts a string using AES encryption method.</td>
                           <td>In &#39;Memeber&#39; Page</td>
                        </tr>
                        
                    </table>

                </p>
            </section>
        </div>
        <div class="row">
    <section class="col-md-4" aria-labelledby="logoutTitle">
        <h2 id="logoutTitle">&nbsp;</h2>
        <h2>Logout</h2>
        <p>
            Click here to logout:   
            <asp:Button ID="logoutBtn" runat="server" Text="Logout" OnClick="logoutBtn_Click" />
            <br />
            <asp:Label ID="resultLbl" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
    </section>
</div>

    </main>

</asp:Content>
