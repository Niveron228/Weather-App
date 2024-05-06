using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Reflection.Emit;
using Newtonsoft.Json;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        private HttpClient httpClient = new HttpClient();
        private string apiKey = Token.ApiKey;
        private string apiUrl;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            label8.Text = $"Weather in {Variables.cobmo_choose}";
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={Variables.cobmo_choose}&appid={apiKey}&units=metric";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                WeatherData data = JsonConvert.DeserializeObject<WeatherData>(responseBody);
                double currentTemp = data.main.temp;
                double maxTemp = data.main.temp_max;
                double minTemp = data.main.temp_min;
                double windSpeed = data.wind.speed;
                int visibility = data.visibility;
                int humidity = data.humidity;

                label3.Text = $"Current Temperature: {currentTemp} °C";
                label4.Text = $"Min Temperature: {minTemp} °C";
                label5.Text = $"Max Temperature: {maxTemp} °C";
                label2.Text = $"Wind speed: {windSpeed} m/s";
                label6.Text = $"Visibility: {visibility} m";
                label7.Text = $"Humidity: {humidity}%";
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error with API: {ex.Message}", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
            this.Close();
  
        }

    }
    

    public class WeatherData
    {
        public MainData main { get; set; }
        public WindData wind { get; set; }
        public CloudData clouds { get; set; }
        public int visibility { get; set; }
        public int humidity { get; set; }
    }

    public class MainData
    {
        public double temp { get; set; }
        public double temp_max { get; set; }
        public double temp_min { get; set; }
    }

    public class WindData
    {
        public double speed { get; set; }
    }

    public class CloudData
    {
        public int all { get; set; }
    }
}
