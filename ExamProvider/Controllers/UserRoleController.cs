using ExamProvider.core.Data;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleServise _iuserroleservise;

        public UserRoleController(IUserRoleServise iuserroleservise)
        {
            _iuserroleservise = iuserroleservise;
        }
        [HttpPost]
        [Route("Createuserroleinfo")]
        public async Task create_USER_ROLE(UserRole userrole)
        {
            await _iuserroleservise.create_USER_ROLE(userrole);
        }
        [HttpPut]
        public async Task Update_USER_ROLE(UserRole userrole)
        {
            await _iuserroleservise.Update_USER_ROLE(userrole);
        }
        [HttpDelete("{id}")]
        public async Task delete_USER_ROLE(int id)
        {
            await _iuserroleservise.delete_USER_ROLE(id);
        }
        [HttpGet]
        public async Task<List<UserRole>> get_USER_ROLE()
        {
            return await _iuserroleservise.get_USER_ROLE();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<UserRole> getUSER_ROLEId(int id)
        {
            return await _iuserroleservise.getUSER_ROLEId(id);
        }

    }
}
