using System;
using System.Globalization;

namespace ArithmeticCalculator
{
    internal static class task4
    {
        private static void Main()
        {
            bool continueLoop = true;

            while (continueLoop)
            {
                Console.WriteLine("Press any following key to perform an arithmetic");
                Console.WriteLine("operation:");
                Console.WriteLine("1 - Addition");
                Console.WriteLine("2 - Subtraction");
                Console.WriteLine("3 - Multiplication");
                Console.WriteLine("4 - Division");

                int choice = GetMenuChoice();

                double value1 = GetDoubleFromUser("Enter Value 1: ");
                double value2 = GetDoubleFromUser("Enter Value 2: ");

                switch (choice)
                {
                    case 1:
                        PrintResult(value1, value2, "+", Add(value1, value2));
                        break;
                    case 2:
                        PrintResult(value1, value2, "-", Subtract(value1, value2));
                        break;
                    case 3:
                        PrintResult(value1, value2, "*", Multiply(value1, value2));
                        break;
                    case 4:
                        if (IsZero(value2))
                        {
                            Console.WriteLine("Division by zero is not allowed.");
                        }
                        else
                        {
                            PrintResult(value1, value2, "/", Divide(value1, value2));
                        }

                        break;
                    default:
                        // Should not occur because GetMenuChoice enforces valid input.
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine();

                // Prompt user to continue or exit. Accept only Y or N (case-insensitive).
                while (true)
                {
                    Console.Write("Do you want to continue again (Y/N)? ");
                    string response = Console.ReadLine() ?? string.Empty;

                    if (response.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        // continue outer loop
                        break;
                    }

                    if (response.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        continueLoop = false;
                        break;
                    }

                    Console.WriteLine("Please enter 'Y' to continue or 'N' to exit.");
                }

                Console.WriteLine();
            }
        }

        private static int GetMenuChoice()
        {
            while (true)
            {
                Console.Write("> ");
                string raw = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(raw.Trim(), out int parsed) && parsed >= 1 && parsed <= 4)
                {
                    return parsed;
                }

                Console.WriteLine("Please enter a valid option: 1, 2, 3 or 4.");
            }
        }

        private static double GetDoubleFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string raw = Console.ReadLine() ?? string.Empty;
                string trimmed = raw.Trim();

                // Try invariant culture first for predictable parsing (e.g., "." decimal separator),
                // then fall back to current culture.
                double result;
                if (double.TryParse(trimmed, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out result) ||
                    double.TryParse(trimmed, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out result))
                {
                    return result;
                }

                Console.WriteLine("Invalid number. Please enter a numeric value.");
            }
        }

        private static void PrintResult(double a, double b, string op, double result)
        {
            Console.WriteLine("{0} {1} {2} = {3}", FormatNumber(a), op, FormatNumber(b), FormatNumber(result));
        }

        private static string FormatNumber(double value)
        {
            // If the value is a whole number, print without decimal places to match examples like "10 + 20 = 30".
            if (Math.Abs(value - Math.Truncate(value)) < 1e-12)
            {
                long integral = Convert.ToInt64(Math.Truncate(value));
                return integral.ToString(CultureInfo.InvariantCulture);
            }

            return value.ToString(CultureInfo.InvariantCulture);
        }

        private static bool IsZero(double value)
        {
            return Math.Abs(value) < 1e-12;
        }

        // Separate methods for each arithmetic operation
        private static double Add(double x, double y)
        {
            return x + y;
        }

        private static double Subtract(double x, double y)
        {
            return x - y;
        }

        private static double Multiply(double x, double y)
        {
            return x * y;
        }

        private static double Divide(double x, double y)
        {
            return x / y;
        }
    }
}