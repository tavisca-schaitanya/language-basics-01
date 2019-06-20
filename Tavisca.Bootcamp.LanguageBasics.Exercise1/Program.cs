using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int equateResults(string expectedResult, string actualResult)
        {
            System.Console.WriteLine(expectedResult);
            if(expectedResult.Length != actualResult.Length)
                return -1;
            int pos = actualResult.IndexOf('?');
            return Convert.ToInt32(expectedResult[pos]);    
        }

        public static int FindDigit(string equation)
        {
            string[] splittedEquation = equation.Split('=');
            string result = splittedEquation[1];
            string operand1 = splittedEquation[0].Split('*')[0];
            string operand2 = splittedEquation[0].Split('*')[1];
            int missingDigit = -1;
            if(result.Contains('?'))
            {
                int expectedResult = Convert.ToInt32(operand1)*Convert.ToInt32(operand2);
                missingDigit = equateResults(Convert.ToString(expectedResult), result);
            }
            else if(operand1.Contains('?'))
            {
                float expectedResult = (float)Convert.ToInt32(result)/Convert.ToInt32(operand2);
                missingDigit = equateResults(Convert.ToString(expectedResult), operand1);
            }
            else if(operand2.Contains('?'))
            {
                float expectedResult = (float)Convert.ToInt32(result)/Convert.ToInt32(operand1);
                missingDigit = equateResults(Convert.ToString(expectedResult), operand2);
            }
            return missingDigit; 
        }
    }
}
