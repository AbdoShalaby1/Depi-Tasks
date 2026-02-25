using EF_Core_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Task.Data
{
    internal class DataServices
    {
        public static void ConfigureEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(entity =>
            entity.HasKey(x => new { x.CourseId, x.StudentId })
            );

            modelBuilder.Entity<InstructorCourse>(entity =>
            entity.HasKey(x => new { x.CourseId, x.InstructorId })
            );

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(x => x.Email).IsUnique();
                entity.HasIndex(x => x.StudentNumber).IsUnique();
            });

            modelBuilder.Entity<Instructor>(entity =>
            entity.HasIndex(x => x.Email).IsUnique()
            );

            modelBuilder.Entity<Course>(entity =>
            entity.HasMany(x => x.Exams)
            .WithOne(x => x.Course)
            .OnDelete(DeleteBehavior.Cascade)
            // you must define the relation manually to say on delete cascade
            );

            modelBuilder.Entity<Exam>(entity =>
            entity.HasMany(x => x.Questions)
            .WithOne(x => x.Exam)
            .OnDelete(DeleteBehavior.Cascade)
            );

            modelBuilder.Entity<ExamAttempt>(entity =>
            entity.HasMany(x => x.StudentAnswers)
            .WithOne(x => x.ExamAttempt)
            .OnDelete(DeleteBehavior.Cascade)
            );

            modelBuilder.Entity<Student>(entity =>
            entity.HasMany(x => x.ExamAttempts)
            .WithOne(x => x.Student)
            .OnDelete(DeleteBehavior.Restrict)
            );

            modelBuilder.Entity<Exam>().ToTable("Exams", t =>
                t.HasCheckConstraint("Exam_DateRange", "[EndDate] > [StartDate]"));

            modelBuilder.Entity<Question>().ToTable("Questions", t =>
                t.HasCheckConstraint("Question_PositiveMarks", "[Marks] > 0"));

            modelBuilder.Entity<Course>().ToTable("Courses", t =>
                t.HasCheckConstraint("Course_MaxDegree", "[MaximumDegree] > 0"));

            modelBuilder.Entity<Exam>(entity =>
            entity.HasIndex(x => x.StartDate)
            );

            modelBuilder.Entity<ExamAttempt>(entity =>
            entity.HasIndex(x => x.StartTime)
            );

        }

        protected static void SeedInitialData(ModelBuilder modelBuilder)
        {
            // 3 Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "C# Mastery", MaximumDegree = 100, CreatedDate = DateTime.Now, IsActive = true },
                new Course { Id = 2, Title = "Database Systems", MaximumDegree = 100, CreatedDate = DateTime.Now, IsActive = true },
                new Course { Id = 3, Title = "Clean Architecture", MaximumDegree = 100, CreatedDate = DateTime.Now, IsActive = true }
            );

            // 2 Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, Name = "Karim Essam", Email = "karim@teaching.com", Specialization = "Software Engineering", HireDate = new DateTime(2020, 1, 1), IsActive = true },
                new Instructor { Id = 2, Name = "Ahmed Ali", Email = "ahmed@teaching.com", Specialization = "Database Design", HireDate = new DateTime(2021, 5, 10), IsActive = true }
            );

            // 5 Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Omar Khaled", Email = "omar@student.com", StudentNumber = "S001", EnrollmentDate = DateTime.Now, IsActive = true },
                new Student { Id = 2, Name = "Sara Ahmed", Email = "sara@student.com", StudentNumber = "S002", EnrollmentDate = DateTime.Now, IsActive = true },
                new Student { Id = 3, Name = "Mona Zaki", Email = "mona@student.com", StudentNumber = "S003", EnrollmentDate = DateTime.Now, IsActive = true },
                new Student { Id = 4, Name = "Hassan Ali", Email = "hassan@student.com", StudentNumber = "S004", EnrollmentDate = DateTime.Now, IsActive = true },
                new Student { Id = 5, Name = "Lila Amr", Email = "lila@student.com", StudentNumber = "S005", EnrollmentDate = DateTime.Now, IsActive = true }
            );

            // 2 Exams (One for C#, one for DB)
            modelBuilder.Entity<Exam>().HasData(
                new Exam
                {
                    Id = 1,
                    Title = "C# Basics Quiz",
                    CourseId = 1,
                    InstructorId = 1,
                    TotalMarks = 20,
                    Duration = TimeSpan.FromHours(1),
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(1).AddHours(2)
                },
                new Exam
                {
                    Id = 2,
                    Title = "SQL Fundamentals",
                    CourseId = 2,
                    InstructorId = 2,
                    TotalMarks = 50,
                    Duration = TimeSpan.FromHours(2),
                    StartDate = DateTime.Now.AddDays(2),
                    EndDate = DateTime.Now.AddDays(2).AddHours(3)
                }
            );

            // Seeding various question types into Exam 1
            modelBuilder.Entity<MultipleChoiceQuestion>().HasData(new MultipleChoiceQuestion
            {
                Id = 1,
                ExamId = 1,
                QuestionText = "What is the base class for all types?",
                Marks = 5,
                CreatedDate = DateTime.Now,
                OptionA = "Object",
                OptionB = "String",
                OptionC = "Var",
                OptionD = "Base",
                CorrectOption = 'A'
            });

            modelBuilder.Entity<TrueFalseQuestion>().HasData(new TrueFalseQuestion
            {
                Id = 2,
                ExamId = 1,
                QuestionText = "Interfaces can have state?",
                Marks = 5,
                CreatedDate = DateTime.Now,
                CorrectAnswer = false
            });

            modelBuilder.Entity<EssayQuestion>().HasData(new EssayQuestion
            {
                Id = 3,
                ExamId = 1,
                QuestionText = "Discuss the importance of Dependency Injection.",
                Marks = 10,
                CreatedDate = DateTime.Now,
                MaxWordCount = 500,
                GradingCriteria = "Concept clarity and examples."
            });
        }
    }
}
