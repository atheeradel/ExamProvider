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
    public class ApiServiseReopsotary : IApiServiseReopsotary
    {
        private readonly IDbContext _dbContext;
        public ApiServiseReopsotary(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task create_APIS_SERVICES(ApiService apiservice)
        {
            var param = new DynamicParameters();
            param.Add("c_service_name", apiservice.ServiceName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_unique_key", apiservice.UniqueKey, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("createdat", apiservice.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updatedat", apiservice.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("APIS_SERVICES_package.create_APIS_SERVICES", param, commandType: CommandType.StoredProcedure);
        }

        public async Task delete_APIS_SERVICES(int id)
        {
            var param = new DynamicParameters();
            param.Add("d_api_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("APIS_SERVICES_package.delete_APIS_SERVICES", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ApiService>> get_all_APIS_SERVICES()
        {
            var result = await _dbContext.Connection.QueryAsync<ApiService>("APIS_SERVICES_package.get_all_APIS_SERVICES", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<ApiService> gid_APIS_SERVICES_by_id(int id)
        {
            var param = new DynamicParameters();
            param.Add("gid_api_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<ApiService>("APIS_SERVICES_package.gid_APIS_SERVICES_by_id", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task update_APIS_SERVICES(ApiService apiservice)
        {
            var param = new DynamicParameters();
            param.Add("u_api_id", apiservice.ApiId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_service_name", apiservice.ServiceName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_unique_key", apiservice.UniqueKey, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("createdat", apiservice.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updatedat", apiservice.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("APIS_SERVICES_package.update_APIS_SERVICES", param, commandType: CommandType.StoredProcedure);
        }
    }
}
