namespace TestRecord;

record Client
{
    public string Nom {get; set; } = "";
    public string Prenom {get; set;} = "";
}
class Program
{
    public static void Main()
    {
        Client c1 = new Client();
        c1.Nom = "Test";
        c1.Prenom = "Test2";
        Console.WriteLine(c1.ToString()); // ToString gratuit pour débug

        Client c2 = new Client();
        c2.Nom = "Test";
        c2.Prenom = "Test2";
        Console.WriteLine(c2.ToString());

        // Test l"égalité des données
        if(c1 == c2)
        {
            Console.WriteLine("Données OK");
        }
        else
        {
            Console.WriteLine("Données KO");
        }
    }
}

