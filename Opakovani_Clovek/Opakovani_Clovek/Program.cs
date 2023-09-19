using System.Text.RegularExpressions;

namespace Opakovani_Clovek;

class Program
{
    class Clovek
    {
        private string jmeno;
        public string Jmeno
        {
            get
            {
                return jmeno;
            }
            set
            {
                jmeno = value;
            }
        }

        private string prijmeni;
        public string Prijmeni
        {
            get
            {
                return prijmeni;
            }
            set
            {
                prijmeni = value;
            }
        }

        // constructor without params
        public Clovek()
        {
            Jmeno = "Nezname";
            Prijmeni = "Nezname";
        }

        // constructor with params
        public Clovek(string name, string surname)
        {
            Jmeno = name;
            Prijmeni = surname;
        }

        public override string ToString()
        {
            return $"Jmeno osoby je: {this.Jmeno}\nPrijimeni jest: {this.Prijmeni}";
        }
    }

    class Obcan : Clovek
    {
        private string rodneCislo;
        public string RodneCislo
        {
            get
            {
                return rodneCislo;
            }

            set
            {
                rodneCislo = value;
            }
        }


        public Obcan() : base()
        {
            RodneCislo = "000000/0000";
        }

        public Obcan(string name, string surname, string rodneC) : base(name, surname)
        {
            // check validity
            Regex rg = new Regex(@"^\d{6}\/\d{4}$");

            if (!rg.IsMatch(rodneC))
            {
                throw new FormatException();
            }

            RodneCislo = rodneC;

        }

        public override string ToString()
        {
            return $"Name: {this.Jmeno}\nSurname: {this.Prijmeni}\nID: {this.RodneCislo}";
        }
    }

    public static void Main(string[] args)
    {

        Obcan novyClovek = new Obcan("jmeno", "prijemnei", "444345/3245");

        
        Console.WriteLine(novyClovek);

        Console.ReadKey();
    }

}

