using System;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        string cheminFichier = "personnes.xml";

        try
        {
            XDocument doc = XDocument.Load(cheminFichier);

            foreach (var personne in doc.Descendants("Personne"))
            {
                string? nom = personne.Element("Nom")?.Value;
                string? age = personne.Element("Age")?.Value;
                Console.WriteLine($"Nom : {nom}, Âge : {age}");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Fichier XML introuvable.");
        }
        catch (System.Xml.XmlException ex)
        {
            Console.WriteLine($"Erreur de format XML : {ex.Message}");
        }

    }
}