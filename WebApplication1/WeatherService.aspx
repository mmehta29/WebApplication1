<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeatherService.aspx.cs" Inherits="WebApplication1.WeatherService"  Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <section class="row" aria-labelledby="weatherServiceTitle">
    <h1 id="weatherServiceTitle">Weather Service</h1>
        <p>Get 5 Day Weather Forecast for the entered zip code</p>
    </section>


        <p>
            Enter Zip Code:&nbsp;&nbsp;
            <asp:TextBox ID="zipCodeTB" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="forecastBtn" runat="server" Text="Get Forecast" OnClick="forecastBtn_Click" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server"></asp:Label>
        </p>
        <p>
            Information:
            <br />
            Creator: Carissa Moore
            <br />
            Service: weatherapi.com
            <br />
            GetWeatherForecast (input: zipcode, output: a list of strings, storing 5-day weather forecast for the given zipcode)
        </p>
    </form>


</body>
</html>
