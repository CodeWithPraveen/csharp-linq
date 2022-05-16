using System;
using System.Collections.Generic;
using System.Linq;
using CMS.UI.Models;

namespace LinqProjection
{
    class Program
    {
        static List<Student> students = new List<Student>();

        static void Initialize()
        {
            students.Add(new Student(101, "James", "Smith"));
            students.Add(new Student(102, "Robert", "Smith"));
            // students.Add(new Student(103, "Maria", "Rodriguez"));
            // students.Add(new Student(104, "David", "Smith"));
            // students.Add(new Student(105, "James", "Johnson"));
            // students.Add(new Student(106, "John", "SevenLast"));
            // students.Add(new Student(107, "Maria", "Garcia"));
            // students.Add(new Student(108, "Mary", "Smith"));
        }
        static void Main(string[] args)
        {
            Initialize();

            //LinqSelect();
            //LinqSelectAnonymous();
            LinqSelectMany();
        }

        static void LinqSelect()
        {
            // Query syntax
            Console.WriteLine("\nQuery syntax:");
            var query = from student in students
                            select (student.StudentId, student.FirstName);
            foreach (var item in query)
            {
                Console.WriteLine($"{item.StudentId} {item.FirstName}");
            }

            // Method syntax
            Console.WriteLine("\nMethod syntax:");
            var methodQuery = students.Select(student => (student.StudentId, student.FirstName));
            foreach (var item in methodQuery)
            {
                Console.WriteLine($"{item.StudentId} {item.FirstName}");
            }
        }

        static void LinqSelectAnonymous()
        {
            // Query syntax
            Console.WriteLine("\nQuery syntax:");
            var query = from student in students
                            select new {
                                ID = student.StudentId,
                                Name = student.FirstName + student.LastName
                            };
            foreach (var item in query)
            {
                Console.WriteLine($"{item.ID} {item.Name}");
            }

            // Method syntax
            Console.WriteLine("\nMethod syntax:");
            var methodQuery = students.Select(student => new {
                ID = student.StudentId,
                Name = student.FirstName + student.LastName
            });
            foreach (var item in methodQuery)
            {
                Console.WriteLine($"{item.ID} {item.Name}");
            }
        }

        static void LinqSelectMany()
        {
            // Query syntax
            Console.WriteLine("\nQuery syntax:");
            var query = from student in students
                            from a in student.FirstName.ToArray()
                            select a;
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            // Method syntax
            Console.WriteLine("\nMethod syntax:");
            var methodQuery = students.SelectMany(student => student.FirstName.ToArray(), (students, a) => (a));
            foreach (var item in methodQuery)
            {
                Console.WriteLine(item);
            }
        }
    }
}
