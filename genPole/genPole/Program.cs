int[] arr = new int[50];

Random genNum = new Random();

int curNum;

for (int i = 0; i < arr.Length; i++)
{
    do {
        curNum = genNum.Next(0, 101);
    } while (arr.Contains(curNum));

    arr[i] = curNum;
}



Console.WriteLine("Sudý index: ");

for (int i = 0; i < arr.Length / 2; i += 2)
{
    Console.WriteLine(arr[i]);
}

Console.WriteLine("Lichý index: ");

for (int i = 1; i < arr.Length / 2; i += 2)
{
    Console.WriteLine(arr[i]);
}
