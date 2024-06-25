using Dapper;
using ExamProvider.core.Data;
using ExamProvider.core.ICommon;
using ExamProvider.core.IRepositary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Repositary
{
    public class CompanyInfoReository : ICompanyInfoReository
    {
        private readonly IDbContext _dbContext;
        public CompanyInfoReository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task create_COMPANY_INFO(CompanyInfo companyinfo)
        {
            var param = new DynamicParameters();
            param.Add("organization_name", companyinfo.OrganizationName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("commercialrecord_img", companyinfo.CommercialrecordImg, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("logo_img", companyinfo.LogoImg, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("DESCRIPTION", companyinfo.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("createdat", companyinfo.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updatedat", companyinfo.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("COMPANY_INFO_package.create_COMPANY_INFO", param, commandType: CommandType.StoredProcedure);
        }

        public async Task delete_COMPANY_INFO(int id)
        {
            var param = new DynamicParameters();
            param.Add("company_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("COMPANY_INFO_package.delete_COMPANY_INFO", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<CompanyInfo> getCOMPANY_INFOId(int id)
        {
            var param = new DynamicParameters();
            param.Add("company_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<CompanyInfo>("COMPANY_INFO_package.getCOMPANY_INFOId", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<CompanyInfo>> get_COMPANY_INFO()
        {
            var result = await _dbContext.Connection.QueryAsync<CompanyInfo>("COMPANY_INFO_package.get_COMPANY_INFO", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task update_COMPANY_INFO(CompanyInfo companyinfo)
        {
            var param = new DynamicParameters();
            param.Add("company_id", companyinfo.CompanyId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            param.Add("organization_name", companyinfo.OrganizationName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("commercialrecord_img", companyinfo.CommercialrecordImg, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("logo_img", companyinfo.LogoImg, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("DESCRIPTION", companyinfo.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("createdat", companyinfo.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updatedat", companyinfo.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("COMPANY_INFO_package.update_COMPANY_INFO", param, commandType: CommandType.StoredProcedure);
        }
    }
}
