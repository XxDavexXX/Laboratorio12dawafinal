using Laboratorio11API.Models;
using Laboratorio11API.Request;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio11API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnrollmentsController:ControllerBase
    {
        private readonly SchoolContext _context;

        public EnrollmentsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Enrollment>  GetAll()
        {
            return _context.Enrollments.ToList();
        }

        [HttpPost]
        public void SaveByListCourse(MatriculaRequestV1 request)
        {
            List<Enrollment> enrollments = new List<Enrollment>();  
            foreach (var courseId in request.CoursesIds)
            {
                enrollments.Add(new Enrollment
                {
                    StudentId=request.StudentId,
                    CourseId=courseId,
                });
            }
            _context.Enrollments.AddRange(enrollments);
            _context.SaveChanges();
        }


    }
}
