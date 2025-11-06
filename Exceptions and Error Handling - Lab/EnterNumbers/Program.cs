using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int Start = 1;
            const int End = 100;

            List<int> numbers = new List<int>();
            int currentStart = Start;

            while (numbers.Count < 10)
            {
                try
                {
                    int number = ReadNumber(currentStart, End);
                    numbers.Add(number);
                    currentStart = number;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                throw new FormatException();
            }

            if (number <= start || number >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - {end}!");
            }

            return number;
        }
    }
}
