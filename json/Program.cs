using System.Text.Json; // Package natif

namespace JSON;

public class Client
{
    public string? nom {get; set;}
    public string? prenom {get; set;} 
    
}

public class Program {
    public static void Main()
    {
        
        Console.WriteLine("Test sérialisation/désérialisation JSON");
        Client? c1 = new Client();

        string jsonStringIn = "{\"nom\":\"Carpentier\",\"prenom\":\"Christophe\"}"; 
        Console.WriteLine(jsonStringIn); 

        Console.WriteLine("- Désérialisation de la chaine JSON vers l'objet Client"); 
        c1 = JsonSerializer.Deserialize<Client>(jsonStringIn);

        Console.WriteLine("- Lecture des données de l'instance de Client");
        Console.WriteLine($"{c1?.nom} {c1?.prenom}"); 

        Console.WriteLine("- Sérialisation de l'instance de Client en chaine JSON"); 
        string jsonStringOut = JsonSerializer.Serialize(c1);
        Console.WriteLine(jsonStringOut);

    }

    
}
