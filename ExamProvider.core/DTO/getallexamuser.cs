using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.DTO
{
    public class getallexamuser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ExamName { get; set; }
        public decimal? ExamDuration { get; set; }
        public string? ExamDescription { get; set; }
        public decimal? ScorEmark { get; set; }
        public string? ScoreRate { get; set; }
    }
}
