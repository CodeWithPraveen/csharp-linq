using System;
using System.Collections.Generic;
using CMS.Data.Models;
using System.Linq;
using System.Xml.Linq;

namespace LinqToXml
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

            //LinqToXml_Write();
            LinqToXml_Read();
        }
        
        static void LinqToXml_Write()
        {
            // Query syntax
            Console.WriteLine("Query syntax:");
            XElement xml = new XElement("Students", 
                                    from student in students
                                    select new XElement("Student", 
                                        new XAttribute("CourseId", student.CourseId),
                                        new XElement("StudentId", student.StudentId),
                                        new XElement("FirstName", student.FirstName),
                                        new XElement("LastName", student.LastName)));
            Console.WriteLine(xml.ToString());

            // Method syntax
            Console.WriteLine("\nMethod syntax:");
            XElement xmlMethod = new XElement("Students", 
                                    students.Select(student => new XElement("Student", 
                                        new XAttribute("CourseId", student.CourseId),
                                        new XElement("StudentId", student.StudentId),
                                        new XElement("FirstName", student.FirstName),
                                        new XElement("LastName", student.LastName))));
            Console.WriteLine(xmlMethod.ToString());
        }

        static void LinqToXml_Read()
        {
            XDocument doc = XDocument.Load("sample.xml");

            var query = doc.Descendants("Students")
                            .Descendants("Student")
                            .Select(student => new {
                                StudentId = student.Element("StudentId").Value,
                                FirstName = student.Element("FirstName").Value,
                                LastName = student.Element("LastName").Value,
                                CourseId = student.Attribute("CourseId").Value
                            });
            foreach (var item in query)
            {
                Console.WriteLine($"{item.StudentId} {item.FirstName} {item.LastName} {item.CourseId}");
            }
        }
        
    }
}
