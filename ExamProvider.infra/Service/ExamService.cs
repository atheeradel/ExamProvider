using ExamProvider.core.Data;
using ExamProvider.core.IRepositary;
using ExamProvider.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Service
{
    public class ExamService : IExamService

    {
        private readonly IExamRepositary _examRepositary;

        public ExamService(IExamRepositary examRepositary)
        {
            _examRepositary = examRepositary;
        }

        public async Task create_Exam(Exam exam)
        {
            await _examRepositary.create_Exam(exam);
        }

        public async Task delete_Exam(int id)
        {
            await _examRepositary.delete_Exam(id);
        }

        public async Task<Exam> getExamById(int id)
        {
            return await _examRepositary.getExamById(id);
        }

        public async Task<List<Exam>> get_ALLExams()
        {
          return await _examRepositary.get_ALLExams();
        }

        public async Task<List<Exam>> search_between_interval(DateTime firstDate, DateTime secondDate)
        {
            return await _examRepositary.search_between_interval(firstDate, secondDate);
        }

        public async Task<List<Exam>> search_specifec_Date(DateTime specificDate)
        {
            return await _examRepositary.search_specifec_Date(specificDate);
        }

        public async Task update_Exam(Exam exam)
        {
            await _examRepositary.update_Exam(exam);
        }
    }
}
