using System;
using System.Collections.Generic;

namespace ExamProvider.core.Data
{
    public partial class CompanyInfo
    {
        public decimal CompanyId { get; set; }
        public string? OrganizationName { get; set; }
        public string? CommercialrecordImg { get; set; }
        public string? LogoImg { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
