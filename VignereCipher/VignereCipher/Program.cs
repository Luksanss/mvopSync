// text = "hey cipher"
// key = "asdf"

// for loop on text
// for loop used on text is used on key as well
namespace VignereCipher;

class Program
{
    public static void Main(string[] args)
    {
        string text = "hey ciphter";
        string key = "asdf";

        byte[] newText = new byte[text.Length];

        int indexerForKey = 0;
        for (int i = 0; i < text.Length; i++)
        {
            newText[i] = (byte) (text[i] ^ key[indexerForKey]);

            if (indexerForKey < key.Length - 1) indexerForKey++;
            else indexerForKey = 0;
        }
        Console.WriteLine(System.Convert.ToBase64String(newText));

        Console.ReadKey();
    }
}