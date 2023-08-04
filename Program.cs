namespace cSharp_WeatherAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            try
            {
                String baseUrl = "https://api.openweathermap.org/data/2.5/weather";
                String parameters = $"{baseUrl}?q={Uri.EscapeDataString("new york")}&appid=3df7da9e2ea55fc1cf78aa3d743591ea";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage respone = await client.GetAsync(baseUrl);
                    if(respone.IsSuccessStatusCode)
                    {
                        string jsonResponse = await respone.Content.ReadAsStringAsync();
                        Console.WriteLine(jsonResponse);
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