using ClosedXML.Excel; // Bibliothéque externe

Console.WriteLine("Test création de fichier Excel");

using var workbook = new XLWorkbook();
var worksheet = workbook.Worksheets.Add("Feuille1");

// En-têtes
worksheet.Cell(1, 1).Value = "Nom";
worksheet.Cell(1, 2).Value = "Âge";

// Données
worksheet.Cell(2, 1).Value = "bob";
worksheet.Cell(2, 2).Value = 30;

worksheet.Cell(3, 1).Value = "Cécile";
worksheet.Cell(3, 2).Value = 25;

// Mise en forme (optionnel)
worksheet.Row(1).Style.Font.Bold = true;
worksheet.Columns().AdjustToContents();

try {
    Console.WriteLine(">> Création du fichier Excel");
    workbook.SaveAs("monfichier.xlsx"); 
}
catch (IOException ex)
{
    // Fichier ouvert dans Excel, ou chemin invalide
    Console.WriteLine($"Erreur d'accès au fichier : {ex.Message}");
}
catch (UnauthorizedAccessException ex)
{
    // Droits insuffisants sur le dossier/fichier
    Console.WriteLine($"Accès refusé : {ex.Message}");
}
catch (Exception ex)
{
    // Toute autre erreur inattendue
    Console.WriteLine($"Erreur inattendue : {ex.Message}");
}
