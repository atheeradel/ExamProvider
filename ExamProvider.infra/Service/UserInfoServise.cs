using ExamProvider.core.Data;
using ExamProvider.core.Dto;
using ExamProvider.core.IRepositary;
using ExamProvider.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Service
{
    public class UserInfoServise : IUserInfoServise
    {
        private readonly IUserInfoRebository _iuserinforebository;

        public UserInfoServise(IUserInfoRebository iuserinforebository)
        {
            _iuserinforebository = iuserinforebository;
        }
        public async Task create_USER_Info(UserInfo userinfo)
        {
            await _iuserinforebository.create_USER_Info(userinfo);
        }

        public async Task delete_USER_Info(int id)
        {
            await (_iuserinforebository.delete_USER_Info(id));
        }

        public async Task<UserInfo> getUSER_InfoEId(int id)
        {
            return await _iuserinforebository.getUSER_InfoEId(id);
        }

        public async Task<List<User_Info_Extra>> get_USER_Info()
        {
            return await _iuserinforebository.get_USER_Info();
        }

        public async Task Update_USER_Info(UserInfo userinfo)
        {
            await _iuserinforebository.Update_USER_Info(userinfo);
        }
    }
}