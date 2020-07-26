using System;
using System.Collections.Generic;
using CMS.UI.Models;
using System.Linq;

namespace LinqJoin
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
            students.Add(new Student(107, "Maria", "Garcia", 1));
            students.Add(new Student(108, "Mary", "Smith", 2));

            courses.Add(new Course(1, "Computer Science"));
            courses.Add(new Course(2, "Marketing"));
            courses.Add(new Course(3, "Accounting"));
        }
        static void Main(string[] args)
        {
            Initialize();

            //LinqJoinOperator();
            LinqGroupJoin();
        }

        static void LinqJoinOperator()
        {
            // Query syntax
            Console.WriteLine("Query syntax:");
            var query = from student in students
                            join course in courses
                            on student.CourseId equals course.CourseId
                            select new { student.StudentId, student.FirstName, course.CourseName };                                      
            foreach (var item in query)
            {
                Console.WriteLine($"{item.StudentId} {item.FirstName} {item.CourseName}");
            }

            // Method syntax
            Console.WriteLine("Method syntax:");
            var methodQuery = students.Join(courses, student => student.CourseId,
                                        course => course.CourseId,
                                        (s, c) => new { s.StudentId, s.FirstName, c.CourseName});
            foreach (var item in methodQuery)
            {
                Console.WriteLine($"{item.StudentId} {item.FirstName} {item.CourseName}");
            }
        }

        static void LinqGroupJoin()
        {
            // Query syntax
            Console.WriteLine("Query syntax:");
            var query = from course in courses
                        join student in students
                        on course.CourseId equals student.CourseId
                        into CourseStudents
                        select new {course.CourseName, CourseStudents};
            foreach(var item in query)
            {
                Console.WriteLine("\n" + item.CourseName);

                foreach(var student in item.CourseStudents)
                    Console.WriteLine($"{student.StudentId} {student.FirstName}");
            }

            // Method syntax
            Console.WriteLine("Method syntax:");
            var methodQuery = courses.GroupJoin(students,
                                course => course.CourseId,
                                student => student.CourseId,
                                (c, CourseStudents) => new {c.CourseName, CourseStudents});
            foreach(var item in methodQuery)
            {
                Console.WriteLine("\n" + item.CourseName);

                foreach(var student in item.CourseStudents)
                    Console.WriteLine($"{student.StudentId} {student.FirstName}");
            }
        }
    }
}
