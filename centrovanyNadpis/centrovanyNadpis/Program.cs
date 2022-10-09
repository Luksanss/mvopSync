using System.Globalization;

namespace centrovanyNadpis;

class Program
{
    public static void Main()
    {
        // setting czech culture info
        CultureInfo cultureinfo = new CultureInfo("cs-CZ");
        Thread.CurrentThread.CurrentCulture = cultureinfo;
        // getting cur date
        string dateNow = $"{DateTime.Today:dd}. {DateTime.Today:MMMM yyyy}";

        Console.Write("Nadpis: ");
        string nadpis = Console.ReadLine();


        int height = 0;
        // force user to enter right height
        while (height == 0)
        {
            height = GetHeight();
        }

        int width = 0;
        // force user to enter the right width
        while (width == 0)
        {
            width = GetWidth(dateNow.Length, nadpis.Length);
        }


        // now run the func with input params
        Hlavicka(width, height, nadpis, dateNow);
    }


    public static int GetWidth(int dateSize, int nadpisSize)
    {
        Console.Write("Sirka: ");
        int width = Convert.ToInt32(Console.ReadLine());

        if (width < (dateSize + 2) || width < (nadpisSize + 2))
        {
            Console.WriteLine("Nedostatecna sirka");
            return 0;
        }
        else
        {
            return width;
        }
    }

    public static int GetHeight()
    {
        Console.Write("Vyska: ");
        int height = Convert.ToInt32(Console.ReadLine());

        if (height < 3)
        {
            Console.WriteLine("Vyska musi byt minimalne 3");
            return 0;
        }
        else
        {
            return height;
        }
    }


    public static void Hlavicka(int width, int height, string nadpis, string dateNow)
    {
        Console.Write("Znak pro vysku hlavicky: ");
        char forHeight = Console.ReadLine()[0];
        
        Console.Write("Znak pro sirku hlavicky: ");
        char forWidth = Console.ReadLine()[0];
        
        Console.Write("Znak pro roh hlavicky: ");
        char corner = Console.ReadLine()[0];
      
        Console.WriteLine();

        // Printing the result
        Width(width, forWidth, corner);

        Fill(height, width, forHeight);

        Nadpis(width, forHeight, nadpis);

        Fill(height, width, forHeight, dateNow);

        Width(width, forWidth, corner);

        Console.ReadKey();

    }

    public static void Width(int width, char forWidth, char corner)
    {
        // Prints the top and bottom border
        Console.Write(corner);

        for (int i = 0; i < (width - 2); i++)
        {
            Console.Write(forWidth);
        }

        Console.Write($"{corner}\n");
    }

    public static void Fill(int height, int width, char forHeight)
    {
        // fills the lines between top and bottom border
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
    public static void Fill(int height, int width, char forHeight, string dateNow)
    {
        // overload for Fill -> Fills, but also adds right-centered current date
        Console.Write(forHeight);
        for (int n = 0; n < (height - 1) / 2 - 1; n++)
        {
            for (int i = 0; i < (width - 2); i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(forHeight);
            Console.Write(forHeight);
        }


        for (int i = 0; i < width - (dateNow.Length + 2); i++)
        {
            Console.Write(" ");
        }
        Console.Write(dateNow);
        Console.WriteLine(forHeight);


    }

    public static void Nadpis(int width, char forHeight, string nadpis)
    {
        // Prints the middle part with name
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