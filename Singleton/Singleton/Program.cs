using Singleton;

class Program
{
    static void Main(string[] args)
    {
        HelperSingleton s1 = HelperSingleton.GetInstance();
        HelperSingleton s2 = HelperSingleton.GetInstance();
        
        if (s1 == s2)
        {
            Console.WriteLine("Singleton berjalan");
        }
        else
        {
            Console.WriteLine("Singleton gagal");
        }
        
        Console.WriteLine("---Instance 1");
        s1.addBuku(new Book("Buku Cerita", "hapis"));
        s1.print();
        Console.WriteLine("");
        Console.WriteLine("---Instance 2");
        s2.print();
    }
}