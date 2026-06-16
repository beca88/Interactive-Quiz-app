
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        // Inject the QuizDbContext to interact with the database
        private readonly QuizDbContext _context;
        // Constructor to initialize the QuizDbContext
        public QuestionsController(QuizDbContext context)
        {
            _context = context;
        }

        // GET: api/questions
        [HttpGet]
        public ActionResult<IEnumerable<Question>> GetQuestions()
        {
            return Ok(_context.Questions.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Question> GetQuestion(int id)
        {
            var question = _context.Questions.Find(id);
            if (question == null)
            {
                return NotFound(new { message = $"Question with ID {id} not found." });
            }
            return Ok(question);
        }

        // POST: api/questions
        [HttpPost]
        public ActionResult<Question> CreateQuestion(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, question);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateQuestion(int id, Question updatedQuestion)
        {
            if (id != updatedQuestion.Id)
            {
                return BadRequest(new { message = "ID in the URL does not match ID in the request body." });
            }

            var existingQuestion = _context.Questions.Find(id);
            if (existingQuestion == null)
            {
                return NotFound(new { message = $"Question with ID {id} not found." });
            }

            existingQuestion.QuestionText = updatedQuestion.QuestionText;
            existingQuestion.Options = updatedQuestion.Options;
            existingQuestion.CorrectAnswer = updatedQuestion.CorrectAnswer;

            _context.Entry(existingQuestion).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteQuestion(int id)
        {
            var question = _context.Questions.Find(id);
            if (question == null)
            {
                return NotFound(new { message = $"Question with ID {id} not found." });
            }

            _context.Questions.Remove(question);
            _context.SaveChanges();

            return NoContent();
        }   
    }
}