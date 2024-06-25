using ExamProvider.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IRepositary
{
    public interface ICompanyInfoReository
    {
        Task<List<CompanyInfo>> get_COMPANY_INFO();
        Task<CompanyInfo> getCOMPANY_INFOId(int id);
        Task create_COMPANY_INFO(CompanyInfo companyinfo);
        Task update_COMPANY_INFO(CompanyInfo companyinfo);
        Task delete_COMPANY_INFO(int id);
    }
}