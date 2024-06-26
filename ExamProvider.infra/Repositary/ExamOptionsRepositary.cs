﻿using Dapper;
using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.ICommon;
using ExamProvider.core.IRepositary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExamProvider.infra.Repositary
{
    public class ExamOptionsRepositary : IExamOptionsRepositary
    {
        private readonly IDbContext _dbContext;

        public ExamOptionsRepositary(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task createOptions(QuestionOption option)
        {
            var param = new DynamicParameters();
            param.Add("optiontitle", option.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("correctornot", option.IsCorrect, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("questiontsid", option.QuestionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("createdat", option.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updatedat", option.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("Exam_Options.createOptions", param, commandType: CommandType.StoredProcedure);
        }

        public async Task delete_Options(int id)
        {
            var param = new DynamicParameters();
            param.Add("optionquestionid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("Exam_Options.delete_Options", param, commandType: CommandType.StoredProcedure);
        }


       

        public async Task update_ExamOptions(QuestionOption option)
        {
            var param = new DynamicParameters();
            param.Add("optionquestionid", option.OptionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("optiontitle", option.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("correctornot", option.IsCorrect, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("questiontsid", option.QuestionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("createdat", option.CreatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("updatedat", option.UpdatedAt, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("Exam_Options.update_ExamOptions", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<getalloption>> getOptionsById(int id)
        {
            var param = new DynamicParameters();
            param.Add("optionquestionid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<getalloption>("Exam_Options.getOptionsById", param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<getalloption>> get_ALLOptions()
        {
            var result = await _dbContext.Connection.QueryAsync<getalloption>("Exam_Options.get_ALLOptions", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public async Task<string> GetAllOptions()
        {
            var result = await _dbContext.Connection.QueryAsync<GetAllExamQuestionsDto>("Exam_Options.get_ALLOptions", commandType: CommandType.StoredProcedure);

            var exams = result.GroupBy(e => new { e.ExamName, e.ExamDuration, e.ExamDescription, e.CreatedAt })
                              .Select(g => new ExamDto
                              {
                                  ExamName = g.Key.ExamName,
                                  ExamDuration = g.Key.ExamDuration,
                                  ExamDescription = g.Key.ExamDescription,
                                  CreatedAt = g.Key.CreatedAt,
                                  Questions = g.GroupBy(q => new { q.QuestionDateCreation, q.QuestionLevel, q.QuestionType })
                                               .Select(qg => new QuestionDto
                                               {
                                                   QuestionDateCreation = qg.Key.QuestionDateCreation,
                                                   QuestionLevel = qg.Key.QuestionLevel,
                                                   QuestionType = qg.Key.QuestionType,
                                                   Options = qg.Select(o => new OptionDto
                                                   {
                                                       Title = o.Title,
                                                       IsCorrect = o.IsCorrect
                                                   }).ToList()
                                               }).ToList()
                              }).ToList();

            return JsonConvert.SerializeObject(exams, Formatting.Indented);
        }

    }
}
