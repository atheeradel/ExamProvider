using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IService
{
    public interface IExamQuestionService
    {
        Task create_Question(Question question);
        Task update_ExamQuestion(Question question);
        Task delete_Question(int id);
        Task<List<getallexam>> get_ALLQuestions();
        Task<List<getallexam>> getQuestionById(int id);

    }
}
