namespace MonteKarloIntegrace;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("How many rectangles?: ");
        double rectangleCount = Convert.ToDouble(Console.ReadLine());

        // func area limit
        double a = 2;
        double b = 3;

        double x = 1.0 / rectangleCount;

        double y;

        // 6.33

        double sum = 0;
        
        for (; a < b; a += 1.0/rectangleCount)
        {
            y = a * a;
            sum += y * x;
        }

        Console.WriteLine(sum);

        Console.ReadKey();
    }


}