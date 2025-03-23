using Microsoft.EntityFrameworkCore;
using Umfrage.Data;
using Umfrage.DTO;
using Umfrage.Model;

namespace Umfrage.Services
{
    public class QuestionService
    {
        private readonly SurveyContext _context;

        public QuestionService(SurveyContext context)
        {
            _context = context;
        }

        public List<Questions> AllQuestions()
        {
            return _context.Questions.AsNoTracking().ToList();
        }

        public List<Questions> GetQuestionsForSchoolClass(string schoolClass)
        {
            return _context.Questions.AsNoTracking().Where(q => q.SelectedClass == schoolClass || q.SelectedClass == "0").ToList();
        }

        public Questions? CreateQuestion(QuestionDTO newQuestion)
        {
            Questions question = new Questions
            {
                Question = newQuestion.Question,
                AnswerOne = newQuestion.AnswerOne,
                AnswerTwo = newQuestion.AnswerTwo,
                AnswerThree = newQuestion.AnswerThree,
                AnswerFour = newQuestion.AnswerFour,
                SelectedClass = newQuestion.SelectedClass,
            };
            _context.Questions.Add(question);
            if (_context.SaveChanges() > 0)
                return question;
            return null;
        }
    }
}
