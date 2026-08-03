using System.Globalization;
public class Program
{
    public static void Main()
    {
        int age = SaisirAge();
        Console.WriteLine($"Âge accepté : {age}");

        double poids = SaisirPoids();
        Console.WriteLine($"Poid valide : {poids.ToString(CultureInfo.InvariantCulture)}");
        // CultureInfo.InvariantCulture pour ne pas tenir compte de la culture régional et convertir vers format décimal avec '.'
    }

    public static int SaisirAge()
    {
        int age;
        do
        {
            Console.Write("Entrez un âge valide (1-120), un entier : ");            
        } while (!int.TryParse(Console.ReadLine(), out age) || age < 1 || age > 120);
        // BOUCLE SI la conversion ne fonctionne pas ou que l'age soit <1 ou que l'age soit>120   
        return(age);
    }

    public static double SaisirPoids()
    {
        double poids;
        do
        {
           Console.Write("Entrez un poid valide (1-120) utilisez '.' comme séparateur décimal : "); 
        } while (!double.TryParse(
            Console.ReadLine(),
            NumberStyles.Float,            // Utilisation de la virgule = ECHEC  
            CultureInfo.InvariantCulture,  // Ne tiens pas compte de la culture régionale, SEPARATEUR = "."
            out poids) || poids < 1 || poids > 120);
        return(poids);
    }
}


