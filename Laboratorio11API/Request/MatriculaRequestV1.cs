namespace Laboratorio11API.Request
{
    public class MatriculaRequestV1
    {
        public int StudentId { get; set; }
        public List<int> CoursesIds { get; set; }
    }
}
