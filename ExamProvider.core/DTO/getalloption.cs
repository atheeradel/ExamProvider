using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.DTO
{
    public class getalloption
    {

        public string? ExamName { get; set; }
        public int? ExamDuration { get; set; }

        public string? ExamDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? QuestionDatecreation { get; set; }
        public string? QuestionLevel { get; set; }
        public string? QuestionType { get; set; }
        public string? Title { get; set; }
        public string? IsCorrect { get; set; }

    }
}
