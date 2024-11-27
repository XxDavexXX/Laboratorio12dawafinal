using Laboratorio11API.Models;

namespace Laboratorio11API.Request
{
    public class StudentRequestV3
    {
        public int GradeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }   
    }
}
