using System.Collections.Generic;

namespace realMonteCarlo;

class Program
{
    public static void Main(string[] args)
    {
        Random randomNext = new Random();

        int[] sumPool = new int[100_000];

        IDictionary<int, int> occuranceOfNumSums = new Dictionary<int, int>();

        // inicializace dictionary: hodnoty od 6 do 36 na nule
        for (int i = 6; i <= 36; i++)
        {
            occuranceOfNumSums[i] = 0;
        }


        int sum = 0;

        // generace 100 000 čísel

        for (int i = 0; i < 100_000; i++)
        {
            for (int index = 0; index < 6; index++)
            {
                sum += randomNext.Next(1, 7);
            }
            sumPool[i] = sum;
            occuranceOfNumSums[sum]++;
            sum = 0;
        }

        // výpočet četnosti součtů (kolikrát byl jaký počet)


        foreach (KeyValuePair<int, int> kvp in occuranceOfNumSums)
        {
            Console.WriteLine($"Probability for {kvp.Key}: {((double)kvp.Value / 100_000) * 100}%");
        }


        Console.ReadKey();
    }

}