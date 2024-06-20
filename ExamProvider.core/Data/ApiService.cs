using System;
using System.Collections.Generic;

namespace ExamProvider.core.Data
{
    public partial class ApiService
    {
        public decimal ApiId { get; set; }
        public string? ServiceName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal? UniqueKey { get; set; }
    }
}
