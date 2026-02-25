using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_Core_Task.Models
{
    internal class TrueFalseQuestion : Question
    {
        public required bool CorrectAnswer { get; set; }
        public TrueFalseQuestion() : base(QuestionType.TrueFalse)
        {
        }
    }
}
