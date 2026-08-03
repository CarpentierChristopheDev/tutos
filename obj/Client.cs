using System.ComponentModel;
using System.Text;

namespace obj.dto;

public class Client
{
    public int    Id{get;}
    private string Nom {get;}
    private string Prenom {get;}
    private int    AnNaissance {get;}

    public Client(int pId, string pNom, string pPrenom, int pAnNaissance)
    {
        this.Id = pId;
        this.Nom = pNom;
        this.Prenom = pPrenom;
        this.AnNaissance = pAnNaissance;
    }    

    private int age()
    {
        int anneeActuelle = DateTime.Now.Year;
        return(anneeActuelle - this.AnNaissance);
    }
    public override string ToString()
    {
        return($"{this.Id} {this.Nom} {this.Prenom} {this.age()}");
    }
}

public class Clients
{
    private List<Client> ClientsListItems = new List<Client>();

    public void Add(string pNom, string pPrenom, int pAnNaissance)
    {
        int id = ClientsListItems.Count + 1;
        Client newClient = new Client(id, pNom, pPrenom, pAnNaissance);
        ClientsListItems.Add(newClient);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach(Client ClientItem in this.ClientsListItems) {
            sb.Append(ClientItem.ToString() + "\n"); 
        }
        return(sb.ToString());
    }

    public string Get(int pId)
    {
        Client ClientTrouve = this.ClientsListItems.Find(client => client.Id == pId);
        return(ClientTrouve.ToString()+"\n");
    }
}