using System;
using System.Collections.Generic;

namespace ExamProvider.core.Data
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            UserExams = new HashSet<UserExam>();
        }

        public decimal UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Datecreation { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public decimal? RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual UserRole? Role { get; set; }
        public virtual ICollection<UserExam> UserExams { get; set; }
    }
}
