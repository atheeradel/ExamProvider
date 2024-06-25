using ExamProvider.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IService
{
    public interface IUserRoleServise
    {
        Task<List<UserRole>> get_USER_ROLE();
        Task<UserRole> getUSER_ROLEId(int id);
        Task create_USER_ROLE(UserRole userrole);
        Task Update_USER_ROLE(UserRole userrole);
        Task delete_USER_ROLE(int id);
    }
}
