using System;

namespace CMS.Data.Models
{
    public class Student
    {
        public Student(int studentId, string firstName, string lastName, int courseId = 0)
        {
            this.StudentId = studentId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CourseId = courseId;
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CourseId { get; set; }
    }

    public class EngineeringStudent : Student
    {
        public EngineeringStudent(int studentId, string firstName, string lastName, int courseId = 0) 
        : base(studentId, firstName, lastName, courseId)
        {
        }
    }

    public class MedicalStudent : Student
    {
        public MedicalStudent(int studentId, string firstName, string lastName, int courseId = 0) 
        : base(studentId, firstName, lastName, courseId)
        {
        }
    }
}
