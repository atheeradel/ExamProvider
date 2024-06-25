using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.Dto
{
    public class User_Info_Extra
    {
        public decimal UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Datecreation { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RoleName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
