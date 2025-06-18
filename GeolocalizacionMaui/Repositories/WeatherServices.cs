using CoreImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeolocalizacionMaui.Models;

namespace GeolocalizacionMaui.Repositories
{
    
    public class WeatherServices
    {
        public async Task<WeatherData> GetWeatherDataAsync( double latitude, double longitude)
        {
            string latitude_str = latitude.ToString().Replace(",",".");
            string longitude_str = longitude.ToString().Replace(",", ".");
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude_str}&longitude={longitude_str}&current=temperature_2m,relative_humidity_2m,rain";
            //https://api.open-meteo.com/v1/forecast?latitude=46.9481&longitude=7.4474&current=temperature_2m,relative_humidity_2m,rain
            //HttpClient httpClient = new HttpClient();
            using (HttpClient client = new HttpClient()) 
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();//Dispara la excepcion numerica.
                var result = await response.Content.ReadAsStringAsync();
            }
        }
    }

}
