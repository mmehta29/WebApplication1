// Carissa Moore (1224352909)
// Web Service Developed in Assingment 3

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace WebApplication1
{
    public partial class WeatherService : System.Web.UI.Page
    {
        string key = "81c9d89a2eb44061b4e174057251904";                 // my api key for the website
        string url = "https://api.weatherapi.com/v1/forecast.json";     // baseUrl for the website
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void forecastBtn_Click(object sender, EventArgs e)
        {
            string zip = zipCodeTB.Text;
            try
            {
                List<string> forecast = await weatherForecast(zip);
                // setting the labels with the forecast for the next 5 days
                Label1.Text = "1.) " + forecast[0];
                Label2.Text = "2.) " + forecast[1];
                Label3.Text = "3.) " + forecast[2];
                Label4.Text = "4.) " + forecast[3];
                Label5.Text = "5.) " + forecast[4];

            }
            catch (Exception ex)        // exception handling
            {
                Label1.Text = ($"{ex.Message}");
            }

        }

        // method to return a list of the 5 day forecast
        protected async Task<List<string>> weatherForecast(string zip)
        {
            using (HttpClient client = new HttpClient())
            {
                string search = $"{url}?key={key}&q={zip}&days=5&aqi=no";
                HttpResponseMessage response = await client.GetAsync(search);  // getting the 5 day forecast

                if (!response.IsSuccessStatusCode)  // exception handling
                {
                    throw new Exception($"{response.StatusCode}");
                }

                string json = await response.Content.ReadAsStringAsync();       // the API returns data as a json object
                JObject data = JObject.Parse(json);

                List<string> forecast = new List<string>();

                foreach (var day in data["forecast"]["forecastday"])        // going through the data and extracting the forecast
                {
                    string date = day["date"].ToString();
                    string condition = day["day"]["condition"]["text"].ToString();
                    string highTemp = day["day"]["maxtemp_f"].ToString();
                    string lowTemp = day["day"]["mintemp_f"].ToString();

                    forecast.Add($"{date}: {condition} with a high of {highTemp}°F and a low of {lowTemp}°F"); // forecast text added to the list
                }

                return forecast;
            }
        }
    }
}
