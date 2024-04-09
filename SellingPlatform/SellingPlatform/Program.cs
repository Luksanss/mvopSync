namespace SellingPlatform;

class Program
{
    public static void Main(string[] args)
    {
        Console.ReadKey();
    }
}

public struct Address
{
    string street;
    string number;
    string town;
    public override string ToString()
    {
        return $"{street} {number} {town}";
    }
}

public interface ISellable
{
    decimal Price { get; set; }

    DateTime AvailableSince { get; set; }

    Address GetLocation();
}

public class Picture : ISellable
{
    public string Author { get; set; }

    public double Length { get; set; }
    
    public double Width { get; set; }

    // ISellable implementation

    public decimal Price { get; set; }
    public DateTime AvailableSince { get; set; }

    public Address Location { get; set; }

    public override string ToString()
    {
        return base.ToString();
    }
}