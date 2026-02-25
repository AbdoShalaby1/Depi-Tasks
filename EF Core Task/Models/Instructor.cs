using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_Core_Task.Models
{
    internal class Instructor
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [MaxLength(150)]
        public required string Specialization { get; set; }

        public required DateTime HireDate { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Exam>? Exams { get; set; } = new HashSet<Exam>();
        public ICollection<InstructorCourse> InstructorCourses { get; set; } = new HashSet<InstructorCourse>();
    }
}
