using System;
using System.Collections.Generic;
using CMS.UI.Models;
using System.Linq;

namespace LinqFiltering
{
    class Program
    {
        static List<Student> students = new List<Student>();

        static void Initialize()
        {
            students.Add(new EngineeringStudent(101, "James", "Smith"));
            students.Add(new EngineeringStudent(102, "Robert", "Smith"));
            students.Add(new EngineeringStudent(103, "Maria", "Rodriguez"));
            students.Add(new MedicalStudent(104, "David", "Smith"));
            students.Add(new MedicalStudent(105, "James", "Johnson"));
            students.Add(new EngineeringStudent(106, "John", "SevenLast"));
            students.Add(new MedicalStudent(107, "Maria", "Garcia"));
            students.Add(new MedicalStudent(108, "Mary", "Smith"));
        }
        static void Main(string[] args)
        {
            Initialize();

            LinqOfType();
        }

        static void LinqWhere()
        {
            // Query syntax
            Console.WriteLine("Query syntax:");
            IEnumerable<Student> query = from student in students
                                            where student.LastName.Equals("Smith") 
                                            select student;
            foreach (Student item in query)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            // Method syntax
            Console.WriteLine("Method syntax:");
            IEnumerable<Student> methodQuery = students.Where(student => student.LastName.Equals("Smith"))
                                                .Select(student => student);
            foreach (Student item in methodQuery)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
    
        static void LinqOfType()
        {
            IEnumerable<EngineeringStudent> enggStudents = students.OfType<EngineeringStudent>();
            foreach (EngineeringStudent item in enggStudents)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
    }
}
