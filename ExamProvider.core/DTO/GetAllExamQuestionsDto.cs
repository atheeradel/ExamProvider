using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExamProvider.core.DTO
{
    public class GetAllExamQuestionsDto
    {
        public string ExamName { get; set; }
        public int ExamDuration { get; set; }
        public string ExamDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public string QuestionDateCreation { get; set; }
        public string QuestionLevel { get; set; }
        public string QuestionType { get; set; }
        public string Title { get; set; }
        public string IsCorrect { get; set; }
    }
    public class ExamDto
    {
        public string ExamName { get; set; }
        public int ExamDuration { get; set; }
        public string ExamDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    }

    public class QuestionDto
    {
        public string QuestionDateCreation { get; set; }
        public string QuestionLevel { get; set; }
        public string QuestionType { get; set; }
        public List<OptionDto> Options { get; set; } = new List<OptionDto>();
    }

    public class OptionDto
    {
        public string Title { get; set; }
        public string IsCorrect { get; set; }
    }
}

