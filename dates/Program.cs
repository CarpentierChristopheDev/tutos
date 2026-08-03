using System.Globalization;

Console.WriteLine("Travail avec les date uniquement");

DateOnly aujourdhui = DateOnly.FromDateTime(DateTime.Now);
Console.WriteLine($">> aujourd'hui {aujourdhui}");

DateOnly hier = aujourdhui.AddDays(-1);
DateOnly demain = aujourdhui.AddDays(1); 
Console.WriteLine($">> hier {hier} et demain {demain}");

// Valide un format date 
Console.Write($"saisie une date (jj/mm/aaaa): ");
string saisie = Console.ReadLine();

bool estValide = DateOnly.TryParseExact(
    saisie,
    "dd/MM/yyyy",
    CultureInfo.InvariantCulture,
    DateTimeStyles.None,
    out DateOnly date
);

if(estValide)
{
   Console.WriteLine($"Date : {date}");
}
else
{
    Console.WriteLine($"format invalide");
}
