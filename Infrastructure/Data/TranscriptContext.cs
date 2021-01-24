using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TranscriptContext : DbContext
    {
        public TranscriptContext(DbContextOptions<TranscriptContext> options) : base(options)
        {

        }

        public DbSet<School> School { get; set; }
        public DbSet<SchoolDepartment> SchoolDepartment { get; set; }
        public DbSet<SchoolFaculty> SchoolFaculty { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}