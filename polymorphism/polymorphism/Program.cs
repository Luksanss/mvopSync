namespace polymorphism;

class Program
{
    public static void Main(string[] args)
    {
        GeometrickyObjekt g = new GeometrickyObjekt();
        Kruznice k = new Kruznice();
        Ctverec c = new Ctverec();

        Console.WriteLine(g.MyID);
        Console.WriteLine(k.MyID);



        c.Side = 3.2;


        Kruznice k2 = GetKruznice();

        Console.WriteLine(k2.Obvod());
        Console.WriteLine(k2.Plocha());


        Console.WriteLine(k2.protina(new Kruznice(3, 4, 2)));

        Console.ReadKey();
    }

    public static Kruznice GetKruznice()
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

        return new Kruznice(x, y, polomer);
    }

}

class GeometrickyObjekt
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


    static int id = 0;

    public GeometrickyObjekt()
    {
        this.myID = id;
        id++;
    }
    public GeometrickyObjekt(double x, double y)
    {
        this.x = x;
        this.y = y;
        this.myID = id;
        id++;
    }

    public virtual double Plocha()
    {
        return -1d;
    }

    public virtual double Obvod()
    {
        return -1d;
    }

}

class Kruznice : GeometrickyObjekt
{
    private double polomer;
    public double Polomer
    {
        get { return polomer; }
        set { this.polomer = value; }
    }
    public Kruznice() : base()
    {
        // doesn't need to do anything
    }

    public Kruznice(double x, double y, double polomer) : base(x, y)
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

    public bool protina(Kruznice k)
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
}

class Ctverec : GeometrickyObjekt
{
    private double side;
    public double Side
    {
        get { return side; }
        set { this.side = value; }
    }
    public Ctverec() : base()
    {
        // doesn't need to do anything
    }

    public Ctverec(double x, double y, double side) : base(x, y)
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
}