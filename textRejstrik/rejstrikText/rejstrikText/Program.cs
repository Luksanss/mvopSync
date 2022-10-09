using System.IO;
using System.Text;
using System.Collections.Generic;


namespace rejstrikText;

class Program
{
    public static void Main(string[] args)
    {
        string? lineIndexed;
        string[] lineArr;

        int indexPoll = 0;

        // need to work out later
        string[] forbidenWords = { };

        // for words in sentence
        List<string> wordsInText = new List<string>();

        // dict
        IDictionary<string, List<int>> DictOfWords = new Dictionary<string, List<int>>();

        // need to add more
        char[] forSplit = { ' ', ',', ':', ';', '?', '!', '.'};

        // StreamWriter sw = new StreamWriter("hereShould.txt");



        using (StreamReader sr = new StreamReader("hereShould.txt"))
        {
            while ((lineIndexed = sr.ReadLine()) != null)
            {
                lineArr = lineIndexed.Split(forSplit);
                foreach (string word in lineArr)
                {
                    if (!wordsInText.Contains(word))
                    {
                        wordsInText.Add(word);
                        DictOfWords.Add(word, new List<int>());
                    }
                }
                int index = 0;
                for (int i = 0; i < wordsInText.Count(); i++)
                {
                    while (true)
                    {
                        if (index == -1) { break; }
                        index = lineIndexed.IndexOf(wordsInText[i], index);
                        if (index == -1) { break; }
                        DictOfWords[wordsInText[i]].Add(index + indexPoll);
                        index++;
                    }
                }

                indexPoll += lineIndexed.Length;
            }
        }
        foreach (KeyValuePair<string, List<int>> kvp in DictOfWords)
        {
            Console.Write($"{kvp.Key} nalezeno na indexech: ");
            foreach (int num in kvp.Value)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        Console.ReadKey();


    }
}