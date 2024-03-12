namespace CheckIfInCheck;

class Program
{
    public static void Main(string[] args)
    {
        string[,] chessBoard = new string[8,8];

        PrintBoard(chessBoard);


        chessBoard[0, 1] = "a";

        PrintBoard(chessBoard);

        Console.ReadKey();
    }

    public static void PrintBoard(string[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int n = 0; n < board.GetLength(1); n++)
            {
                Console.Write(board[i, n] + "\t,");
            }
            Console.WriteLine();
        }
    }

    // every chess piece must have its method, that calculates, how far it can reach

}

class ChessPiece
{
    string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    // store all possible positions for piece
    List<int[]> possiblePossitions;

    int[] possition;
    public int[] Possition
    {
        get { return possition; }
        set
        {
            possition[0] = value[0];
            possition[1] = value[1];
        }
    }
}

