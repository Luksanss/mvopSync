namespace IntegraceDelegate;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Choose func 0-4: ");
        int chosenFunc = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Choose range");

        Console.WriteLine("a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("b: ");

        double b = Convert.ToDouble(Console.ReadLine());

        SomeFunc[] arrOfFuncs = { Sin, Cos2, Square, Cube, Special };

        Console.WriteLine(Integrate(a, b, (SomeFunc) arrOfFuncs[chosenFunc]));

        Console.ReadKey();
    }

    public static double Integrate(double a, double b, SomeFunc f)
    {
        int steps = 1000;
        double step = (b - a) / steps;

        double sum = 0d;

        for (; a < b; a += step)
        {
            sum += f(a) * step;
        }

        return sum;
    }

    public static double Sin(double x) => Math.Sin(x);

    public static double Cos2(double x) => 2 * Math.Cos(x);

    public static double Square(double x) => x * x;

    public static double Cube(double x) => x* x * x;

    public static double Special(double x) => 3 / (x + 1);
    
    public delegate double SomeFunc(double x);
}