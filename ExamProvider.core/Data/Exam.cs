﻿using System;
using System.Collections.Generic;

namespace ExamProvider.core.Data
{
    public partial class Exam
    {
        public Exam()
        {
            Questions = new HashSet<Question>();
            UserExams = new HashSet<UserExam>();
        }

        public decimal ExamId { get; set; }
        public string? ExamName { get; set; }
        public decimal? ExamDuration { get; set; }
        public string? ExamDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<UserExam> UserExams { get; set; }
    }
}
