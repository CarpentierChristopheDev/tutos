namespace Json2;

public class Program
{
    public static void Main()
    {
        Devis d = DevisFactory.Load("001");
        Console.WriteLine(d.ToString());
        //d.save();
    }
}