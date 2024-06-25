using ExamProvider.core.Data;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiServise : ControllerBase
    {
        private readonly IApiServiceServise _iapiserviceservise;

        public ApiServise(IApiServiceServise iapiserviceservise)
        {
            _iapiserviceservise = iapiserviceservise;
        }
        [HttpPost]
        [Route("CreateApiServise")]
        public async Task create_APIS_SERVICES(ApiService apiservice)
        {
            await _iapiserviceservise.create_APIS_SERVICES(apiservice);
        }
        [HttpGet]
        public async Task<List<ApiService>> get_all_APIS_SERVICES()
        {
            return await _iapiserviceservise.get_all_APIS_SERVICES();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ApiService> gid_APIS_SERVICES_by_id(int id)
        {
            return await _iapiserviceservise.gid_APIS_SERVICES_by_id(id);
        }
        [HttpPut]
        public async Task update_APIS_SERVICES(ApiService apiservice)
        {
            await _iapiserviceservise.update_APIS_SERVICES(apiservice);

        }
        [HttpDelete("{id}")]
        public async Task delete_APIS_SERVICES(int id)
        {
            await _iapiserviceservise.delete_APIS_SERVICES(id);
        }

    }
}
