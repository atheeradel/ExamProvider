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
    public class ExamQuestionService : IExamQuestionService
    {
        private readonly IExamQuestionRepositary _examQuestionRepositary;

        public ExamQuestionService(IExamQuestionRepositary examQuestionRepositary)
        {
            _examQuestionRepositary = examQuestionRepositary;
        }




        public async Task create_Question(Question question)
        {
            await _examQuestionRepositary.create_Question(question);
        }

        public async Task delete_Question(int id)
        {
            await _examQuestionRepositary.delete_Question(id);
        }

        public async Task<List<getallexam>> getQuestionById(int id)
        {
            return await _examQuestionRepositary.getQuestionById(id);
        }

        public async Task<List<getallexam>> get_ALLQuestions()
        {
            return await _examQuestionRepositary.get_ALLQuestions();
        }

        public async Task update_ExamQuestion(Question question)
        {
            await _examQuestionRepositary.update_ExamQuestion(question);
        }
    }
}
