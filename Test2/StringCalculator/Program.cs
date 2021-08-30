using System;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter delimeted numbers");

            var input = Console.ReadLine();

            if (input.Contains("-"))
            {
                var negativesCount = new StringBuilder();

                foreach(var item in input)
                {
                    if(item == '-')
                    {
                        negativesCount.Append("-");
                    }
                }

                throw new InvalidOperationException($"negatives not allowed : {negativesCount}");
            }
                
            var numbers = GetNumbers(input);

            if(numbers.Length == 1)
            {
                Console.WriteLine("Please provide more than one number");
                return;
            }

            Console.WriteLine($"The added number equal to {AddNumbers(numbers)}");


        }




        private static string[] GetNumbers(string value)
        {
            var input = new StringBuilder(value);

            var newlineDelemeter = "\\n";
            string changedDelimeter = string.Empty;

            if (value.StartsWith("//"))
            {
                input.Replace("//", string.Empty);


                changedDelimeter = input[0].ToString();
                input.Remove(0, 1);
            }

            if(changedDelimeter != string.Empty)
            {
                input.Replace(changedDelimeter, ",");
            }

            input.Replace(newlineDelemeter, ",");

            return input.ToString().Split(',');
        }

        private static int AddNumbers(params string[] arguments)
        {
            int[] numbers = Array.ConvertAll(arguments, int.Parse);


            return numbers.Sum();
        }
    }
}
