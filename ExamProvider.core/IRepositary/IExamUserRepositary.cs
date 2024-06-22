using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IRepositary
{
    public interface IExamUserRepositary
    {
        Task CreateExamUser(UserExam userExam);
        Task UpdateExamUser(UserExam userExam);
        Task deleteExamUser(int id);
        Task<List<getallexamuser>> getALLExamsUser();
        Task<getallexamuser> getExamUserById(int id);


    }
}
