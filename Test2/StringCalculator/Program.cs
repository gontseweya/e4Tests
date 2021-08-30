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
                
            var result = GetNumbers(input);

            if(result.delimeterCount > 1 && result.numbers.Length == 1)
            {
                Console.WriteLine("Please provide more than one number");
                return;
            }

            Console.WriteLine($"The added number equal to {AddNumbers(result.numbers)}");


        }




        private static (int delimeterCount, string[] numbers) GetNumbers(string value)
        {
            var input = new StringBuilder(value);
            var newlineDelemeter = "\\n";
            string changedDelimeter = string.Empty;
            int delimeterCount = 0;

            if (value.StartsWith("//"))
            {
                input.Replace("//", string.Empty);


                changedDelimeter = input[0].ToString();
                input.Remove(0, 1);
            }

            if (value.Contains(","))
            {
                delimeterCount++;
            }

            if (changedDelimeter != string.Empty)
            {
                input.Replace(changedDelimeter, ",");
                delimeterCount++;
            }

            if(value.Contains("\\n"))
            {
                input.Replace(newlineDelemeter, ",");
                delimeterCount++;
            }

            var inputResult = input.ToString().Split(',');

            var newlist = inputResult.ToList().Where(x => x != string.Empty).ToArray();


            return (delimeterCount, newlist);
        }

        private static int AddNumbers(params string[] arguments)
        {
            int[] numbers = Array.ConvertAll(arguments, int.Parse);


            return numbers.Sum();
        }
    }
}
