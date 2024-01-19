using System;
using System.Threading;
using System.Threading.Tasks;

namespace async_1;


class Program
{
    public static async Task Main(string[] args)
    {
        CountLeftAsync();
        CountRightAsync();
        Console.ReadKey();
    }

    static async Task CountLeftAsync()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.SetCursorPosition(0, 2);
            Console.Write($"{i} na threadu {Thread.CurrentThread.Name}{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(100);
        }
        
    }

    static async Task CountRightAsync()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.SetCursorPosition(60, 23);
            Console.Write($"{i} na threadu {Thread.CurrentThread.Name}{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(100);
        }

    }
}