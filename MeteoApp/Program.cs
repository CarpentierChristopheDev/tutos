using System.Text.Json;

namespace MeteoApp;

class Program
{

    public class MeteoResponse
    {
        public CurrentWeather current_weather {get; set;}
    }
    
    public class CurrentWeather
    {
        public double temperature { get; set; }
        public double windspeed { get; set; }
    }
    
    public static async Task Main()
    {
        // URL pour météo à Paris
        double lat = 48;
        double lon = 2;
        string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true";

        // Http Client
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);

        // Leve une erreur si la réponse ne contient pas un code 2XX
        try {

            response.EnsureSuccessStatusCode();

            // Récupère le contenu de la réponse 
            string jsonString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonString);

            // Désérialise la réponse
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            MeteoResponse meteo = JsonSerializer.Deserialize<MeteoResponse>(jsonString, options);

            // Affichage de la réponse
            Console.WriteLine($"\n >> temperature = {meteo.current_weather.temperature}° - Vitesse vent = {meteo.current_weather.windspeed} Km/h");

        } 
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erreur réseau : {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Erreur de désérialisation JSON : {ex.Message}");
        }

        
    }

}