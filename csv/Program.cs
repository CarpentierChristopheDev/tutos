using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace testCsvHelper;


public record Personne
{
    public string Nom { get; set; } = "";
    public int Age { get; set; }
    public string Ville { get; set; } = "";
    public double Salaire { get; set; }
}

class Program
{
    public static void Main()
    {
        TestCsvEcriture();
        TestCsvLecture();
    }

    public static void TestCsvEcriture()
    {
        Console.WriteLine("Test d'écriture");

        var personnes = new List<Personne>
        {
            new Personne { Nom = "Alice", Age = 30, Ville = "Paris", Salaire = 3500.50 },
            new Personne { Nom = "Bob", Age = 25, Ville = "Lyon", Salaire = 2800.75 },
        };

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
        };

        using var writer = new StreamWriter("data.csv");
        using var csv = new CsvWriter(writer, config);

        csv.WriteRecords(personnes);
    }

    public static void TestCsvLecture()
    {
        
        Console.WriteLine("Test de lecture");

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            HasHeaderRecord = true,
        };

        using var reader = new StreamReader("data.csv");
        using var csv = new CsvReader(reader, config);

        try
        {
            var personnes = csv.GetRecords<Personne>().ToList();
            foreach (var p in personnes)
            {
                Console.WriteLine($"{p.Nom} ({p.Age} ans, {p.Ville}) — Salaire : {p.Salaire.ToString(CultureInfo.InvariantCulture)}");
            }
        }
        catch (CsvHelperException ex)
        {
            Console.WriteLine($"Erreur de parsing CSV : {ex.Message}");
        }
        
    }

}



