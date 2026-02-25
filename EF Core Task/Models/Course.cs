using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Task.Models
{
    internal class Course
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public required string Title { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
        [Precision(18, 2)]
        public required decimal MaximumDegree { get; set; }
        public required DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<InstructorCourse> InstructorCourses { get; set; } = new HashSet<InstructorCourse>();
    }
}
