namespace sumaceFaktorial;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Factorial(6));

        Console.WriteLine(SumFact(2, 4));

        Console.ReadKey();
    }

    public static double SumFact(int x, int n)
    {
        double sum = 1;

        bool substract = false;

        for (int i = 1; i < n + 1; i++)
        {
            if (!substract)
            {
                sum += Math.Pow(x, i) / Factorial(i);
                substract = true;
            }
            else
            {
                sum -= Math.Pow(x, i) / Factorial(i);
                substract = false;
            }
            
        }

        return sum;
    }

    public static int Factorial(int n)
    {
        int result = 1;

        int tempN = n;
        while (tempN > 0)
        {
            result *= tempN;
            tempN--;
        }

        return result;
    }
}