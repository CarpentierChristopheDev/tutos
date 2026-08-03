using System;
using System.IO;

Console.WriteLine("Test Lecture / Ecriture dans un fichier");

Console.WriteLine("- Test Lecture");
string cheminFichier = "texte.txt";
try
{
    string contenu = File.ReadAllText(cheminFichier);
    // ReadAllLines pour avoir en retour un tableau ligne par ligne
    Console.WriteLine(">> Fichier lu : ");
    Console.WriteLine(contenu);
}
catch (FileNotFoundException)
{
    Console.WriteLine("Le fichier n'a pas été trouvé.");
}
catch (IOException ex)
{
    Console.WriteLine($"Erreur de lecture : {ex.Message}");
}

Console.WriteLine("- Test Ecriture");
string cheminFichierEcriture = "texte2.txt";
try
{
    File.WriteAllText(cheminFichierEcriture, "Contenu à écrire àéèê !");
    // WriteAllLines pour écrire un tableau de chaines comme fichier multilignes
    Console.WriteLine(">> Fichier crée.");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Accès refusé au fichier.");
}
catch (IOException ex)
{
    Console.WriteLine($"Erreur d'écriture : {ex.Message}");
}
