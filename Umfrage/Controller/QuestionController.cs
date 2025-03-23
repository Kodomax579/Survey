using Microsoft.AspNetCore.Mvc;
using Umfrage.DTO;
using Umfrage.Model;
using Umfrage.Services;

namespace Umfrage.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService _questionService;

        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("questions/{schoolClass}")]
        public ActionResult<List<QuestionDTO>> QuestionsForSchoolClass(string schoolClass)
        {
            var questions = _questionService.GetQuestionsForSchoolClass(schoolClass).Select(ToQuestionDTO).ToList();
            if (questions == null || questions.Count == 0) return NotFound("No questions found for this school class.");
            return Ok(questions);
        }

        [HttpPost("questions/create")]
        public ActionResult<QuestionDTO> CreateNewQuestion(QuestionDTO question)
        {
            var createdQuestion = _questionService.CreateQuestion(question);
            if (createdQuestion != null)
                return CreatedAtAction(nameof(QuestionsForSchoolClass), new { schoolClass = question.SelectedClass }, ToQuestionDTO(createdQuestion));
            return BadRequest("Question could not be created.");
        }


        private QuestionDTO ToQuestionDTO(Questions question)
        {
            return new QuestionDTO
            {
                Question = question.Question,
                AnswerOne = question.AnswerOne,
                AnswerTwo = question.AnswerTwo,
                AnswerThree = question.AnswerThree,
                AnswerFour = question.AnswerFour,
                SelectedClass= question.SelectedClass,
            };
        }
    }
}
