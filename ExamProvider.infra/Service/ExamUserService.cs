using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IRepositary;
using ExamProvider.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Service
{
    public class ExamUserService : IExamUserService
    {
        private readonly IExamUserRepositary _examUserRepositary;

        public ExamUserService(IExamUserRepositary examUserRepositary)
        {
            _examUserRepositary = examUserRepositary;
        }

        public async Task CreateExamUser(UserExam userExam)
        {
            await _examUserRepositary.CreateExamUser(userExam);
        }

        public async Task deleteExamUser(int id)
        {
            await _examUserRepositary.deleteExamUser(id);
        }

        public async Task<List<getallexamuser>> getALLExamsUser()
        {
            return await _examUserRepositary.getALLExamsUser();
        }

        public async Task<getallexamuser> getExamUserById(int id)
        {
            return await _examUserRepositary.getExamUserById(id);
        }

        public async Task UpdateExamUser(UserExam userExam)
        {
            await _examUserRepositary.UpdateExamUser(userExam);
        }
    }
}
