using ExamProvider.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamProvider.core.DTO;
namespace ExamProvider.core.IRepositary
{
    public interface IExamOptionsRepositary
    {
        Task createOptions(QuestionOption option);
        Task update_ExamOptions(QuestionOption option);
        Task delete_Options(int id);
        Task<List<getalloption>> getOptionsById(int id);
        Task<List<getalloption>> get_ALLOptions();

    }
}
