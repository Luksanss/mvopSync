using System.Diagnostics;

namespace WhatDayWasIt;


class Program
{
    public static void Main(string[] args)
    {
        Stopwatch s = new Stopwatch();

        

        DateTime d = new DateTime(1415, 7, 6);

        List<int> dateTimes = new List<int>();

        int year = 1415;

        s.Start();
        
        do
        {
            year++;
            if (new DateTime(year, 7, 6).DayOfWeek == DayOfWeek.Thursday)
            {
                dateTimes.Add(new DateTime(year, 7, 6).Year);
            }
        } while (dateTimes.Count != 5);
        s.Stop();

        Console.WriteLine(d.DayOfWeek);

        foreach (var date in dateTimes)
        {
            Console.WriteLine(date);
        }

        Console.WriteLine($"Next thursday in {new DateTime(dateTimes[0], 7, 6).Subtract(d).Days} days");
        Console.WriteLine($"Calculation took {s.ElapsedMilliseconds} miliseconds");


        Console.ReadKey();
    }
}