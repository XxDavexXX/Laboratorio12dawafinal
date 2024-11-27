using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laboratorio11API.Models;
using Laboratorio11API.Request;
using Laboratorio11API.Response;

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

        [HttpPost]
        public List<Student> GetByNameAndLastNameAndEmail(StudentRequestV1 student)
        {
            return _context.Students.Where(x=>x.FirstName==student.Name && x.LastName==student.LastName && x.Email==student.Email).OrderByDescending(x=>x.LastName).ToList();
        }


        [HttpPost]
        public List<StudentResponseV2> GetByNameAndGrade(StudentRequestV2 request)
        {
            
            List<Enrollment> enrollments = _context.Enrollments.Where(x => x.Student.FirstName == request.Name && x.Student.GradeId == request.GradeId)
                                                                .Include(x=>x.Student)
                                                                    .ThenInclude(x=>x.Grade)
                                                                .OrderByDescending(x=>x.Course.Name).ToList();
            List<StudentResponseV2> response = enrollments.Select(x =>
                new StudentResponseV2
                {
                    FirstName = x.Student.FirstName,
                    LastName = x.Student.LastName,
                    Email = x.Student.Email,
                    Grade = x.Student.Grade,
                    Phone = x.Student.Phone,
                    StudentId = x.StudentId
                }
            ).ToList();
            return response;
        }

        [HttpGet("{id}")]
        public Student GetById(int id)
        {
            var student = _context.Students.Include(s => s.Grade).FirstOrDefault(s => s.StudentId == id);
            return student;
        }

        [HttpPost]
        public void Save(StudentRequestV3 student)
        {
            Student studentSave = new Student
            {
                GradeId = student.GradeId,
                FirstName = student.firstName,
                LastName = student.lastName,
                Email = student.email,
                Phone = student.phone
            };
            _context.Students.Add(studentSave);
            _context.SaveChanges();
        }


        [HttpPut]
        public void UpdateContactData(StudentRequestV4 request)
        {
            Student student = _context.Students.Find(request.StudentId);
            _context.Entry(student).State = EntityState.Modified;

            if (student != null)
            {
                student.Phone = request.Phone;
                student.Email = request.Email;
             }
            _context.SaveChanges();
        }

        [HttpPut]
        public void UpdatePersonalData(StudentRequestV5 request)
        {
            Student student = _context.Students.Find(request.StudentId);
            _context.Entry(student).State = EntityState.Modified;

            if (student != null)
            {
                student.FirstName = request.FirstName;
                student.LastName = request.LastName;
            }
            _context.SaveChanges();
        }

        [HttpPost]
        public void SaveListStudents(StudentRequestV6 request)
        {
            List<Student> students = new List<Student>();
            foreach (var studentRequest in request.students)
            {
                students.Add(new Student
                {
                    FirstName = studentRequest.FirstName,
                    LastName = studentRequest.LastName,
                    Email = studentRequest.Email,
                    Phone = studentRequest.Phone,
                    GradeId = request.GradeId
                });
            }
            _context.AddRange(students);
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
