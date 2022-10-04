using System.Collections.Generic;

namespace MyStackProgram;

class Program
{
    static void Main(string[] args)
    {

        //Console.Write("Napiš výraz: ");
        //string? userString = Console.ReadLine();

        string testCase0 = "{2+3*2+7*(2-3)]}";
        string testCase1 = "{2+3*[2+7*(2-3)]}";
        //string testCase2 = "{2+3*[2+7*(2-3}]}";
        //string testCase3 = "3d3";
        //string testCase4 = "}";
        //string testCase5 = "";

        //IsValid(userString);

       

        // special zavorky
        // string testCaseS0 = "$bob& $bobs&";


        IsValid(testCase0);
        IsValid(testCase1);
        //IsValid(testCase2);
        //IsValid(testCase3);
        //IsValid(testCase4);
        //IsValid(testCase5);

        //Console.WriteLine("\n\n");
        //Console.WriteLine("Special case testing: \n");
        //IsValid(testCaseS0);

        Console.ReadKey();


    }

    static bool IsValid(string s)
    {
        MyStack bracketStack = new MyStack();

        string brackets = "{}[]()$&";

        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case '{':
                    bracketStack.Push('}');
                    break;
                case '[':
                    bracketStack.Push(']');
                    break;
                case '(':
                    bracketStack.Push(')');
                    break;
                case '$':
                    bracketStack.Push('&');
                    break;
                case '}':
                case ']':
                case ')':
                case '&':
                    char expectedChar = brackets[brackets.IndexOf(s[i]) - 1];
                    if (bracketStack.IsEmpty() || bracketStack.Pop() != s[i])
                    {
                        Console.WriteLine(s);
                        if (i == 0)
                        {
                            Console.WriteLine("↑ here");
                            Console.WriteLine($"Chyba uzavorkovani, ocekaval se znak {expectedChar} \n");
                            return false;
                        }
                        Console.WriteLine($"{String.Concat(Enumerable.Repeat(" ", i - 1))} ↑ here");
                        Console.WriteLine($"Chyba uzavorkovani, ocekaval se znak {expectedChar} \n");
                        return false;
                    }
                    break;
                default:
                    break;
            }
        }
        // Just for test -> delete Console.WriteLine later

        if (s.Length == 0)
        {
            Console.Write("Empty String     ----> ");
        }
        else
        {
            Console.Write($"{s}     ----> ");
        }
        Console.WriteLine("Uzavorkovani je spravne \n");

        return true;
    }
}

class MyStack
{
    private readonly List<char> stackList = new List<char>();

    public MyStack()
    {
        stackList = new List<char>();
    }

    public MyStack(int sizeOfStack)
    {
        // sizeOfStack for list just works as an optimalization, does not limit the actuall size of list
        stackList = new List<char>(sizeOfStack);
    }

    public void Push(char c)
    {
        stackList.Insert(0, c);
    }

    public char Pop()
    {
        char topOnStack = stackList[0];

        stackList.RemoveAt(0);

        return topOnStack;
    }

    public char Peek()
    {
        return stackList[0];
    }

    public bool IsEmpty()
    {
        if (stackList.Count == 0) { return true; }
        return false;
    }

    public void PrintStack()
    {
        foreach (char c in stackList)
        {
            Console.Write($"{c} ");
        }
    }

}
