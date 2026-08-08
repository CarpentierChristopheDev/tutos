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
        Console.WriteLine(c1.ToString());
    }
}

