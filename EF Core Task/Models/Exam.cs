using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_Core_Task.Models
{
    internal class Exam
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public required string Title { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public decimal TotalMarks { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; } = true;
        public int CourseId { get; set; }
        public int InstructorId { get; set; }

        public Course Course { get; set; } = null!;

        public Instructor Instructor { get; set; } = null!; // ef will fill it later

        public ICollection<Question> Questions { get; set; } = null!;
        public ICollection<ExamAttempt> ExamAttempts { get; set; } = new HashSet<ExamAttempt>();
    }
}
