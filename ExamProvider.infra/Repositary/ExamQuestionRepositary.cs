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
    public class ExamQuestionRepositary : IExamQuestionRepositary
    {
        private readonly IDbContext _dbContext;

        public ExamQuestionRepositary(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task create_Question(Question question)
        {
            var param = new DynamicParameters();
            param.Add("questionDescription", question.QuestionDatecreation, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("questionlevel", question.QuestionLevel, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("questiontype", question.QuestionType, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("examid", question.ExamId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("createdat", question.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updatedat", question.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Exam_Questions.create_Question", param, commandType: CommandType.StoredProcedure);
        }

        public async Task delete_Question(int id)
        {
            var param = new DynamicParameters();
            param.Add("questionid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Exam_Questions.delete_Question", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<getallexam>> getQuestionById(int id)
        {
            var param = new DynamicParameters();
            param.Add("questionid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<getallexam>("Exam_Questions.getQuestionById", param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<getallexam>> get_ALLQuestions()
        {
            var result = await _dbContext.Connection.QueryAsync<getallexam>("Exam_Questions.get_ALLQuestions", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task update_ExamQuestion(Question question)
        {
            var param = new DynamicParameters();
            param.Add("questionid", question.QuestionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("questionDescription", question.QuestionDatecreation, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("questionlevel", question.QuestionLevel, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("questiontype", question.QuestionType, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("examid", question.ExamId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("createdat", question.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updatedat", question.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Exam_Questions.update_ExamQuestion", param, commandType: CommandType.StoredProcedure);
        }
    }
}
