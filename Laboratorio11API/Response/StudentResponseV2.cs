using Laboratorio11API.Models;

namespace Laboratorio11API.Response
{
    public class StudentResponseV2
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Grade Grade { get; set; }
    }
}

