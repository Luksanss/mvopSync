namespace DynamecPass;

class Program
{
    public static void Main(string[] args)
    {
        string s = IsStringValid(Validate);
        Console.ReadKey();
    }

    public static string IsStringValid(Something f)
    {
        string? userInput;
        while (true)
        {
            userInput = Console.ReadLine();
            if (f(userInput))
            {
                Console.WriteLine("Correct");
                return userInput;
            }
            else
            {
                Console.WriteLine("Bad string format, try again");
            }
        }
    }

    public static bool Validate(string? userInput)
    {
        if (userInput != null && userInput.Length >= 2 && Int32.TryParse(userInput, out _))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public delegate bool Something(string? userInput);
}