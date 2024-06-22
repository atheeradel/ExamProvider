using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.DTO
{
    public class getallexam
    {
        public string? QuestionDatecreation { get; set; }
        public string? QuestionLevel { get; set; }
        public string? QuestionType { get; set; }
        public string? ExamName { get; set; }
        public decimal? ExamDuration { get; set; }
        public string? ExamDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
