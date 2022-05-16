using System;
using System.Collections.Generic;
using System.Linq;
using CMS.UI.Models;

namespace LinqSorting
{
    class Program
    {
        static List<Student> students = new List<Student>();

        static void Initialize()
        {
            students.Add(new Student(101, "James", "Smith"));
            students.Add(new Student(102, "Robert", "Smith"));
            students.Add(new Student(103, "Maria", "Rodriguez"));
            students.Add(new Student(104, "David", "Smith"));
            students.Add(new Student(105, "James", "Johnson"));
            students.Add(new Student(106, "John", "SevenLast"));
            students.Add(new Student(107, "Maria", "Garcia"));
            students.Add(new Student(108, "Mary", "Smith"));
        }
        static void Main(string[] args)
        {
            Initialize();

            //LinqOrderBy();
            //LinqOrderByDescending();
            //LinqThenBy();
            //LinqThenByDescending();
            LinqReverse();
        }

        static void LinqOrderBy()
        {
            // Query syntax
            Console.WriteLine("\nQuery syntax:");
            IEnumerable<Student> query = from student in students
                                            orderby student.FirstName
                                            select student;
            foreach (Student item in query)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            // Method syntax
            Console.WriteLine("\nMethod syntax:");
            IEnumerable<Student> methodQuery = students.OrderBy(students => students.FirstName);                                
            foreach (Student item in methodQuery)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }

        static void LinqOrderByDescending()
        {
            // Query syntax
            Console.WriteLine("\nQuery syntax:");
            IEnumerable<Student> query = from student in students
                                            orderby student.FirstName descending
                                            select student;
            foreach (Student item in query)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            // Method syntax
            Console.WriteLine("\nMethod syntax:");
            IEnumerable<Student> methodQuery = students.OrderByDescending(students => students.FirstName);                                
            foreach (Student item in methodQuery)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
    
        static void LinqThenBy()
        {
            // Query syntax
            Console.WriteLine("\nQuery syntax:");
            IEnumerable<Student> query = from student in students
                                            orderby student.FirstName, student.LastName
                                            select student;
            foreach (Student item in query)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            // Method syntax
            Console.WriteLine("\nMethod syntax:");
            IEnumerable<Student> methodQuery = students.OrderBy(students => students.FirstName)
                                                    .ThenBy(student => student.LastName);                                
            foreach (Student item in methodQuery)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }

        static void LinqThenByDescending()
        {
            // Query syntax
            Console.WriteLine("\nQuery syntax:");
            IEnumerable<Student> query = from student in students
                                            orderby student.FirstName, student.LastName descending
                                            select student;
            foreach (Student item in query)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            // Method syntax
            Console.WriteLine("\nMethod syntax:");
            IEnumerable<Student> methodQuery = students.OrderBy(students => students.FirstName)
                                                    .ThenByDescending(student => student.LastName);                                
            foreach (Student item in methodQuery)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }

        static void LinqReverse()
        {
            // Method syntax
            students.Reverse();

            foreach (Student item in students)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
    }
}
