using System.Text.RegularExpressions;

namespace FindTCPIP;

class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            throw new Exception("No file given");
        }

        Regex r = new Regex("^\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}$");


        //List<int> lineWithIP = new List<int>();
        //List<string> matches = new List<string>();

        Dictionary<int, string> matches = new();

        try
        {
            using (StreamReader read = new StreamReader(args[0]))
            {
                string line = read.ReadLine();
                int counter = 0;

                while (line != null)
                {
                    if (r.IsMatch(line))
                    {

                        foreach (string word in line.Split(" "))
                        {
                            if (r.IsMatch(word)) matches.Add(counter, word);
                        }
                    }

                    counter++;
                    line = read.ReadLine();
                }
            }
        }
        catch
        {
            throw new Exception("Error while reading a file");
        }



        Console.WriteLine("Found on lines: ");
        foreach (int key in matches.Keys)
        {
            Console.WriteLine($"{key} {matches[key]}");
        }

        Console.ReadKey();
    }
}