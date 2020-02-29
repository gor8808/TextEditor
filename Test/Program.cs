using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = 100;
            int totalOfEvenNumbers = CalculateEvenNumbersTotalFromRange(range);
            Console.WriteLine(totalOfEvenNumbers);
        }

        private static int CalculateEvenNumbersTotalFromRange(int range)
        {
            int total = 0;
            for (int i = 0; i < range; i++)
            {
                total += CheckEvenNumber(i);
            }

            return total;
        }

        private static int CheckEvenNumber(int number)
        {
            if (number % 2 == 0)
            {
                return number;
            }

            return 0;
        }
    }
}
