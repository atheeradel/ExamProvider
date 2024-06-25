using ExamProvider.core.Data;
using ExamProvider.core.Dto;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoServise _iuserinfoservise;

        public UserInfoController(IUserInfoServise iuserinfoservise)
        {
            _iuserinfoservise = iuserinfoservise;
        }
        [HttpPost]
        [Route("CreateUserinfo")]
        public async Task create_USER_Info(UserInfo userinfo)
        {
            await _iuserinfoservise.create_USER_Info(userinfo);
        }
        [HttpPut]
        public async Task Update_USER_Info(UserInfo userinfo)
        {
            await _iuserinfoservise.Update_USER_Info(userinfo);
        }
        [HttpDelete("{id}")]
        public async Task delete_USER_Info(int id)
        {
            await (_iuserinfoservise.delete_USER_Info(id));
        }
        [HttpGet]
        public async Task<List<User_Info_Extra>> get_USER_Info()
        {
            return await _iuserinfoservise.get_USER_Info();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<UserInfo> getUSER_InfoEId(int id)
        {
            return await _iuserinfoservise.getUSER_InfoEId(id);
        }

    }
}
