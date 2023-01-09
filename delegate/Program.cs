namespace f;

class Program
{

    public delegate int AddInt(int a);
    public static int Add5(int a)
    {
        Console.Write("Add5 ");
        return a + 5;
    }
    public static int Add10(int a)
    {
        Console.Write("Add10 ");
        return a + 10;
    }
    public static void Main(string[] args)
    {
        AddInt fi, sumFi = null;
        fi = Add5;
        Console.WriteLine(fi(3)); // Add5 8
        sumFi += fi;
        fi = Add10;
        Console.WriteLine(fi(3)); // Add10 13
        sumFi += fi;
        Console.WriteLine(sumFi(3)); // Add5 Add10 13
        Console.ReadKey();
    }
}
