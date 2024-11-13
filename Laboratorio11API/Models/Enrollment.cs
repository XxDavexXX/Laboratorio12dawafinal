namespace Laboratorio11API.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student Students { get; set; }
        public Course Courses { get; set; }
        public DateTime Date { get; set; }
    }
}
