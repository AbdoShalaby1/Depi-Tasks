using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Task.Models
{
    internal class ExamAttempt
    {
        public int Id { get; set; }

        public required DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public decimal? TotalScore { get; set; }
        public bool IsSubmitted { get; set; } = false;
        public bool IsGraded { get; set; } = false;

        public required int StudentId { get; set; }
        public required int ExamId { get; set; }

        public required Student Student { get; set; }
        public required Exam Exam { get; set; }

        public ICollection<StudentAnswer> StudentAnswers { get; set; } = new HashSet<StudentAnswer>();
    }
}
