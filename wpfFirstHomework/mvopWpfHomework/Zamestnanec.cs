using System;

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

        public bool isFilled()
        {
            return this.Name != null && this.Surname != null && this.Salary != 0d && this.WorkOccupation != null && this.EdDegree != null && this.Name != String.Empty && this.Surname != String.Empty && this.Salary != 0 && this.WorkOccupation != String.Empty && this.EdDegree != String.Empty;
        }
    }
}
