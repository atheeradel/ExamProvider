using ExamProvider.core.Data;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpPost]
        [Route("CreateExam")]
        public async Task create_Exam(Exam exam)
        {
            await _examService.create_Exam(exam);
        }

        [HttpPut]
        public async Task update_Exam(Exam exam)
        {
            await _examService.update_Exam(exam);
        }
        [HttpDelete("{id}")]
        public async Task delete_Exam(int id)
        {
            await _examService.delete_Exam(id);
        }
        [HttpGet]
        public async Task<List<Exam>> get_ALLExams()
        {
            return await _examService.get_ALLExams();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Exam> getExamById(int id)
        {
            return await _examService.getExamById(id);
        }
        [HttpGet]
        [Route("Search/{firstDate}/{secondDate}")]
        public async Task<List<Exam>> search_between_interval(DateTime firstDate, DateTime secondDate)
        {
            return await _examService.search_between_interval(firstDate, secondDate);
        }

        [HttpGet]
        [Route("serchbyId/{specificDate}")]
             public async Task<List<Exam>> search_specifec_Date(DateTime specificDate)
        {
            return await _examService.search_specifec_Date(specificDate);
        }
    }
}
