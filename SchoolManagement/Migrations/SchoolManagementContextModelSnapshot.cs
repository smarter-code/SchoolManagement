﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManagement.Data;

namespace SchoolManagement.Migrations
{
    [DbContext(typeof(SchoolManagementContext))]
    partial class SchoolManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolManagement.Data.ClassRoom", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.HasKey("RecordId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("SchoolManagement.Data.Course", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseCode");

                    b.Property<string>("CourseName");

                    b.HasKey("RecordId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SchoolManagement.Data.Schedule", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClassRoomRecordId");

                    b.Property<int?>("CourseRecordId");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("RecordId");

                    b.HasIndex("ClassRoomRecordId");

                    b.HasIndex("CourseRecordId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("SchoolManagement.Data.Student", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PersonNumber");

                    b.HasKey("RecordId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolManagement.Data.StudentCourse", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("CourseId");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("SchoolManagement.Data.Schedule", b =>
                {
                    b.HasOne("SchoolManagement.Data.ClassRoom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomRecordId");

                    b.HasOne("SchoolManagement.Data.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseRecordId");
                });

            modelBuilder.Entity("SchoolManagement.Data.StudentCourse", b =>
                {
                    b.HasOne("SchoolManagement.Data.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolManagement.Data.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
