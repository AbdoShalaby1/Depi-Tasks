using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Task.Models
{
    internal class StudentCourse
    {
        public required int StudentId { get; set; }

        public required int CourseId { get; set; }

        public required DateTime EnrollmentDate { get; set; }

        public decimal? Grade { get; set; }

        public bool IsCompleted { get; set; } = false;

        public required Student Student { get; set; }
        public required Course Course { get; set; }
    }
}
