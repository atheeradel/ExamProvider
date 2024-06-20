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
    public class ExamRepositary : IExamRepositary
    {
        private readonly IDbContext _dbContext;
        public ExamRepositary(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       

        public async Task create_Exam(Exam exam)
        {
            var param = new DynamicParameters();
            param.Add("examName", exam.ExamName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("ExamDuration", exam.ExamDuration, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("examDescription", exam.ExamDescription, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("createDate", exam.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updateDate", exam.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("Exam_Package.create_Exam", param, commandType: CommandType.StoredProcedure);
        }

        public async Task delete_Exam(int id)
        {
            var param = new DynamicParameters();
            param.Add("examId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("Exam_Package.delete_Exam", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<Exam> getExamById(int id)
        {
            var param = new DynamicParameters();
            param.Add("examId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Exam>("Exam_Package.getExamById", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        
    }

        public async Task<List<Exam>> get_ALLExams()
        
        {
            var result = await _dbContext.Connection.QueryAsync<Exam>("Exam_Package.get_ALLExams", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public async Task<List<Exam>> search_between_interval(DateTime firstDate, DateTime secondDate)
        {
            var param = new DynamicParameters();
            param.Add("first_date", firstDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("second_date", secondDate, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Exam>("Exam_Package.search_between_interval", param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Exam>> search_specifec_Date(DateTime specificDate)
        {
            var param = new DynamicParameters();
            param.Add("specific_Date", specificDate, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Exam>("Exam_Package.search_specifec_Date", param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task update_Exam(Exam exam)
        {
            var param = new DynamicParameters();
            param.Add("examId", exam.ExamId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("examName", exam.ExamName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("ExamDuration", exam.ExamDuration, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("examDescription", exam.ExamDescription, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("createDate", exam.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updateDate", exam.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("Exam_Package.update_Exam", param, commandType: CommandType.StoredProcedure);
        }
    }
}
