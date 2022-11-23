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

        int XBegin = 3;
        int YBegin = 0; // Y is reversed to match indexes of array

        int XEnd = 3;
        int YEnd = 3; // Y is reversed here too

    }

    public static List<int[]> NextStep(char[,] maze, int XBegin, int YBegin, int XEnd, int YEnd, List<int[]> stepsForRobot)
    {
        if (XBegin == XEnd && YBegin == YEnd)
        {
            return stepsForRobot;
        }
        else
        {
            try:
                if ()
        }
    }
}