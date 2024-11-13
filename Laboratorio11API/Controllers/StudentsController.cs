using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laboratorio11API.Models;

namespace Laboratorio11API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Student> GetAll()
        {
            return _context.Students.Include(s => s.Grade).ToList();
        }

        [HttpGet("{id}")]
        public Student GetById(int id)
        {
            var student = _context.Students.Include(s => s.Grade).FirstOrDefault(s => s.StudentId == id);
            return student;
        }

        [HttpPost]
        public void Save(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Update(int id, Student student)
        {
            var existingStudent = _context.Students.Find(id);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Phone = student.Phone;
                existingStudent.Email = student.Email;
                existingStudent.GradeId = student.GradeId;

                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
