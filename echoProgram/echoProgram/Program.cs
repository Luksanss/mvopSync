while (true)
{
    Console.Write("> ");

    string[] userInput = Console.ReadLine().Split();

    if (userInput[0] == "echo")
    {
        for (int i = 1; i < userInput.Length; i++) {
            Console.Write(userInput[i]);
        }
        Console.WriteLine();
    }
}