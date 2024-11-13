using Microsoft.EntityFrameworkCore;

namespace Laboratorio11API.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }//"Grades" sera el nombre con el que se pondra en la base de datos.
        public DbSet<Enrollment>Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-AVILCATO\\SQLEXPRESS;Database=APIDemoDB;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
