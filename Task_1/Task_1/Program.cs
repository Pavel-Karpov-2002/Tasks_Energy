using System;
using System.Text.RegularExpressions;

namespace Task_1
{
    class Program
    {
        private const string GetFormulPattern = @"[^0-9\+\*\/\-]";
        private const string EnterValue = "Enter the line: ";
        private const string ErrorSybmolValue = "Wrong symbol!";

        static void Main(string[] args)
        {
            string line;

            Console.WriteLine(EnterValue);
            line = Console.ReadLine();

            Console.WriteLine(GetResult(line));
            Console.Read();
        }
        
        private static int GetResult(string line)
        {
            int result = 0;
            char wordOperator = '+';
            int number = 0;
            foreach (char word in Regex.Replace(line, GetFormulPattern, ""))
            {
                if (Char.IsDigit(word))
                {
                    number = number * 10 + (word - '0');
                    continue;
                }
                result = OperationWithResult(result, number, wordOperator);
                number = 0;
                wordOperator = word;
            }

            return OperationWithResult(result, number, wordOperator);
        }

        private static int OperationWithResult(int result, int number, char wordOperator)
        {
            switch (wordOperator)
            {
                case '+':
                    result += number;
                    break;
                case '-':
                    result -= number;
                    break;
                case '*':
                    result *= number;
                    break;
                case '/':
                    if (number != 0)
                        result /= number;
                    break;
                default:
                    Console.WriteLine(ErrorSybmolValue);
                    break;
            }

            return result;
        }
    }
}
