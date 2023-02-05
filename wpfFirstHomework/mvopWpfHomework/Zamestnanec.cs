using System;
using System.Collections.Generic;

namespace mvopWpfHomework
{
    class Osoba
    {
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
    }

    class Zamestnanec : Osoba
    {
        string edDegree;
        public string EdDegree
        {
            get { return edDegree; }
            set { edDegree = value; }
        }

        string workOccupation;
        public string WorkOccupation
        {
            get { return workOccupation; }
            set { workOccupation = value; }
        }

        double salary;
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public override string ToString()
        {
            return $"{Name} {Surname},\nBorn: {DateOfBirth.ToShortDateString()}, \nDegree: {edDegree}, \nWorking as: {workOccupation},\nsalary: {salary}";
        }
        public string ToStringSave()
        {
            return $"Name: {Name}, Surname: {Surname}, Born: {DateOfBirth.ToShortDateString()}, Degree: {edDegree}, Working as: {workOccupation}, salary: {salary}";
        }
        public Guid ID
        {
            get;
            set;
        }

        // save all ZamestnanciList for listView
        public static List<Zamestnanec> ZamestnanciList { get; set; } = new List<Zamestnanec>();
        public static bool isFilled(Zamestnanec zam)
        {
            return zam.Name != null && zam.Surname != null && zam.Salary != 0d && zam.WorkOccupation != null && zam.EdDegree != null && zam.Name != String.Empty && zam.Surname != String.Empty && zam.Salary != 0 && zam.WorkOccupation != String.Empty && zam.EdDegree != String.Empty;
        }
    }
}
