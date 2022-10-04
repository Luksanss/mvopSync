using System.Globalization;

namespace centrovanyNadpis;

class Program
{
    public static void Main()
    {
        Console.Write("Nadpis: ");
        string nadpis = Console.ReadLine();

        Console.Write("Vyska: ");
        int height = Convert.ToInt32(Console.ReadLine());

        Console.Write("Sirka: ");
        int width = Convert.ToInt32(Console.ReadLine());


        // now run the func with input params
        Hlavicka(width, height, nadpis);
    }

    public static void Hlavicka(int width, int height, string nadpis)
    {
        Console.Write("Znak pro vysku hlavicky: ");
        char forHeight = Console.ReadLine()[0];
        
        Console.Write("Znak pro sirku hlavicky: ");
        char forWidth = Console.ReadLine()[0];
        
        Console.Write("Znak pro roh hlavicky: ");
        char corner = Console.ReadLine()[0];
      
        Console.WriteLine();

        DateTime time = new DateTime();

        Width(width, forWidth, corner);

        Fill(height, width, forHeight);

        Nadpis(width, forHeight, nadpis);

        Fill(height, width, forHeight, time);

        Width(width, forWidth, corner);

        Console.ReadKey();


    }

    public static void Width(int width, char forWidth, char corner)
    {

        Console.Write(corner);

        for (int i = 0; i < (width - 2); i++)
        {
            Console.Write(forWidth);
        }

        Console.Write($"{corner}\n");
    }

    public static void Fill(int height, int width, char forHeight)
    {
        for (int n = 0; n < (height - 1) / 2; n++)
        {
            Console.Write(forHeight);

            for (int i = 0; i < (width - 2); i++)
            {
                Console.Write(" ");
            }
            Console.Write($"{forHeight}\n");
        }

    }
    public static void Fill(int height, int width, char forHeight, DateTime time)
    {
        CultureInfo cultureinfo = new CultureInfo("cs-CZ");
        Thread.CurrentThread.CurrentCulture = cultureinfo;
        string dateNow = $"{DateTime.Today:dd}. {DateTime.Today:MMMM yyyy}";

        Console.Write(forHeight);
        for (int n = 0; n < (height - 1) / 2 - 1; n++)
        {
            for (int i = 0; i < (width - 2); i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(forHeight);
        }
        Console.Write(forHeight);

        for (int i = 0; i < width - (dateNow.Length + 2); i++)
        {
            Console.Write(" ");
        }
        Console.Write(dateNow);
        Console.WriteLine(forHeight);


    }

    public static void Nadpis(int width, char forHeight, string nadpis)
    {
        int diff;

        if ((nadpis.Length % 2 != 0 && width % 2 == 0) || (nadpis.Length % 2 == 0 && width % 2 != 0))
        {
            diff = 1;
        }
        else
        {
            diff = 0;
        }

        width -= nadpis.Length;



        Console.Write(forHeight);

        for (int i = 0; i < (width - 2) / 2; i++)
        {
            Console.Write(" ");
        }

        Console.Write(nadpis);

        for (int i = 0; i < (width - 2) / 2 + diff ; i++)
        {
            Console.Write(" ");
        }

        Console.Write($"{forHeight}\n");
    }

}