using Laboratorio11API.Models;
using Laboratorio11API.Request;
using Laboratorio11API.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio11API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController:ControllerBase
    {
        private readonly SchoolContext _context;
        public CoursesController(SchoolContext schoolContext)
        {
            _context =schoolContext;
        }

        [HttpGet]
        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        [HttpGet]
        public List<CourseResponseV1> GetAllName()
        {
            List<Course> courses = _context.Courses.ToList();

            List<CourseResponseV1> coursesReponses = courses.Select(x => new CourseResponseV1
            {
                Id = x.CourseId,
                Name = x.Name
            }).ToList();
            return coursesReponses; 
            
        }

        [HttpPost]
        public void Save(CourseRequestV1 course) {

            Course courseSave = new Course
            {
                Credit = course.Credit,
                Name = course.Name
            };
            _context.Courses.Add(courseSave);
            _context.SaveChanges();
        }
        
        [HttpPost]
        public void UpdateCredit(CourseRequestV2 request)
        {
            Course course = _context.Courses.FirstOrDefault(x=>x.CourseId==request.Id);
            course.Credit=request.Credit;

            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCourse(CourseRequestV3 request)
        {
            Course course = _context.Courses.Find(request.CourseId);
            if(course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();

            }
        }

        [HttpDelete]
        public void DeleteCourseList(CourseRequestV4 request)
        {
            foreach (var id in request.Ids)
            {
                Course course = _context.Courses.Find(id);
                if (course != null)
                {
                    _context.Remove(course);
                    _context.SaveChanges();
                }
            }

        }
    }
}
