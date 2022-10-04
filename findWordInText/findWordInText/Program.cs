namespace stringRegex;

class Program
{
    public static void Main(string[] args)
    {
        string mujTest1 = "C#, ke velmi C# ff C#";
        string keyWord = "C#";
        int index = mujTest1.IndexOf(keyWord);
        int found = 0;
        while (index != -1)
        {
            Console.WriteLine($"{keyWord} found at index {index}");
            index = mujTest1.IndexOf("C#", index + 1);
            found++;
        }

        Console.WriteLine($"Word: {keyWord} found {found} times in text: \"{mujTest1}\"");

        Console.ReadKey();
    }
}