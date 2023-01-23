using System;
using System.Collections.Generic;
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
using System.Data;

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }
        public static double Evaluate(string expression) => Convert.ToDouble(new DataTable().Compute(expression, ""));
        
        private bool godChecker(string charToCheck)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[0-9]");
            string temp;
            string[] allowedSymbols = { "/", "*", "-", "+", "." };


            if (!regex.IsMatch(charToCheck) && printResult.Text.Length > 1)
            {
                if (allowedSymbols.Contains(Convert.ToString(printResult.Text[printResult.Text.Length - 1])) && allowedSymbols.Contains(charToCheck))
                {
                    return true;
                }
                else
                {
                    foreach (var syumbol in charToCheck)
                    {
                        temp = Convert.ToString(syumbol);
                        if (allowedSymbols.Contains(temp))
                        {
                            return false;
                        }
                        temp = Convert.ToString(syumbol);
                        if (!allowedSymbols.Contains(temp))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = godChecker(e.Text);
        }

        private void result_Click(object sender, RoutedEventArgs e)
        {
            // printResult.Text = Calc.MainCalc(printResult.Text);
            printResult.Text = Convert.ToString(Evaluate(printResult.Text)).Replace(',', '.');
        }

        private void InputBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string charToCheck = (e.Source as Button).Content.ToString();
            if (!godChecker(charToCheck))
            {
                printResult.Text += charToCheck;
            }
        }

        private void Clear_Text(object sender, RoutedEventArgs e)
        {
            printResult.Text = string.Empty;
        }
    }
    class Calc
    {
        public static string MainCalc(string arg)
        {
            List<double> nums;
            List<char> operators;

            (nums, operators) = GetValues(arg);
            return Convert.ToString(Calculate(nums, operators));
            //Console.ReadKey();
        }

        public static (List<double>, List<char>) GetValues(string equasion)
        {
            string[] Equasion = equasion.Split(" ");
            char[] operatorsAllowed = { '/', '*', '-', '+' };

            List<double> nums = new List<double>();
            List<char> operators = new List<char>();

            double num;

            foreach (string c in Equasion)
            {
                bool result = double.TryParse(c, out num);
                if (result) { nums.Add(num); }
                else
                {
                    if (operatorsAllowed.Contains(c[0]))
                    {
                        operators.Add(c[0]);
                    }
                }
            }
            return (nums, operators);
        }

        public static double Calculate(List<double> nums, List<char> operators)
        {
            double? value;
            int? index;
            do
            {
                (value, index, operators) = getNewNum(nums, operators);
                if (value == null || index == null)
                {
                    break;
                }
                nums[(int)index] = (double)value;
                nums.RemoveAt((int)index + 1);
            } while (value != null && index != null);


            return nums[0];
        }
        public static (double?, int?, List<char>) getNewNum(List<double> nums, List<char> operators)
        {
            double? value = null;
            int? index = null;

            if (operators.Contains('*') || operators.Contains('/'))
            {
                for (int i = 0; i < operators.Count; i++)
                {
                    if (operators[i] == '*')
                    {
                        value = nums[i] * nums[i + 1];
                        index = i;
                        operators.RemoveAt(i);
                        break;
                    }
                    if (operators[i] == '/')
                    {
                        value = nums[i] / nums[i + 1];
                        index = i;
                        operators.RemoveAt(i);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < operators.Count; i++)
                {
                    if (operators[i] == '+')
                    {
                        value = nums[i] + nums[i + 1];
                        index = i;
                        operators.RemoveAt(i);
                        break;
                    }
                    if (operators[i] == '-')
                    {
                        value = nums[i] - nums[i + 1];
                        index = i;
                        operators.RemoveAt(i);
                        break;
                    }
                }
            }

            return (value, index, operators);
        }

    }

}


