namespace ListOfQuests;

class Program
{
    public static void Main(string[] args)
    {
        // a)
        Console.WriteLine(IsEven(2));
        Console.WriteLine(IsEven(3));

        // b)
        Console.WriteLine(IsConvertable("4"));
        Console.WriteLine(IsConvertable("4fd"));

        // c)
        string hey = "hey";
        string hello = "hello";

        Console.WriteLine(hey);
        Console.WriteLine(hello);

        Swap(ref hey, ref hello);

        Console.WriteLine(hey);
        Console.WriteLine(hello);

        // d)
        string[] arr = { "f", "asdf", "asdf", "Luasd" };

        foreach (var elem in GetLengthOfArray(arr))
        {
            Console.Write(elem);
        }

        Console.ReadKey();
    }

    public static bool IsEven(int i)
    {
        return i % 2 == 0;
    }

    public static int IsConvertable(string sentence)
    {
        int.TryParse(sentence, out int res);

        if (res == 0) return int.MinValue;
        return res;
    }

    public static void Swap(ref string s, ref string t)
    {
        (s, t) = (t, s);
    }

    public static int[] GetLengthOfArray(string[] arr)
    {
        int[] arrLen = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            arrLen[i] = arr[i].Length;
        }

        return arrLen;
    }
}