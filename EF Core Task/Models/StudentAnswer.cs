using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_Core_Task.Models
{
    internal class StudentAnswer
    {
        public int Id { get; set; }

        [MaxLength(2000)]
        public required string AnswerText { get; set; }
        public char? SelectedOption { get; set; }
        public bool? BooleanAnswer { get; set; }
        public decimal? MarksObtained { get; set; }
        public required DateTime SubmittedAt { get; set; }
        public required int ExamAttemptId { get; set; }
        public required int QuestionId { get; set; }

        public required ExamAttempt ExamAttempt { get; set; }
        public required Question Question { get; set; }
    }
}
