using BIMA.Database.DataSeed;
using BIMA.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Database
{
    public class BIMADbContext : IdentityDbContext<User, Role, long>
    {
        public BIMADbContext(DbContextOptions<BIMADbContext> options) : base(options) {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserQuestionType> UserQuestionTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Navbar> Navbars { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<PlanPrice> PlanPrices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseContent> CourseContents { get; set; }
        public DbSet<UserCourseContent> UserCourseContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
            .HasOne<User>(sc => sc.User)
            .WithMany(s => s.UserRoles)
            .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne<Role>(sc => sc.Role)
                .WithMany(s => s.UserRoles)
                .HasForeignKey(sc => sc.RoleId);

            modelBuilder.Entity<City>()
                .HasOne<Country>(c => c.Country)
                .WithMany(s => s.Cities)
                .HasForeignKey(c => c.CountryCode);

            modelBuilder.Entity<UserQuestionType>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.UserQuestionTypes)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<Payment>()
                .HasOne<User>(p => p.User)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.UserId);

            ModelBuilderExtensions.Seed(modelBuilder);
        }
    }
}
