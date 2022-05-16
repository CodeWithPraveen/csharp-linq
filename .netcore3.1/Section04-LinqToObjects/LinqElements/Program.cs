using System;
using System.Collections.Generic;
using CMS.UI.Models;
using System.Linq;

namespace LinqElements
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

            //LinqElement();
            //LinqFirst();
            //LinqLast();
            LinqSingle();
        }

        static void LinqElement()
        {
            // Query syntax
            // Not Applicable (NA)
            
            // Method syntax
            Console.WriteLine("Method syntax:");
            Student query = students.ElementAt(0);
            Console.WriteLine($"{query.FirstName} {query.LastName}");

            Student queryElementAtOrDefault = students.ElementAtOrDefault(10);
            if(queryElementAtOrDefault != null)
                Console.WriteLine($"{query.FirstName} {query.LastName}");
            else
                Console.WriteLine("The record doesn't exist");
        }

        static void LinqFirst()
        {
            Console.WriteLine("\nFirst");
            Student query = students.Where(student => student.LastName.Equals("Smith"))
                                .First();
            Console.WriteLine($"{query.FirstName} {query.LastName}");

            Console.WriteLine("\nFirstOrDefault");
            Student query2 = students.Where(student => student.LastName.Equals("Kumar"))
                                .FirstOrDefault();
            if(query2 == null)
                Console.WriteLine("No record exists");
            else
                Console.WriteLine($"{query2.FirstName} {query2.LastName}");
        }

        static void LinqLast()
        {
            Console.WriteLine("\nLast");
            Student query = students.Where(student => student.LastName.Equals("Smith"))
                                .Last();
            Console.WriteLine($"{query.FirstName} {query.LastName}");

            Console.WriteLine("\nLastOrDefault");
            Student query2 = students.Where(student => student.LastName.Equals("Kumar"))
                                .LastOrDefault();
            if(query2 == null)
                Console.WriteLine("No record exists");
            else
                Console.WriteLine($"{query2.FirstName} {query2.LastName}");
        }

        static void LinqSingle()
        {
            Console.WriteLine("\nSingle");
            Student query = students.Where(student => student.LastName.Equals("Garcia"))
                                .Single();
            Console.WriteLine($"{query.FirstName} {query.LastName}");

            Console.WriteLine("\nSingleOrDefault");
            Student query2 = students.Where(student => student.LastName.Equals("Kumar"))
                                .SingleOrDefault();
            if(query2 == null)
                Console.WriteLine("No record exists");
            else
                Console.WriteLine($"{query2.FirstName} {query2.LastName}");
        }
    }
}
