using ExamProvider.core.Data;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamUserController : ControllerBase
    {
        private readonly IExamUserService _examUserService;

        public ExamUserController(IExamUserService examUserService)
        {
            _examUserService = examUserService;
        }
       
        [HttpPost]
        public async Task<IActionResult> CreateExamUser([FromBody] UserExam userExam)
        {
            try
            {
                await _examUserService.CreateExamUser(userExam);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamUser(int id)
        {
            try
            {
                await _examUserService.deleteExamUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllExamUsers()
        {
            try
            {
                var examUsers = await _examUserService.getALLExamsUser();
                return Ok(examUsers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamUserById(int id)
        {
            try
            {
                var examUser = await _examUserService.getExamUserById(id);
                if (examUser == null)
                {
                    return NotFound();
                }
                return Ok(examUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/examuser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExamUser(int id, [FromBody] UserExam userExam)
        {
            try
            {
                if (id != userExam.UserExamId)
                {
                    return BadRequest("ID mismatch between URL and body.");
                }

                await _examUserService.UpdateExamUser(userExam);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
