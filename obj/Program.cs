using obj.dto;

namespace obj;

public class Obj {
    public static void Main()
    {
        Clients l1 = new Clients();
        l1.Add("Carpentier", "Christophe", 1978);
        l1.Add("Bourgoin", "Blandine", 1968);
        
        Console.WriteLine(l1);

        Console.WriteLine(l1.Get(2));       
    }
}

    

