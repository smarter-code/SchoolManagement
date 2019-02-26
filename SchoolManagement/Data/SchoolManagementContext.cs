﻿using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Data
{
    public class SchoolManagementContext : DbContext
    {

        public DbSet<ClassRoom> ClassRooms { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // ...
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);


            modelBuilder.Entity<StudentCourse>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);


        }


        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options) : base(options)
        {

        }
    }
}
