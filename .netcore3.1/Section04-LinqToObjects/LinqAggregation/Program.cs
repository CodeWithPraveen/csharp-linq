using System;
using System.Collections.Generic;
using CMS.UI.Models;
using System.Linq;

namespace LinqAggregation
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Course> courses = new List<Course>();

        static void Initialize()
        {
            students.Add(new Student(101, "James", "Smith", 1));
            students.Add(new Student(102, "Robert", "Smith", 2));
            students.Add(new Student(103, "Maria", "Rodriguez", 3));
            students.Add(new Student(104, "David", "Smith", 1));
            students.Add(new Student(105, "James", "Johnson", 2));
            students.Add(new Student(106, "John", "SevenLast", 3));
            students.Add(new Student(107, "Maria", "Garcia",1));
            students.Add(new Student(108, "Mary", "Smith",2));

            courses.Add(new Course(1, "ComputerScience"));
            courses.Add(new Course(2, "Marketing"));
            courses.Add(new Course(3, "Accounting"));
        }
        static void Main(string[] args)
        {
            Initialize();

            LinqAggregationOperations();
        }

        static void LinqAggregationOperations()
        {
            // Query syntax
            // Not Applicable (NA)
            
            // Method syntax
            Console.WriteLine("Method syntax: Min");
            int query1 = students.Min(student => student.StudentId);
            Console.WriteLine(query1);

            Console.WriteLine("Method syntax: Max");
            int query2 = students.Max(student => student.StudentId);
            Console.WriteLine(query2);

            Console.WriteLine("Method syntax: Average");
            double query3 = students.Average(student => student.StudentId);
            Console.WriteLine(query3);

            Console.WriteLine("Method syntax: Count");
            int query4 = students.Count();
            Console.WriteLine(query4);

            Console.WriteLine("Method syntax: Sum");
            int query5 = students.Sum(student => student.StudentId);
            Console.WriteLine(query5);            
        }
    }
}
