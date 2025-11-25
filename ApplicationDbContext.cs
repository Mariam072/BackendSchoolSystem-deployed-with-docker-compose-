using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
using System.Text.RegularExpressions;

using System.Collections.Generic;
namespace SchoolSystem
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor receives DbContextOptions via Dependency Injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        // DbSet represents a table in the database for a specific model
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<SchoolSupplies> SchoolSupplies { get; set; }
    }
}
