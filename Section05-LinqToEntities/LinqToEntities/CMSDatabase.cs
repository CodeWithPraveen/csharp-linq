using Microsoft.EntityFrameworkCore;

namespace LinqToEntities
{
    public class CMSDatabase : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "CMS.db");

            builder.UseSqlite($"Filename={path}");
        }
    }
}