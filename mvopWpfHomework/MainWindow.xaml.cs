using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mvopWpfHomework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /*
        Napište ve WPF vstupní formulář pro třídu Zaměstnanec, která obsahuje jméno, příjmení, rok narození, nejvyšší dokončené vzdělání(výběrem z omezených možností), pracovní pozici a hrubý plat v korunách.
        Třídu Zaměstnanec vytvořte děděním ze třídy Osoba, která obsahuje jméno, příjmení a rok narození.
        Formulář otestujte a informace o zaměstnancích ukládejte do souboru.
     */
    public partial class MainWindow : Window
    {
        Zamestnanec zm;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = zm = new Zamestnanec();
        }
        private void PrintToLabel(object sender, RoutedEventArgs e)
        {
            LabelEmploee.Content = zm.ToString();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            string Path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\dataEmployes.txt";
            using (StreamWriter sw = File.AppendText(Path))
            {
                sw.WriteLine("Name: " + zm.Name);
                sw.WriteLine("Surname: " + zm.Surname);
                sw.WriteLine("Date of birth: " + zm.DateOfBirth);
                sw.WriteLine("Education: " + zm.EdDegree);
                sw.WriteLine("Salary: " + zm.Salary);
                sw.WriteLine("Occupation: " + zm.WorkOccupation);
                sw.WriteLine("********************************");
            }
        }
    }

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
            return $"{Name} {Surname},\nBorn: {DateOfBirth}, \nDegree: {edDegree} \nWorking as: {workOccupation}, salary: {salary}";
        }

    }
}
