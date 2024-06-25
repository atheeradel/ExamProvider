using ExamProvider.core.Data;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyInfoController : ControllerBase
    {
        private readonly ICompanyInfoServise _companyInfoservise;

        public CompanyInfoController(ICompanyInfoServise companyInfoservise)
        {
            _companyInfoservise = companyInfoservise;
        }
        [HttpPost]
        [Route("CreateCompanyinfo")]
        public async Task create_COMPANY_INFO(CompanyInfo companyinfo)
        {
            await _companyInfoservise.create_COMPANY_INFO(companyinfo);
        }
        [HttpPut]
        public async Task update_COMPANY_INFO(CompanyInfo companyinfo)
        {
            await _companyInfoservise.update_COMPANY_INFO(companyinfo);
        }
        [HttpDelete("{id}")]
        public async Task delete_COMPANY_INFO(int id)
        {
            await _companyInfoservise.delete_COMPANY_INFO(id);
        }
        [HttpGet]
        public async Task<List<CompanyInfo>> get_COMPANY_INFO()
        {
            return await _companyInfoservise.get_COMPANY_INFO();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<CompanyInfo> getCOMPANY_INFOId(int id)
        {
            return await _companyInfoservise.getCOMPANY_INFOId(id);
        }
    }
}
