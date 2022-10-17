namespace tridaHuman;

class Program
{
    public static void Main(string[] args)
    {
        Human realHuman = new("Ahjoj", "af");

        // realHuman.Name = "f";
        // realHuman.Surname = "hehe";

        Console.WriteLine(realHuman.Name);
        Console.WriteLine(realHuman.Surname);

        Student realStudent = new("Lukas", "Papariga", 1);

        realStudent.Mark = 5;

        Console.WriteLine(realStudent.Name);
        Console.WriteLine(realStudent.Surname);
        Console.WriteLine(realStudent.Mark);

        Worker realWorker = new("Deine", "Mutter", 2010.2, 100.1);

        Console.WriteLine(realWorker.Mzda);
        Console.WriteLine(realWorker.OdpracovaneHodiny);
        Console.WriteLine(realWorker.HodinovaMzda());

        Console.ReadKey();
    }
}

class Human
{
    public Human(string name, string surname)
    {
        this.Name = name;
        this.Surname = surname;
    }

    private string name;
    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value == "")
            {
                throw new ArgumentException();
            }
            else
            {
                this.name = value;
            }
        }
    }

    private string surname;
    public string Surname
    {
        get { return surname;  }
        set
        {
            if (value == "")
            {
                throw new ArgumentException();
            }
            else
            {
                this.surname = value;
            }
        }
    }
}

class Student : Human
{
    private int mark;
    public int Mark
    {
        get;
        set;
    }

    public Student(string name, string surname, int mark) : base(name, surname)
    {
        this.Mark = mark;
    }
}

class Worker : Human
{
    private double mzda;
    public double Mzda
    {
        get { return mzda; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                this.mzda = value;
            }
        }
    }

    private double odpracovaneHodiny;
    public double OdpracovaneHodiny
    {
        get { return odpracovaneHodiny; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                odpracovaneHodiny = value;
            }
        }
    }

    public Worker(string name, string surname, double mzda, double odpracovaneHodiny) : base(name, surname)
    {
        this.Mzda = mzda;
        this.OdpracovaneHodiny = odpracovaneHodiny;
    }

    public double HodinovaMzda()
    {
        return this.Mzda * this.OdpracovaneHodiny;
    }
}