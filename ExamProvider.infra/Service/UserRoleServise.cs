using ExamProvider.core.Data;
using ExamProvider.core.IRepositary;
using ExamProvider.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Service
{
    public class UserRoleServise : IUserRoleServise
    {
        private readonly IUserRoleRepository _iuserRoleRepository;

        public UserRoleServise(IUserRoleRepository iuserRoleRepository)
        {

            _iuserRoleRepository = iuserRoleRepository;
        }
        public async Task create_USER_ROLE(UserRole userrole)
        {
            await _iuserRoleRepository.create_USER_ROLE(userrole);
        }

        public async Task delete_USER_ROLE(int id)
        {
            await _iuserRoleRepository.delete_USER_ROLE(id);
        }

        public async Task<UserRole> getUSER_ROLEId(int id)
        {
            return await _iuserRoleRepository.getUSER_ROLEId(id);
        }

        public async Task<List<UserRole>> get_USER_ROLE()
        {
            return await _iuserRoleRepository.get_USER_ROLE();
        }

        public async Task Update_USER_ROLE(UserRole userrole)
        {
            await _iuserRoleRepository.Update_USER_ROLE(userrole);
        }
    }
}
