namespace stringToEquasion;

class Program
{
    public static void Main(string[] args)
    {
        List<double> nums;
        List<char> operators;

        (nums, operators) = GetValues("2.15 + 3 * 4 / 2 - 1");
        Console.WriteLine(Calculate(nums, operators));
        Console.ReadKey();
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
            else {
                if (operatorsAllowed.Contains(c[0])) {
                    operators.Add(c[0]);
                }
            }
        }
        foreach (var f in nums)
        {
            Console.Write($"{f} ");
        }
        Console.WriteLine();
        foreach (var f in operators)
        {
            Console.Write($"{f} ");
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
            if (value == null || index == null) {
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