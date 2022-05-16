using System;
using System.Linq;

namespace LinqToEntities
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinqToEntities_Projection();
            //LinqToEntities_Aggregation();
            LinqToEntities_Join();
        }

        static void LinqToEntities_Projection()
        {
            CMSDatabase database = new CMSDatabase();

            // Query syntax
            var query = from student in database.Students
                            select new { student.StudentId, student.FirstName };
            foreach(var student in query)
                Console.WriteLine($"{student.StudentId} {student.FirstName}");

            // Method syntax
            var methodQuery = database.Students
                                .Select(student => new {student.StudentId, student.FirstName});
            foreach(var student in methodQuery)
                Console.WriteLine($"{student.StudentId} {student.FirstName}");
        }

        static void LinqToEntities_Aggregation()
        {
            CMSDatabase database = new CMSDatabase();

            Console.WriteLine(database.Students.Count());
            Console.WriteLine(database.Students.Min(student => student.StudentId));
            Console.WriteLine(database.Students.Max(student => student.StudentId));
        }

        static void LinqToEntities_Join()
        {
            CMSDatabase database = new CMSDatabase();

            // Query syntax
            Console.WriteLine("Query syntax:");
            var query = from student in database.Students
                            join course in database.Courses
                            on student.CourseId equals course.CourseId
                            select new { student.StudentId, student.FirstName, course.CourseName };                                      
            foreach (var item in query)
            {
                Console.WriteLine($"{item.StudentId} {item.FirstName} {item.CourseName}");
            }

            // Method syntax
            Console.WriteLine("Method syntax:");
            var methodQuery = database.Students.Join(database.Courses, student => student.CourseId,
                                        course => course.CourseId,
                                        (s, c) => new { s.StudentId, s.FirstName, c.CourseName});
            foreach (var item in methodQuery)
            {
                Console.WriteLine($"{item.StudentId} {item.FirstName} {item.CourseName}");
            }
        }
    }
}
