namespace getSetTest;

class Program
{
    public static void Main()
    {
        Test bobus = new();

        bobus.MaxLoad = 200;

        Console.WriteLine(bobus.MaxLoad);

        Console.ReadKey();
    }
}

class Test
{
    private double maxLoad;
    public double MaxLoad
    {
        get { return maxLoad;  }
        set {
            Console.WriteLine($"Prirazuji {value}");
            if (value > 0)
            {
                this.maxLoad = value;
            }
            else
            {
                this.maxLoad = 0;
            }
        }
    }
}