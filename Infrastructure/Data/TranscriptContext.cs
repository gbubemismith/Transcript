using System.Reflection;
using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TranscriptContext : IdentityDbContext<User, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>,
        IdentityUserToken<int>>
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

            //added for heroku deployment
            modelBuilder.Entity<AppRole>(entity => entity.Property(m => m.Id).HasMaxLength(127));
            modelBuilder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(127));
            modelBuilder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(127));
            modelBuilder.Entity<AppUserRole>(entity => entity.Property(m => m.UserId).HasMaxLength(127));
            modelBuilder.Entity<AppUserRole>(entity => entity.Property(m => m.RoleId).HasMaxLength(127));
            modelBuilder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(127));
            modelBuilder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(127));
            modelBuilder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.Name).HasMaxLength(127));

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}