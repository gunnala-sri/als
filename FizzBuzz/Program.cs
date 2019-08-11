using System;

namespace FizzBuzz
{
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

        private static bool MultipleOf3(int num)
        {
            return (num % 3) == 0;
        }

        private static bool MultipleOf5(int num)
        {
            return (num % 5) == 0;
        }
    }
}
