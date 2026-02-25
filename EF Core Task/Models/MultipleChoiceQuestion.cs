using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_Core_Task.Models
{
    internal class MultipleChoiceQuestion : Question
    {
        [MaxLength(500)]
        public required string OptionA { get; set; }

        [MaxLength(500)]
        public required string OptionB { get; set; }

        [MaxLength(500)]
        public required string OptionC { get; set; }

        [MaxLength(500)]
        public required string OptionD { get; set; }

        public char CorrectOption { get; set; }

        public MultipleChoiceQuestion():base(QuestionType.MultipleChoice)
        {
        }
    }
}
