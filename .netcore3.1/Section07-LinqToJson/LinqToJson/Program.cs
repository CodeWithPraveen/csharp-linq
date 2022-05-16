using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CMS.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Console;

namespace LinqToJson
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Course> courses = new List<Course>();
        static void Main(string[] args)
        {
            Initialize();

            //CreatingJsonManually();
            //CreatingJsonDeclaratively();
            //CreatingJsonUsingLinq();
            //CreatingJsonFromObject();

            //ParsingJsonFromString();
            //ParsingJsonFromStream();

            //QueryingJsonUsingPropertyName();
            //QueryingJsonUsingCollectionIndex();
            //QueryingJsonUsingLinq();
            QueryingJsonUsingSelectToken();
        }

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

            courses.Add(new Course(1, "ComputerScience"));
            courses.Add(new Course(2, "Marketing"));
            courses.Add(new Course(3, "Accounting"));
        }

        static void CreatingJsonManually()
        {
            // {
            //     "StudentId": 101,
            //     "FirstName": "James",
            //     "LastName": "Smith",
            //     "Course": {
            //         "CourseId": 1,
            //         "CourseName": "ComputerScience"
            //     }
            // }

            JObject student = new JObject();
            student.Add("StudentId", 101);
            student.Add("FirstName", "James");
            student.Add("LastName", "Smith");

            JObject course = new JObject();
            course.Add("CourseId", 1);
            course.Add("CourseName", "ComputerScience");
            student.Add("Course", course);

            WriteLine(student);
        }

        static void CreatingJsonDeclaratively()
        {
            // {
            //     "Students": {
            //         "Student": {
            //             "StudentId": 101,
            //             "FirstName": "James",
            //             "LastName": "Smith"
            //         }
            //     }
            // }

            JObject root =
                new JObject(
                    new JProperty("Students",
                        new JObject(
                            new JProperty("Student",
                                new JObject(
                                    new JProperty("StudentId", 101),
                                    new JProperty("FirstName", "James"),
                                    new JProperty("LastName", "Smith")
                                ))
                        ))
                );

            WriteLine(root);
        }

        static void CreatingJsonUsingLinq()
        {
            // {
            //     "Students": [
            //         {
            //             "StudentId": 101,     
            //             "FirstName": "James", 
            //             "LastName": "Smith"
            //         },
            //         {
            //             "StudentId": 102,     
            //             "FirstName": "Robert",
            //             "LastName": "Smith"
            //         },
            //         ...
            //     ]
            // }

            JObject root =
                new JObject(
                    new JProperty("Students",
                        new JArray(
                           students.Select(s => new JObject(
                               new JProperty("StudentId", s.StudentId),
                               new JProperty("FirstName", s.FirstName),
                               new JProperty("LastName", s.LastName)
                           )) 
                        )
                    ));

            //WriteLine(root);

            JObject rootQuery =
                new JObject(
                    new JProperty("Students",
                        new JArray(
                            from s in students
                            select new JObject(
                               new JProperty("StudentId", s.StudentId),
                               new JProperty("FirstName", s.FirstName),
                               new JProperty("LastName", s.LastName)
                           ))
                        )
                    );
            WriteLine(rootQuery);
        }

        static void CreatingJsonFromObject()
        {
            Student student = new Student(101, "James", "Smith", 1);
            JObject root = JObject.FromObject(student);

            //WriteLine(root);

            JObject rootArray = JObject.FromObject(new
            {
                students
            });
            WriteLine(rootArray);
        }

        static void ParsingJsonFromString()
        {
            string student = @"{
                                'StudentId': 101,
                                'FirstName': 'James',
                                'LastName': 'Smith',
                                'CourseId': 1
                                }";

            JObject studentObject = JObject.Parse(student);
            WriteLine(studentObject);
        }

        static void ParsingJsonFromStream()
        {
            JToken token;
            using (StreamReader streamReader = new StreamReader("students.json"))
            {
                token = JToken.ReadFrom(new JsonTextReader(streamReader));
            }

            WriteLine(token);
        }

        static void QueryingJsonUsingPropertyName()
        {
            Student student = new Student(101, "James", "Smith", 1);
            JObject root = JObject.FromObject(student);

            WriteLine(root["StudentId"]);
            WriteLine(root["FirstName"]);
            WriteLine(root["LastName"]);
            WriteLine(root["CourseId"]);
        }

        static void QueryingJsonUsingCollectionIndex()
        {
            JToken token;
            using (StreamReader streamReader = new StreamReader("students.json"))
            {
                token = JToken.ReadFrom(new JsonTextReader(streamReader));
            }

            JArray students = (JArray)token["Students"];
            WriteLine(students.Count);

            foreach (var item in students)
            {
                WriteLine(item["StudentId"]);
                WriteLine(item["FirstName"]);
                WriteLine(item["LastName"]);
                WriteLine(item["CourseId"]);
            }
        }

        static void QueryingJsonUsingLinq()
        {
            JToken token;
            using (StreamReader streamReader = new StreamReader("students.json"))
            {
                token = JToken.ReadFrom(new JsonTextReader(streamReader));
            }

            // Query syntax
            IEnumerable<JToken> query = from s in token["Students"]
                                        select s["StudentId"];

            // Method syntax
            IEnumerable<JToken> queryMethod = token["Students"]
                                                .Select(s => s["StudentId"]);

            foreach (var item in queryMethod)
            {
                WriteLine(item);
            }
        }

        static void QueryingJsonUsingSelectToken()
        {
            JToken token;
            using (StreamReader streamReader = new StreamReader("students.json"))
            {
                token = JToken.ReadFrom(new JsonTextReader(streamReader));
            }

            int studentId = (int)token.SelectToken("Students[4].StudentId");
            WriteLine($"StudentId in 5th pos = {studentId}");

            JToken query = token.SelectToken("Students[4]");
            foreach (var item in query)
            {
                WriteLine(item);
            }
        }
    }
}
