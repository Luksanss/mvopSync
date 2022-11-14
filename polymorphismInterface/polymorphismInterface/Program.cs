namespace polymorphismInterface;

class Program
{
    public static void Main(string[] args)
    {
        Circle circle = new Circle(4, 2, 5);

        Circle circle1 = new Circle();

        Square square = new Square(2, 2, 5);

        Square square1 = new Square();

        IGeo[] objects = { circle, circle1, square, square1 };

        foreach (IGeo obj in objects)
        {
            Console.WriteLine(Pomer(obj));
        }

        Console.WriteLine(circle.CompareTo(circle1));

        Circle testCircle = new Circle(1, 1, 2);

        List<Circle> circ = new List<Circle>();

        circ.Add(circle);
        circ.Add(circle1);
        circ.Add(testCircle);

        foreach (Circle c in circ)
        {
            Console.WriteLine(c.Plocha());
        }

        circ.Sort();

        foreach (Circle c in circ)
        {
            Console.WriteLine(c.Plocha());
        }





        Console.ReadKey();
    }

    public static double Pomer(IGeo obj)
    {
        // return $"Obvod : Obsahu = {obj.Obvod()} : {obj.Plocha()}";
        return obj.Obvod() / obj.Plocha();
    }

}
public interface IGeo
{
    double Plocha();
    double Obvod();
    double MomentX();
}

class Circle : IGeo, IComparable<IGeo>
{
    private double polomer;
    public double Polomer
    {
        get { return polomer; }
        set { this.polomer = value; }
    }
    private double x;
    public double X
    {
        get { return x; }

        set { this.x = value; }
    }

    private double y;
    public double Y
    {
        get { return y; }

        set { this.y = value; }
    }
    public Circle()
    {
        // doesn't need to do anything
    }

    public Circle(double x, double y, double polomer)
    {
        this.X = x;
        this.Y = y;
        this.polomer = polomer;
    }

    public double Plocha()
    {
        return Math.PI * this.polomer * this.polomer;
    }

    public double Obvod()
    {
        return 2 * Math.PI * this.polomer;
    }

    public bool protina(Circle k)
    {
        double distance = Math.Sqrt(Math.Pow(this.X - k.X, 2) + Math.Pow(this.Y - k.Y, 2));
        double oblenght = polomer + k.polomer;
        if (distance < polomer)
        {
            return polomer - distance < k.polomer;
        }

        if (distance < k.polomer)
        {
            return k.polomer - distance < polomer;
        }

        return distance < oblenght;

    }

    public double MomentX()
    {
        return this.Y * this.Plocha();
    }

    public override string ToString()
    {
        return $"Circle";
    }

    public int CompareTo(IGeo? obj)
    {
        if (obj.Plocha() > this.Plocha())
        {
            return -1;
        }
        else if (obj.Plocha() == this.Plocha())
        {
            return 0;
        }

        return 1;

    }
}

class Square : IGeo
{
    private double side;
    public double Side
    {
        get { return side; }
        set { this.side = value; }
    }

    private double x;
    public double X
    {
        get { return x; }

        set { this.x = value; }
    }

    private double y;
    public double Y
    {
        get { return y; }

        set { this.y = value; }
    }

    public Square()
    {
        // doesn't need to do anything
    }

    public Square(double x, double y, double side)
    {
        this.X = x;
        this.Y = y;
        this.Side = side;
    }

    public double Plocha()
    {
        return this.Side * this.Side;
    }

    public double Obvod()
    {
        return this.Side * 4;
    }

    public override string ToString()
    {
        return $"Square";
    }

    public double MomentX()
    {
        return this.Y * this.Plocha();
    }
}



