namespace PathFinding;

class Program
{
    public static void Main(string[] args)
    {
        int[,] maze = {
            { 0, 0, 0, 0, 0},
            { 0, 1, 1, 1, 1},
            { 0, 0, 0, 0, 0},
            { 0, 1, 1, 0, 0},
            { 1, 1, 1, 0, 1}
        };
        // { 0, 0, 0, Z, 0}
        // { 0, 1, 1, 1, 1}
        // { 0, 0, 0, 0, 0}
        // { 0, 1, 1, K, 0}
        // { 1, 1, 1, 0, 1}
       
        int[] Begin = { 0, 3 };

        int[] End = { 3, 3 }; 

        SortedDictionary<int[], char> dict = new SortedDictionary<int[], char>();
        dict.Add(Begin, 'Z');

        foreach (KeyValuePair<int[], char> kvp in Step(maze, Begin, End, dict))
        {
            Console.WriteLine($"{kvp.Key} on: {kvp.Value}");
        }
    }

    public static SortedDictionary<int[], char> Move(SortedDictionary<int[], char> dict, int[,] maze)
    {
        char[] moves = { 'l', 'r', 'u', 'd' }; // l = left, r = right, u = up,  d = down

        int[] curPos = dict.Last().Key;
        char curMove = dict.Last().Value;
        switch (curMove)
        {
            case 'Z':
                try
                {
                    if (maze[curPos[0], curPos[1] - 1] != 1)
                    {
                        dict.Add(new int[] { curPos[0], curPos[1] - 1}, 'l');
                        return dict;
                    }
                }
                catch
                {
                    goto case 'l';
                }
                break;
            case 'l':
                try
                {
                    if (maze[curPos[0], curPos[1] + 1] != 1)
                    {
                        dict.Add(new int[] { curPos[0], curPos[1] + 1 }, 'r');
                        return dict;
                    }
                }
                catch
                {
                    goto case 'r';
                }
                break;
            case 'r':
                try
                {
                    if (maze[curPos[0] - 1, curPos[1]] != 1)
                    {
                        dict.Add(new int[] { curPos[0] - 1, curPos[1] }, 'u');
                        return dict;
                    }
                }
                catch
                {
                    goto case 'u';
                }
                break;


            case 'u':
                try
                {
                    if (maze[curPos[0] + 1, curPos[1]] != 1)
                    {
                        dict.Add(new int[] { curPos[0] + 1, curPos[1] }, 'd');
                        return dict;
                    }
                }
                catch
                {
                    goto case 'd';
                }
                break;
            case 'd':
                try
                {
                    if (maze[curPos[0], curPos[1] - 1] != 1)
                    {
                        dict.Add(new int[] { curPos[0], curPos[1] - 1 }, 'l');
                        return dict;
                    }
                }
                catch
                {
                    goto case 'u';
                }
                break;
            default:
                return dict;
        }
        return dict;
    }

    public static SortedDictionary<int[], char> Step(int[,] maze, int[] begin, int[] end, SortedDictionary<int[], char> dict)
    {
        // runs limit after completing alg
        if (dict.Last().Key == end)
        {
            return dict;
        }
        var nextMove = Move(dict, maze);
        return Step(maze, begin, end, nextMove);
    }
}