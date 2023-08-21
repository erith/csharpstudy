namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double c = Plus(20.0d, 40.0d);
            Console.WriteLine(c);

            double s = SummaryNumbers(1, 2, 3, 4, 5);
        }

        public static int Plus(int a, int b)
        {
            return a + b;
        }

        public static double Plus(double a, double b)
        {
            return a + b;
        }

        public static double SummaryNumbers(params double[] nums)
        {
            double sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            return sum;
        }

        public static string GetGreeting(string userName, string greeting = "Hello")
        {
            return $"{greeting}, {userName}";
        }
    }
}