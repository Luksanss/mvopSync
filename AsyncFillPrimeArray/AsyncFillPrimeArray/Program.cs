using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncFillPrimeArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("10-14 mil range: ");
            FillArayWithPrimes(1000000, 1400000);
            Console.WriteLine("faster?");
            RunFour();

            Console.ReadKey();
        }

        public async static void RunFour()
        {
            await Task.Run(() =>
            {
                return FillArayWithPrimes(1000000, 1100000);
            });
            await Task.Run(() =>
            {
                return FillArayWithPrimes(1100000, 1200000);
            });
            await Task.Run(() =>
            {
                return FillArayWithPrimes(1200000, 1300000);
            });
            await Task.Run(() =>
            {
                return FillArayWithPrimes(1300000, 1400000);
            });
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) { return false; }
            if (number == 2) { return true; }
            if (number % 2 == 0) { return false; }

            var boundary = Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        public static List<int> FillArayWithPrimes(int lowerRange, int upperRange)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            List<int> primeArr = new List<int>();

            for (int i = lowerRange; i < upperRange; i++)
            {
                if (IsPrime(i))
                {
                    primeArr.Add(i);
                }
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            return primeArr;
        }
    }
}
