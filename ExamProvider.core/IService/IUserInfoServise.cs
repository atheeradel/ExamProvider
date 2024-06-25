using ExamProvider.core.Data;
using ExamProvider.core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IService
{
    public interface IUserInfoServise
    {
        Task<List<User_Info_Extra>> get_USER_Info();
        Task<UserInfo> getUSER_InfoEId(int id);
        Task create_USER_Info(UserInfo userinfo);
        Task Update_USER_Info(UserInfo userinfo);
        Task delete_USER_Info(int id);
    }
}
