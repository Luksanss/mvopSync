namespace polymorphismAbstract;

class Program
{
    public static void Main(string[] args)
    {
        Circle circle = new Circle();


        Circle circle2 = new Circle(2, 3, 5);


        Square ctverec = new Square();


        Square ctverec2 = new Square(4, 3, 5);

        GeometricObject[] arrOfObjects = { circle, circle2, ctverec, ctverec2 };

        foreach (GeometricObject obj in arrOfObjects)
        {
            Console.WriteLine($"For {obj} the value is: {GeometricObject.MomentX(obj)}");
        }


        Console.ReadKey();
    }
    public static Circle GetKruznice()
    {
        double x;
        double y;
        double polomer;
        Console.Write("pos x: ");
        x = Convert.ToDouble(Console.ReadLine());
        Console.Write("pos y: ");
        y = Convert.ToDouble(Console.ReadLine());
        Console.Write("polomer kruz: ");
        polomer = Convert.ToDouble(Console.ReadLine());

        return new Circle(x, y, polomer);
    }
}



abstract class GeometricObject
{
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
    private int myID;

    public int MyID
    {
        get { return myID; }
    }


    protected static int id = 0;

    public GeometricObject()
    {
        this.myID = id;
        id++;
    }
    public GeometricObject(double x, double y)
    {
        this.x = x;
        this.y = y;
        this.myID = id;
        id++;
    }

    public static double MomentX(GeometricObject obj)
    {
        return obj.Y * obj.Plocha();
    }

    public abstract double Plocha();

    public abstract double Obvod();

    public abstract override string ToString();
}

class Circle : GeometricObject
{
    private double polomer;
    public double Polomer
    {
        get { return polomer; }
        set { this.polomer = value; }
    }
    public Circle() : base ()
    {
        // doesn't need to do anything
    }

    public Circle(double x, double y, double polomer) : base(x, y)
    {
        this.polomer = polomer;
    }

    public override double Plocha()
    {
        return Math.PI * this.polomer * this.polomer;
    }

    public override double Obvod()
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

    public override string ToString()
    {
        return $"Circle id: {this.MyID}";
    }
}

class Square : GeometricObject
{
    private double side;
    public double Side
    {
        get { return side; }
        set { this.side = value; }
    }
    public Square() : base()
    {
        // doesn't need to do anything
    }

    public Square(double x, double y, double side) : base(x, y)
    {
        this.Side = side;
    }

    public override double Plocha()
    {
        return this.Side * this.Side;
    }

    public override double Obvod()
    {
        return this.Side * 4;
    }
    public override string ToString()
    {
        return $"Square id: {this.MyID}";
    }
}