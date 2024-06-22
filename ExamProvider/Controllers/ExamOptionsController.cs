using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamOptionsController : ControllerBase
    {
        private readonly IExamOptionsService _examOptionsService;

        public ExamOptionsController(IExamOptionsService examOptionsService)
        {
           _examOptionsService = examOptionsService;
        }

        [HttpPost]
        [Route("CreateOption")]
        public async Task createOptions(QuestionOption option)
        {
            await _examOptionsService.createOptions(option);
        }
        [HttpDelete("{id}")]
        public async Task delete_Options(int id)
        {
            await _examOptionsService.delete_Options(id);
        }

        [HttpGet]
        [Route("GetByoptionId/{id}")]
        public async Task<List<getalloption>> getOptionsById(int id)
        {
            return await _examOptionsService.getOptionsById(id);
        }
        [HttpGet]
        public async Task< List<getalloption>> get_ALLOptions()
        {
            return await _examOptionsService.get_ALLOptions();
        }
        [HttpPut]
        public async Task update_ExamOptions(QuestionOption option)
        {
            await _examOptionsService.update_ExamOptions(option);
        }
    }
}
