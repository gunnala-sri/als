using System;

namespace FizzBuzz
{
    /// <summary>
    /// App Entry point class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.Write(getPrintingNumber(i) + " ");

                if (i % 10 == 0)
                    Console.WriteLine();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Gets the printable format for given number
        /// </summary>
        /// <param name="num">integer</param>
        /// <returns>string in pritable format</returns>
        private static string getPrintingNumber(int num)
        {
            if (MultipleOf3(num))
            {
                if (MultipleOf5(num))
                    return "FizzBuzz";

                return "Fizz";
            }
            if (MultipleOf5(num))
                return "Buzz";

            return num.ToString();
        }

        /// <summary>
        /// Returns true if multiples of 3, else false
        /// </summary>
        /// <param name="num">integer</param>
        /// <returns>bool</returns>
        private static bool MultipleOf3(int num)
        {
            return (num % 3) == 0;
        }

        /// <summary>
        /// Returns true if multiples of 5, else false
        /// </summary>
        /// <param name="num">integer</param>
        /// <returns>bool</returns>
        private static bool MultipleOf5(int num)
        {
            return (num % 5) == 0;
        }
    }
}
