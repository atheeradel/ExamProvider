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
    public class CompanyInfoServise : ICompanyInfoServise
    {
        private readonly ICompanyInfoReository _icompanyinforeository;

        public CompanyInfoServise(ICompanyInfoReository icompanyinforeository)
        {
            _icompanyinforeository = icompanyinforeository;
        }

        public async Task create_COMPANY_INFO(CompanyInfo companyinfo)
        {
            await _icompanyinforeository.create_COMPANY_INFO(companyinfo);
        }

        public async Task delete_COMPANY_INFO(int id)
        {
            await _icompanyinforeository.delete_COMPANY_INFO(id);
        }

        public async Task<CompanyInfo> getCOMPANY_INFOId(int id)
        {
            return await _icompanyinforeository.getCOMPANY_INFOId(id);
        }

        public async Task<List<CompanyInfo>> get_COMPANY_INFO()
        {
            return await _icompanyinforeository.get_COMPANY_INFO();
        }

        public async Task update_COMPANY_INFO(CompanyInfo companyinfo)
        {
            await _icompanyinforeository.update_COMPANY_INFO(companyinfo);
        }
    }
}
