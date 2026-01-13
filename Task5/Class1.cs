using System;

namespace Task5
{
    public class Class1
    {
        public static void Main()
        {
            Console.WriteLine("Press any following key");
            int totalStudents = ReadPositiveInt("Enter Total Students : ");

            // columns: 0 = Name (string), 1 = English (int), 2 = Math (int), 3 = Computer (int), 4 = Total (int)
            var students = new object[totalStudents, 5];

            for (int i = 0; i < totalStudents; i++)
            {
                Console.WriteLine();
                Console.Write("Enter Student Name : ");
                string name = ReadNonEmptyString();
                int eng = ReadMark("Enter English Marks (Out Of 100) : ");
                int math = ReadMark("Enter Math Marks (Out Of 100) : ");
                int comp = ReadMark("Enter Computer Marks (Out Of 100) : ");

                int total = eng + math + comp;

                students[i, 0] = name;
                students[i, 1] = eng;
                students[i, 2] = math;
                students[i, 3] = comp;
                students[i, 4] = total;
            }

            // Sort students by total descending (stable selection-like swap)
            for (int i = 0; i < totalStudents - 1; i++)
            {
                int bestIndex = i;
                for (int j = i + 1; j < totalStudents; j++)
                {
                    if ((int)students[j, 4] > (int)students[bestIndex, 4])
                    {
                        bestIndex = j;
                    }
                }

                if (bestIndex != i)
                {
                    SwapRows(students, i, bestIndex);
                }
            }

            Console.WriteLine();
            Console.WriteLine("****************Report Card*******************");

            for (int i = 0; i < totalStudents; i++)
            {
                Console.WriteLine("****************************************");
                string name = (string)students[i, 0];
                int total = (int)students[i, 4];
                Console.WriteLine($"Student Name: {name}, Position: {i + 1}, Total:");
                Console.WriteLine($"{total}/300");
                Console.WriteLine("****************************************");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (int.TryParse(s, out int v) && v > 0)
                {
                    return v;
                }

                Console.WriteLine("Please enter a valid positive integer.");
            }
        }

        private static string ReadNonEmptyString()
        {
            while (true)
            {
                string s = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(s))
                    return s.Trim();

                Console.Write("Name cannot be empty. Enter Student Name : ");
            }
        }

        private static int ReadMark(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (int.TryParse(s, out int mark) && mark >= 0 && mark <= 100)
                {
                    return mark;
                }

                Console.WriteLine("Invalid input. Enter an integer between 0 and 100.");
            }
        }

        private static void SwapRows(object[,] arr, int r1, int r2)
        {
            int cols = arr.GetLength(1);
            for (int c = 0; c < cols; c++)
            {
                object tmp = arr[r1, c];
                arr[r1, c] = arr[r2, c];
                arr[r2, c] = tmp;
            }
        }
    }
}