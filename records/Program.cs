namespace TestRecord;

// Constructeur et destructeur en 1 seule ligne 
record Client(string Nom, string Prenom);
class Program
{
    public static void Main()
    {
        Console.WriteLine("Travail sur les records"); 

        Client c1 = new Client("Test", "Test2"); // Constructeur automatique
        Console.WriteLine($"c1 : {c1.ToString()}"); // ToString automatique pour débug

        Client c2 = new Client("Test", "Test2");
        Console.WriteLine($"c2 : {c2.ToString()}");

        // Test l"égalité par valeur automatique
        Console.Write("Test d'égalité ( c1 == c2 ) : ");
        if(c1 == c2)
        {
            Console.WriteLine("Egalité sur les valeurs");
        }
        else
        {
            Console.WriteLine("Pas d'égalité sur les valeurs");
        }
    }
}

