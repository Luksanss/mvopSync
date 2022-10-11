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

        Worker realWorker = new("Deine", "Mutter", 200, 100);

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
        this.name = name;
        this.surname = surname;
    }

    private string name;
    public string Name
    {
        get { return this.name; }
        set
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
        this.Name = name;
        this.Surname = surname;
        this.Mark = mark;
    }
}

class Worker : Human
{
    private int mzda;
    public int Mzda
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

    private int odpracovaneHodiny;
    public int OdpracovaneHodiny
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

    public Worker(string name, string surname, int mzda, int odpracovaneHodiny) : base(name, surname)
    {
        this.Name = name;
        this.Surname = surname;
        this.mzda = mzda;
        this.odpracovaneHodiny = odpracovaneHodiny;
    }

    public int HodinovaMzda()
    {
        return this.Mzda * this.odpracovaneHodiny;
    }
}