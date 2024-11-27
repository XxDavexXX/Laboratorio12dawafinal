using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratorio11API.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        [NotMapped]
        public DateTime Date { get; set; }
    }
}
