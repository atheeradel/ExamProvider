using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IService
{
    public interface IExamOptionsService
    {
        Task createOptions(QuestionOption option);
        Task update_ExamOptions(QuestionOption option);
        Task delete_Options(int id);
        Task<List<getalloption>>get_ALLOptions();
        Task<List<getalloption>> getOptionsById(int id);
        Task<string> GetAllOptions();

    }
}
