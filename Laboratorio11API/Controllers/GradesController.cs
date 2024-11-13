using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Laboratorio11API.Models;

namespace Laboratorio11API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly SchoolContext _context;

        public GradesController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Grade> GetAll()
        {
            return _context.Grades.ToList();
        }

        [HttpGet("{id}")]
        public Grade GetById(int id)
        {
            var grade = _context.Grades.FirstOrDefault(x => x.GradeId == id);
            return grade; 
        }

        [HttpPost]
        public void Save(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Update(int id, Grade grade)
        {
            var gradeFound = _context.Grades.Find(id);
            if (gradeFound != null)
            {
                gradeFound.Name = grade.Name;
                gradeFound.Description = grade.Description;
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var grade = _context.Grades.Find(id);
            if (grade != null)
            {
                _context.Grades.Remove(grade);
                _context.SaveChanges();
            }
        }
    }
}
