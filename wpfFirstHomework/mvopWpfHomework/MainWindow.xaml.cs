using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
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
        SolidColorBrush redErrorbrush = Brushes.Red;
        Zamestnanec zm;
     
        public MainWindow()
        {
            InitializeComponent();
            LoadDataFromFile();
            DataContext = zm = new Zamestnanec();
        }
        private void PrintToLabel(object sender, RoutedEventArgs e)
        {
            if (zm.isFilled())
            {
                LabelEmploee.Content = zm.ToString();
            }
            else
            {
                LabelEmploee.Content = "Missing some information...";
            }
        }
        private void PrintToLabelPreview(Zamestnanec newZm)
        {
            // e.Text = "content"
              LabelEmploee.Content = newZm.ToString();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            bool saveSuccess = false;
            string Path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\dataEmployes.txt";
            using (StreamWriter sw = File.AppendText(Path))
            {
                if (zm.isFilled())
                {
                    sw.WriteLine(zm.ToStringSave());
                    saveSuccess = true;
                }
                else
                {
                    LabelEmploee.Content = "Missing some information, can't save...";
                }
            }
            if (saveSuccess)
            {
                LoadDataFromFile();
            }
        }

        private void TextBoxSurname_LostFocus(object sender, RoutedEventArgs e)
        {
            bool resetValue = false;
            foreach (var c in TextBoxSurname.Text)
            {
                if (!char.IsLetter(c))
                {
                    TextBoxSurname.BorderBrush = redErrorbrush;
                    resetValue = true;
                    break;
                }
            }
            if (resetValue)
            {
                TextBoxSurname.Text = String.Empty;
                SurnameLabel.Content = "use only letters!";
            }
            else
            {
                TextBoxSurname.BorderBrush = Brushes.Black;
                SurnameLabel.Content = String.Empty;
            }
        }

        private void TextBoxSalary_LostFocus(object sender, RoutedEventArgs e)
        {
            bool resetValue = false;
            foreach (var c in TextBoxSalary.Text)
            {
                if (!char.IsDigit(c))
                {
                    TextBoxSalary.BorderBrush = redErrorbrush;
                    resetValue = true;
                    break;
                }
            }
            if (resetValue)
            {
                TextBoxSalary.Text = String.Empty;
                SalaryLabel.Content = "use only whole numbers!";
            }
            else 
            {
                TextBoxSalary.BorderBrush = Brushes.Black;
                SalaryLabel.Content = String.Empty;
            }
        }

        private void TextBoxTitle_LostFocus(object sender, RoutedEventArgs e)
        {
            bool resetValue = false;
            foreach (var c in TextBoxTitle.Text)
            {
                if (!char.IsLetter(c))
                {
                    TextBoxTitle.BorderBrush = redErrorbrush;
                    resetValue = true;
                    break;
                }
            }
            if (resetValue)
            {
                TextBoxTitle.Text = String.Empty;
                TitleLabel.Content = "use only letters!";
            }
            else
            {
                TextBoxTitle.BorderBrush = Brushes.Black;
                TitleLabel.Content = String.Empty;
            }
        }

        private void TextBoxName_LostFocus(object sender, RoutedEventArgs e)
        {
            bool resetValue = false;
            foreach (var c in TextBoxName.Text)
            {
                if (!char.IsLetter(c))
                {
                    TextBoxName.BorderBrush = redErrorbrush;
                    resetValue = true;
                    break;
                }
            }
            if (resetValue)
            {
                TextBoxName.Text = String.Empty;
                NameLabel.Content = "use only letters!";
            }
            else
            {
                TextBoxName.BorderBrush = Brushes.Black;
                NameLabel.Content = String.Empty;
            }
        }

        private void LoadDataFromFile()
        {
            List<Zamestnanec> listOfPeople = new List<Zamestnanec>();

            // code to load data from file into records list
            List<string> values = new List<string>();
            string Path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\dataEmployes.txt";
            try
            {
                string[] linesTest = System.IO.File.ReadAllLines(Path);
            }
            catch
            {
                using (StreamWriter w = File.AppendText(Path)) ;
            }
            string[] lines = System.IO.File.ReadAllLines(Path);

            foreach (string line in lines)
            {
                var selectCategory = line.Split(",");
                foreach (var category in selectCategory)
                {
                    var selectValue = category.Split(": ");
                    values.Add(selectValue[1]);
                }
                listOfPeople.Add(new Zamestnanec { Name = values[0], Surname = values[1], DateOfBirth = DateTime.Parse(values[2]), EdDegree = values[3], WorkOccupation = values[4], Salary = double.Parse(values[5]) });
                values.Clear();
            }
            displayData.ItemsSource = listOfPeople;
        }

        private void TextBoxName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var newZm = zm;
            newZm.Name = TextBoxName.Text;
            PrintToLabelPreview(newZm);
        }

        private void TextBoxSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var newZm = zm;
            newZm.Surname = TextBoxSurname.Text;
            PrintToLabelPreview(newZm);
        }

        private void TextBoxSalary_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var newZm = zm;
            var success = double.TryParse(TextBoxSalary.Text, out _);
            if (success)
            {
                newZm.Salary = double.Parse(TextBoxSalary.Text);
                PrintToLabelPreview(newZm);
            }
            else
            {
                TextBoxSalary_LostFocus(sender, e);
            }

        }

        private void TextBoxTitle_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var newZm = zm;
            newZm.WorkOccupation = TextBoxTitle.Text;
            PrintToLabelPreview(newZm);
        }

        private void CmBoxEdu_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var newZm = zm;
            newZm.EdDegree = CmBoxEdu.Text;
            PrintToLabelPreview(newZm);
        }

        private void DatePicker_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var newZm = zm;
            try
            {
                newZm.DateOfBirth = DateTime.Parse(DatePicker.Text);
            }
            catch
            {
                
            }
            PrintToLabelPreview(newZm);
        }

        private void DatePicker_LostFocus(object sender, RoutedEventArgs e)
        {
            bool resetValue = false;
            foreach (var c in DatePicker.Text)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    DatePicker.BorderBrush = redErrorbrush;
                    resetValue = true;
                    break;
                }
            }
            if (resetValue)
            {
                DatePicker.Text = DateTime.Now.ToShortDateString();
                DateLabel.Content = "use only numbers and dot!";
            }
            else
            {
                DatePicker.BorderBrush = Brushes.Black;
                DateLabel.Content = String.Empty;
            }
        }
    }

    class Osoba 
    {
        string name;
        public string Name {
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
