using System;
using System.Collections.Generic;
using CMS.UI.Models;
using System.Linq;

namespace LinqQuantifier
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

            LinqQuantifierOperations();
        }

        static void LinqQuantifierOperations()
        {
            // Query syntax
            // Not Applicable (NA)
            
            // Method syntax
            Console.WriteLine("Method syntax: All");
            bool query1 = students.All(student => student.FirstName.Length > 5);
            Console.WriteLine(query1);

            Console.WriteLine("Method syntax: Any");
            bool query2 = students.Any(student => student.FirstName.Length > 5);
            Console.WriteLine(query2);

            Console.WriteLine("Method syntax: Contains");
            bool query3 = students.Contains(students.ElementAt(0));
            Console.WriteLine(query3);
        }
    }
}
