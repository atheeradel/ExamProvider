using ExamProvider.core.Data;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamQuestionController : ControllerBase
    {
        private readonly IExamQuestionService _service;

        public ExamQuestionController(IExamQuestionService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] Question question)
        {
            try
            {
                await _service.create_Question(question);
                return Ok("Question created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/examquestion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            try
            {
                await _service.delete_Question(id);
                return Ok($"Question with ID {id} deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/examquestion/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            try
            {
                var question = await _service.getQuestionById(id);
                if (question == null || question.Count == 0)
                {
                    return NotFound($"Question with ID {id} not found");
                }
                return Ok(question);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/examquestion
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            try
            {
                var questions = await _service.get_ALLQuestions();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/examquestion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] Question question)
        {
            try
            {
                // Ensure the ID in the object matches the route parameter
                if (question.QuestionId != id)
                {
                    return BadRequest("Mismatched ID in request");
                }

                await _service.update_ExamQuestion(question);
                return Ok($"Question with ID {id} updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }



        }


        }
    }
