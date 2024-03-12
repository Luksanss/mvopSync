// key is a shift value, which shifts letter in question
    // shift = 2
    // CaesarovaSifra("a") => "c"

namespace CaesarovaSifra;

class Program
{
    public static void Main(string[] args)
    {
        int shift = -1;
        string word = "abcde";

        string wordDe = "zabcd";

        Console.WriteLine(CaesarCipher(word, shift, false));
        Console.WriteLine(CaesarCipher(wordDe, shift, true));

        Console.ReadKey();
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
            else {
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