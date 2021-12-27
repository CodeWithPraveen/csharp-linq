using System;
using System.Collections.Generic;
using CMS.UI.Models;
using System.Linq;

namespace LinqGrouping
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

            //LinqGroupBy();
            //LinqToLookup();
            LinqToLookup_Enumerable();
        }

        static void LinqGroupBy()
        {
            // Query syntax
            Console.WriteLine("Query syntax:");
            var query = from student in students
                            group student by student.CourseId;

            foreach (var item in query)
            {
                Console.WriteLine(item.Key);
                foreach(Student s in item)
                    Console.WriteLine($"{s.FirstName} {s.LastName}");
            }

            // Method syntax
            Console.WriteLine("Method syntax:");
            var methodQuery = students.GroupBy(student => student.CourseId);
            foreach (var item in methodQuery)
            {
                Console.WriteLine(item.Key);
                foreach(Student s in item)
                    Console.WriteLine($"{s.FirstName} {s.LastName}");
            }
        }

        static void LinqToLookup()
        {
            // Method syntax
            Console.WriteLine("Method syntax:");
            var methodQuery = students.ToLookup(student => student.CourseId);

            for(int i = 1; i<4; i++)
            {
                Console.WriteLine(i);
                foreach(Student s in methodQuery[i])
                    Console.WriteLine($"{s.FirstName} {s.LastName}");
            }
        }

        static void LinqToLookup_Enumerable()
        {
            // Method syntax
            Console.WriteLine("Method syntax:");
            var methodQuery = students.ToLookup(student => student.CourseId);

            foreach(var item in methodQuery)
            {
                Console.WriteLine(item.Key);
                foreach(Student s in item)
                    Console.WriteLine($"{s.FirstName} {s.LastName}");
            }
        }
    }
}
