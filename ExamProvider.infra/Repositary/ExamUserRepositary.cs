using Dapper;
using ExamProvider.core.Data;
using ExamProvider.core.DTO;
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
    public class ExamUserRepositary:IExamUserRepositary
    {
        private readonly IDbContext _dbContext;

        public ExamUserRepositary(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateExamUser(UserExam userExam)
        {
            var param = new DynamicParameters();
            param.Add("usersid", userExam.UserId, DbType.Int32, ParameterDirection.Input);
            param.Add("examsid", userExam.ExamId, DbType.Int32, ParameterDirection.Input);
            param.Add("uniquekey", userExam.UniqueId, DbType.Int32, ParameterDirection.Input);
            param.Add("scoremark", userExam.ScorEmark, DbType.Int32, ParameterDirection.Input);
            param.Add("scorerate", userExam.ScoreRate, DbType.String, ParameterDirection.Input);
            param.Add("createdate", userExam.CreatedAt, DbType.Date, ParameterDirection.Input);
            param.Add("updatedate", userExam.UpdatedAt, DbType.Date, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Exam_User.CreateExamUser", param, commandType: CommandType.StoredProcedure);
        }

        public  async Task deleteExamUser(int id)
        {
            var param = new DynamicParameters();
            param.Add("examuserid", id, DbType.Int32, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Exam_User.deleteExamUser", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<getallexamuser>> getALLExamsUser()
        {
            var result = await _dbContext.Connection.QueryAsync<getallexamuser>("Exam_User.getALLExamsUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<getallexamuser> getExamUserById(int id)
        {
            var param = new DynamicParameters();
            param.Add("examuserid", id, DbType.Int32, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<getallexamuser>("Exam_User.getExamUserById", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task UpdateExamUser(UserExam userExam)
        {
            var param = new DynamicParameters();
            param.Add("examuserid", userExam.UserExamId, DbType.Int32, ParameterDirection.Input);
            param.Add("usersid", userExam.UserId, DbType.Int32, ParameterDirection.Input);
            param.Add("examsid", userExam.ExamId, DbType.Int32, ParameterDirection.Input);
            param.Add("uniquekey", userExam.UniqueId, DbType.Int32, ParameterDirection.Input);
            param.Add("scoremark", userExam.ScorEmark, DbType.Int32, ParameterDirection.Input);
            param.Add("scorerate", userExam.ScoreRate, DbType.String, ParameterDirection.Input);
            param.Add("createdate", userExam.CreatedAt, DbType.Date, ParameterDirection.Input);
            param.Add("updatedate", userExam.UpdatedAt, DbType.Date, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Exam_User.UpdateExamUser", param, commandType: CommandType.StoredProcedure);
        }

    }
}
