using System.Text.Json;

string json = """
{
  "nom": "Alice",
  "age": 30,
  "adresse": {
    "ville": "Paris",
    "codePostal": "75000"
  },
  "hobbies": ["lecture", "vélo", "musique"]
}
""";
Console.WriteLine(json);

// Parsing sans desérialisation
using JsonDocument doc = JsonDocument.Parse(json);
JsonElement root = doc.RootElement;

// Accéder à une propriété simple
string nom = root.GetProperty("nom").GetString();
Console.WriteLine($"Nom : {nom}");

int age = root.GetProperty("age").GetInt32();
Console.WriteLine($"Age : {age}");

// Accéder à un objet imbriqué
JsonElement adresse = root.GetProperty("adresse");
string ville = adresse.GetProperty("ville").GetString();
string cp = adresse.GetProperty("codePostal").GetString();
Console.WriteLine($"CP : {cp} - Ville : {ville}");

// Parcourir un tableau
Console.WriteLine($"Hobbies : ");
foreach (JsonElement hobby in root.GetProperty("hobbies").EnumerateArray())
{
    Console.WriteLine("- " + hobby.GetString());
}
