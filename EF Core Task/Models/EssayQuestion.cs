using Microsoft.Extensions.Options;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Text;

namespace EF_Core_Task.Models
{
    internal class EssayQuestion : Question
    {
        public int? MaxWordCount { get; set; }

        [MaxLength(1000)]
        public required string GradingCriteria { get; set; }

        public EssayQuestion() : base(QuestionType.Essay)
        {
        }
    }
}
