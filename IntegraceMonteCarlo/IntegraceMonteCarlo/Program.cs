namespace IntegraceMonteCarlo;

class Program
{
    static void Main (string[] args)
    {
        long bulletCount = 10000000;

        // limit
        double a = 2;
        double b = 3;

        double maxY = b * b + 0.001;
        double curY;
        double curX;

        double shotRight = 0;
        double shotMissed = 0;

        Random randomNext = new Random();



        for (int i = 0; i < bulletCount; i++)
        {
            curY = randomNext.NextDouble() * maxY;
            curX = randomNext.NextDouble() + a; // 0-1 is enough because b-a = 1

            if (curY < (curX * curX))
            {
                shotRight++;
            }
            else
            {
                shotMissed++;
            }

        }

        Console.WriteLine((shotRight / (shotMissed + shotRight)) * maxY);

        Console.ReadKey();

    }

}