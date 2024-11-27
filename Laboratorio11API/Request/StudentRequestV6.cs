using Laboratorio11API.Models;

namespace Laboratorio11API.Request
{
    public class StudentRequestV6
    {
        public int GradeId {get;set;}
        public  List<StudentRequestV7> students {get;set;}
    }
}
