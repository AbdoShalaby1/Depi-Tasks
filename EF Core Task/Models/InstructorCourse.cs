using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_Core_Task.Models
{
    internal class InstructorCourse
    {
        public required int InstructorId { get; set; }
        public required int CourseId { get; set; }

        [Required]
        public required DateTime AssignedDate { get; set; }

        public bool IsActive { get; set; } = true;

        public required Instructor Instructor { get; set; }
        public required Course Course { get; set; }
    }
}
