using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace cSharp_WeatherAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            try
            {
                String baseUrl = "http://api.openweathermap.org/data/2.5/weather?q=Muscat,om&APPID=a768c37a2a9a1b8f2a07bef5d0409c2d";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage respone = await client.GetAsync(baseUrl);
                    if(respone.IsSuccessStatusCode)
                    {
                        string jsonResponse = await respone.Content.ReadAsStringAsync();
                        WeatherClass weatherData = JsonConvert.DeserializeObject<WeatherClass>(jsonResponse);
                        Console.WriteLine(jsonResponse);
                    }
                    else
                    {
                        Console.WriteLine("Failed to get data");
                    }
                }
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}