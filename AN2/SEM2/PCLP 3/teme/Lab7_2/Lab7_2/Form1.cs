using System;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;

namespace Lab7_2
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        //București
        string lat = "44.4323";
        string lon = "26.1063";
        private async void btnGetWeather_Click(object sender, EventArgs e)
        {

            string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,relative_humidity_2m,wind_speed_10m";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                WeatherResponse weatherData = JsonSerializer.Deserialize<WeatherResponse>(responseBody);

                lblTemp.Text = $"Temperatură: {weatherData.current.temperature_2m} °C";
                lblHumidity.Text = $"Umiditate: {weatherData.current.relative_humidity_2m} %";
                lblWind.Text = $"Vânt: {weatherData.current.wind_speed_10m} km/h";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la preluarea datelor: {ex.Message}");
            }
        }

        private void txtLong_TextChanged(object sender, EventArgs e)
        {
            lon = txtLong.Text;
        }

        private void txtLat_TextChanged(object sender, EventArgs e)
        {
            lat = txtLat.Text;
        }
    }
    public class WeatherResponse
    {
        public CurrentData current { get; set; }
    }

    public class CurrentData
    {
        public double temperature_2m { get; set; }
        public int relative_humidity_2m { get; set; }
        public double wind_speed_10m { get; set; }
    }
}