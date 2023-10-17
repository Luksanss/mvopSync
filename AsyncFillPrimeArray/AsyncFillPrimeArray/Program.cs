using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncFillPrimeArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.Write("10-14 mil range: ");
            FillArayWithPrimes(1000000, 1400000);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);


            Console.WriteLine("faster?");
            RunFour();

            Console.ReadKey();
        }

        public async static void RunFour()
        {
            Task t1 = Task.Run(() => FillArayWithPrimes(1000000, 1100000));
            Task t2 = Task.Run(() => FillArayWithPrimes(1100000, 1200000));
            Task t3 = Task.Run(() => FillArayWithPrimes(1200000, 1300000));
            Task t4 = Task.Run(() => FillArayWithPrimes(1300000, 1400000));
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();


            await Task.WhenAll(t1, t2, t3, t4);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

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

            List<int> primeArr = new List<int>();

            for (int i = lowerRange; i < upperRange; i++)
            {
                if (IsPrime(i))
                {
                    primeArr.Add(i);
                }
            }
            return primeArr;
        }
    }
}
