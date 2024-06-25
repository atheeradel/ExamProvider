using Dapper;
using ExamProvider.core.Data;
using ExamProvider.core.Dto;
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
    public class UserInfoRebository : IUserInfoRebository
    {
        private readonly IDbContext _dbContext;
        public UserInfoRebository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task create_USER_Info(UserInfo userinfo)
        {
            var param = new DynamicParameters();
            param.Add("FIRST_NAME", userinfo.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("LAST_NAME", userinfo.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("DATECREATION", userinfo.Datecreation, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("BIRTH_DATE", userinfo.BirthDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("EMAIL", userinfo.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("PASSWORD", userinfo.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("ROLE_ID", userinfo.RoleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("createdat", userinfo.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updatedat", userinfo.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("USER_Info_package.create_USER_Info", param, commandType: CommandType.StoredProcedure);
        }

        public async Task delete_USER_Info(int id)
        {
            var param = new DynamicParameters();
            param.Add("USER_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("USER_Info_package.delete_USER_Info", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<UserInfo> getUSER_InfoEId(int id)
        {
            var param = new DynamicParameters();
            param.Add("USER_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<UserInfo>("USER_Info_package.getUSER_InfoEId", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<User_Info_Extra>> get_USER_Info()
        {
            var result = await _dbContext.Connection.QueryAsync<User_Info_Extra>("USER_Info_package.get_USER_Info", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task Update_USER_Info(UserInfo userinfo)
        {
            var param = new DynamicParameters();
            param.Add("USER_ID", userinfo.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("FIRST_NAME", userinfo.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("LAST_NAME", userinfo.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("DATECREATION", userinfo.Datecreation, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("BIRTH_DATE", userinfo.BirthDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("EMAIL", userinfo.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("PASSWORD", userinfo.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("ROLE_ID", userinfo.RoleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("createdat", userinfo.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updatedat", userinfo.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("USER_Info_package.Update_USER_Info", param, commandType: CommandType.StoredProcedure);
        }
    }
}
