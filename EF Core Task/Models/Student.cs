using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EF_Core_Task.Models
{
    internal class Student
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [MaxLength(20)]
        public required string StudentNumber { get; set; }
        public required DateTime EnrollmentDate { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<ExamAttempt> ExamAttempts { get; set; } = new HashSet<ExamAttempt>();
    }
}
