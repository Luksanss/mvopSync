namespace VignereCipherReal;

class Program
{
    public static void Main(string[] args)
    {
        string text = "text";
        string key = "hey";

        string newText = "";

        int indexOfKey = 0;
        for (int i = 0; i < text.Length; i++)
        {
            newText += CaesarCipher(Char.ToString(text[i]), getShift(text[i], key[indexOfKey]), false);

            if (indexOfKey < key.Length - 1) indexOfKey++;
            else indexOfKey = 0;
        }

        Console.WriteLine(newText);
        Console.ReadKey();
    }

    public static int getShift(char textLetter, char keyLetter)
    {
        char[] alphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        return Math.Abs(Array.IndexOf(alphabetUpper, char.ToUpper(textLetter)) - Array.IndexOf(alphabetUpper, char.ToUpper(keyLetter)));
    }

    public static string CaesarCipher(string text, int shiftValue, bool deCipher)
    {
        if (deCipher)
        {
            shiftValue *= -1;
        }

        string shiftedWord = "";
        foreach (char letter in text)
        {
            shiftedWord += Shift(letter, shiftValue);
        }

        return shiftedWord;
    }


    public static char Shift(char letterToShift, int shiftValue)
    {
        // return value if not letter
        if (!Char.IsLetter(letterToShift)) return letterToShift;

        char[] alphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        char[] alphabetLower = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToArray();

        int alhabetLenght = alphabetUpper.Length;

        // trim shift
        if (Math.Abs(shiftValue) >= alhabetLenght)
        {
            if (shiftValue > 0)
            {
                shiftValue -= alhabetLenght;
            }
            else
            {
                shiftValue += alhabetLenght;
            }
        }

        int indexOfNewLetter;

        if (Char.IsUpper(letterToShift))
        {
            // shifted value index
            indexOfNewLetter = Array.IndexOf(alphabetUpper, letterToShift) + shiftValue;
            // Go back to begining
            if (indexOfNewLetter >= alhabetLenght) indexOfNewLetter -= alhabetLenght;
            if (indexOfNewLetter < 0) indexOfNewLetter += alhabetLenght;

            return alphabetUpper[indexOfNewLetter];
        }
        indexOfNewLetter = Array.IndexOf(alphabetLower, letterToShift) + shiftValue;

        if (indexOfNewLetter >= alphabetLower.Length) indexOfNewLetter -= alphabetLower.Length;
        if (indexOfNewLetter < 0) indexOfNewLetter += alhabetLenght;

        return alphabetLower[indexOfNewLetter];
    }
}