using System;

namespace Task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 3, 7, 12, 19, 21, 25, 30 };
            Console.Write("Enter a number to search for: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int target))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return;
            }

            bool found = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == target)
                {
                    Console.WriteLine($"Number found at position {i}!");
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Number not found in the list.");
            }
        }
    }
}   