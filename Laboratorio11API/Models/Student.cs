using System.Text.Json.Serialization;

namespace Laboratorio11API.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public Grade? Grade { get; set; }
    }
}
