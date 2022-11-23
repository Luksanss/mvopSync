namespace Event;

class Program
{


    public static void Main(string[] args)
    {
        AlertList al = new AlertList(new List<int>(), 20);
        al.Capcity += al_Capacity;
        al.Overflow += al_Overflow;

        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);
        al.AddItem(100);


        Console.ReadKey();
    }

    private static void al_Overflow(int maxSize)
    {
        Console.WriteLine($"max size has been reached (max size: {maxSize})");
    }

    private static void al_Capacity(double percent)
    {
        Console.WriteLine($"{100 - percent}% free space");
    }
}

class AlertList
{
    public delegate void OverflowHandler(int maxSize);
    public delegate void CapacityHandler(double sizeFilledPercent);

    public event OverflowHandler Overflow;
    public event CapacityHandler Capcity;

    private int maxSize;
    public int MaxSize
    {
        get
        {
            return maxSize;
        }

        set
        {
            maxSize = value;
        }
    }



    private List<int> list;
    public List<int> List
    {
        get
        {
            return list;
        }

        set
        {
            list = value;
        }
    }

    public AlertList(List<int> list, int maxSize)
    {
        this.List = new List<int>();
        this.MaxSize = maxSize;
    }


    public void AddItem(int number)
    {
        if (this.List.Count < this.MaxSize)
        {
            this.List.Add(number);
            Capcity.Invoke((double)this.List.Count / this.MaxSize * 100);
        }
        else
        {
            Overflow.Invoke(this.MaxSize);
        }
    }
}
