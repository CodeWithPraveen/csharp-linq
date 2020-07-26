namespace CMS.UI.Models
{
    public class Course
    {
        public Course(int courseId, string courseName)
        {
            this.CourseId = courseId;
            this.CourseName = courseName;
        }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}