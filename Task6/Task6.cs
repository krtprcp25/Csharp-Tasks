using System;

namespace Task6
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine("Student Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Grade: " + Grade);
        }

        public bool IsPassed()
        {
            return Grade >= 75.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
            {
                Name = "Marco",
                Age = 20,
                Grade = 85.5
            };

            student.DisplayInfo();
            Console.WriteLine("Status: " + (student.IsPassed() ? "Passed" : "Failed"));
        }
    }
}