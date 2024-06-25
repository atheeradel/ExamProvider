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
    public class ExamOptionsService : IExamOptionsService
    {
        private readonly IExamOptionsRepositary _examOptionsRepositary;

        public ExamOptionsService(IExamOptionsRepositary examOptionsRepositary)
        {
            _examOptionsRepositary = examOptionsRepositary;
        }


        public async Task createOptions(QuestionOption option)
        {
            await _examOptionsRepositary.createOptions(option);
        }

        public async Task delete_Options(int id)
        {
            await _examOptionsRepositary.delete_Options(id);
        }

        public async Task<List<getalloption>>getOptionsById(int id)
        {
            return await _examOptionsRepositary.getOptionsById(id);
        }

        public async Task<List<getalloption>> get_ALLOptions()
        {
            return await _examOptionsRepositary.get_ALLOptions();
        }

        public async Task update_ExamOptions(QuestionOption option)
        {
            await _examOptionsRepositary.update_ExamOptions(option);
        }
       public async Task<string> GetAllOptions()
        {
            return await _examOptionsRepositary.GetAllOptions();
        }
    }
}
