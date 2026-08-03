using System.Text;
using System.Text.Json; // Package natif

namespace Json2;

public class DevisFactory
{
    public static Devis Load(string pDV_id)
    {
        // Lecture du fichier 
        string jsonDevis = "";
        string jsonDevisFichier = pDV_id + ".json";
        try
        {
            jsonDevis = File.ReadAllText(jsonDevisFichier);
            Console.WriteLine(">> Fichier lu : ");
            Console.WriteLine(jsonDevis);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Le fichier n'a pas été trouvé.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erreur de lecture : {ex.Message}");
        }

        // désérialisation de l'objet 
        Devis? d = JsonSerializer.Deserialize<Devis>(jsonDevis);
        return(d);
    }
}
public class Devis
{
    public string DV_Id {get; set;} = "";
    public string DV_Name {get; set;} = "";

    public Client DV_Client {get; set;} = new Client();

    public List<DevisLigne> DV_Lignes {get; set;} = new List<DevisLigne>();

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Devis : {this.DV_Id} - {this.DV_Name}\n");
        sb.Append($"Client : {this.DV_Client.CL_Id} - {this.DV_Client.CL_Name}\n");
        sb.Append("DevisLignes : \n");
        foreach(DevisLigne dvl in this.DV_Lignes)
        {
            sb.Append($"--> : {dvl.DVL_Id} - {dvl.DVL_Name}\n");
        }
        return(sb.ToString());
    }

    public void save()
    {
        string JsonDevis = JsonSerializer.Serialize(this);
        string jSonDevisFichier = this.DV_Id + ".json";
        try
        {
            File.WriteAllText(jSonDevisFichier, JsonDevis);
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
    }
}

public class Client
{
    public string CL_Id {get; set;} = "";
    public string CL_Name {get; set;} = "";
}

public class DevisLigne
{
    public string DVL_Id {get; set;} = "";
    public string DVL_Name {get; set;} = "";
}

