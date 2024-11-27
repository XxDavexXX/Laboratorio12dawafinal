using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Laboratorio11API.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string? Description { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string? Grade { get; set; }

        [JsonIgnore]

        public List<Enrollment>? Enrollments { get; set; }
    }
}
