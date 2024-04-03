namespace ThirdDegreePolynom;

class Program
{
    public static void Main(string[] args)
    {
        double[] ranges = GetRange();

        List<double> solutions = new List<double>();

        for (double x = ranges[1]; x < ranges[0]; x += 0.0000000001)
        {
            if (CalculateAt(x) == 0)
            {
                solutions.Add(x);
            }
        }

        foreach (var elem in solutions)
        {
            Console.WriteLine(elem);
        }

        Console.ReadKey();
    }

    public static double[] GetRange()
    {
        int iterations = 0;

        double max = 5000;
        double min = -5000;
        do
        {
            iterations++;
            if (CalculateAt(max) > 0 && CalculateAt(min) < 0 || CalculateAt(max) < 0 && CalculateAt(min) > 0)
            {
                max /= 2;
                min /= 2;
            }
            else
            {
                max *= 2;
                min *= 2;
            }
        } while (iterations < 10000);

        return new double[2] { max, min };

    }

    public static double CalculateAt(double x)
    {
        return 3 * Math.Pow(x, 3) + 2 * x * x - 2 * x;
    }
}