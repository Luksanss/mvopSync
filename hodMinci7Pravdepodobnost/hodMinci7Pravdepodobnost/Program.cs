namespace hodMinci7Pravdepodobnost;

class Program
{
    public static void Main(string[] args)
    {
        Random hodMinci = new Random();

        int sevenOcc = 0;

        int itHappened = 0;

        int run = 1000;

        for (int n = 0; n < run; n++)
        {
            for (int i = 0; i < 100; i++)
            {
                if (hodMinci.Next(0, 2) == 0)
                {
                    sevenOcc++;
                    if (sevenOcc == 7)
                    {
                        itHappened++;
                        sevenOcc = 0;
                    }
                }
                else
                {
                    sevenOcc = 0;
                }
            }
        }


        Console.WriteLine($"The same side of a coin occured {itHappened} times (of {run} sets), probability of occurance {(itHappened * 100.0) / run}%");

        Console.ReadKey();
    }
}