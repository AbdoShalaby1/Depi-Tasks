using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_Core_Task.Models
{
    public enum QuestionType
    {
        MultipleChoice = 1,
        TrueFalse = 2,
        Essay = 3
    }

    internal abstract class Question(QuestionType questionType)
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        public required string QuestionText { get; set; }

        public decimal Marks { get; set; }

        public QuestionType QuestionType { get; set; } = questionType;

        public required DateTime CreatedDate { get; set; }

        public int ExamId { get; set; }

        public Exam Exam { get; set; } = null!;

        public ICollection<StudentAnswer> StudentAnswers { get; set; } = new HashSet<StudentAnswer>();
    }
}
