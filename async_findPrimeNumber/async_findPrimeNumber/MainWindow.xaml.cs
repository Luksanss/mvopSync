using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace async_findPrimeNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string userNums;
        SolidColorBrush loadingNumberColorRed = new SolidColorBrush(Color.FromRgb(255, 102, 102));
        SolidColorBrush whiteColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        public MainWindow()
        {
            InitializeComponent();
        }

        public static bool IsPrime(ulong num)
        {
            if (num <= 1) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;

            var boundary = (ulong)Math.Floor(Math.Sqrt(num));

            for (ulong i = 3; i <= boundary; i += 2)
                if (num % i == 0)
                    return false;

            return true;
        }

        public static ulong FindPrime(string num, string repetitions)
        {
            string pattern = string.Empty;
            // generate the pattern
            for (int i = 0; i < Convert.ToInt32(repetitions); i++)
            {
                pattern += num;
            }

            // find number
            string generatedPattern = string.Empty;
            ulong CurNum = Convert.ToUInt64(pattern);
            while (!generatedPattern.Contains(pattern))
            {
                CurNum++;

                if (IsPrime(CurNum))
                {
                    generatedPattern = Convert.ToString(CurNum);
                }
            }

            return CurNum;
        }

        private async void CreateThread_1_Click(object sender, RoutedEventArgs e)
        {
            output_1.Background = loadingNumberColorRed;
            // output_1.Content = FindPrime(num_1.Text, reps_1.Text).Result;
            // Thread thread = new Thread(new ThreadStart(FindPrime(num_1.Text, reps_1.Text)));
            string text = num_1.Text;
            string reps = reps_1.Text;

            ulong result = await Task.Run(() =>
            {
                return FindPrime(text, reps);
            });
            output_1.Content = result;
            output_1.Background = whiteColor;
        }

        private async void CreateThread_2_Click(object sender, RoutedEventArgs e)
        {
            output_2.Background = loadingNumberColorRed;
            string text = num_2.Text;
            string reps = reps_2.Text;
            ulong result = await Task.Run(() =>
            {
                return FindPrime(text, reps);
            });
            output_2.Content = result;
            output_2.Background = whiteColor;
        }

        private async void CreateThread_3_Click(object sender, RoutedEventArgs e)
        {
            output_3.Background = loadingNumberColorRed;
            string text = num_3.Text;
            string reps = reps_3.Text;
            ulong result = await Task.Run<ulong>(() =>
            {
                return FindPrime(text, reps);
            });
            output_3.Content = result;
            output_3.Background = whiteColor;
        }
    }
}
