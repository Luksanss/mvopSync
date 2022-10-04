using System.Text;

namespace stringRegex;

class Program
{
    public static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Numbers: ");

        for (int i = 0; i < 200_000; i++)
        {
            sb.Append(i);
        }

        Console.WriteLine(sb);

        Console.ReadKey();

    }
}