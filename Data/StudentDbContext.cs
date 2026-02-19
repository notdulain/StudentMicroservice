using Microsoft.EntityFrameworkCore;
using StudentMicroservice.Models;

namespace StudentMicroservice.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();
    }
}
