using API.Services.Entities;
using System.Data.Entity;

namespace API.Services.Repositories
{
    class AppDataContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTemplate> CourseTemplates { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<WaitingList> WaitingLists { get; set; }
    }
}