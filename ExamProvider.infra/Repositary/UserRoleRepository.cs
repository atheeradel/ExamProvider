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
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly IDbContext _dbContext;
        public UserRoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task create_USER_ROLE(UserRole userrole)
        {
            var param = new DynamicParameters();
            param.Add("ROLE_NAME", userrole.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("createdat", userrole.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updatedat", userrole.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("USER_ROLE_package.create_USER_ROLE", param, commandType: CommandType.StoredProcedure);
        }

        public async Task delete_USER_ROLE(int id)
        {
            var param = new DynamicParameters();
            param.Add("ROLE_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("USER_ROLE_package.delete_USER_ROLE", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<UserRole> getUSER_ROLEId(int id)
        {
            var param = new DynamicParameters();
            param.Add("ROLE_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<UserRole>("USER_ROLE_package.getUSER_ROLEId", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<UserRole>> get_USER_ROLE()
        {
            var result = await _dbContext.Connection.QueryAsync<UserRole>("USER_ROLE_package.get_USER_ROLE", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task Update_USER_ROLE(UserRole userrole)
        {
            var param = new DynamicParameters();
            param.Add("ROLE_ID", userrole.RoleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("ROLE_NAME", userrole.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("createdat", userrole.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updatedat", userrole.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("USER_ROLE_package.Update_USER_ROLE", param, commandType: CommandType.StoredProcedure);
        }
    }
}