using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Festispec_WebApp.DataTransferObjects;
using Festispec_WebApp.Models;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace Festispec_WebApp.Services
{
    public interface IAnswerService
    {
        Inspectors GetInspector(int inspectorId);
        Questions GetQuestion(int questionId);
        Answers GetAnswer(int questionId, int inspectorId);
        Answers Create(Answers answer);

        Answers Update(Answers answer);

        Answers Save(AnswerDto answerDto);

        Answers ToModel(AnswerDto answerDto);
    }

    public class AnswerService : IAnswerService
    {
        private readonly FSContext _context;

        public AnswerService(FSContext fsContext)
        {
            _context = fsContext;
        }

        public Inspectors GetInspector(int inspectorId)
        {
            return _context.Inspectors.FirstOrDefault(q => q.Id == inspectorId);
        }

        public Questions GetQuestion(int questionId)
        {
            return _context.Questions.FirstOrDefault(q => q.Id == questionId);
        }

        public Answers GetAnswer(int questionId, int inspectorId)
        {
            return _context.Answers.FirstOrDefault(a => a.InspectorId == inspectorId && a.QuestionId == questionId);
        }

        public Answers Save(AnswerDto answerDto)
        {
//            var inspector = _context.Inspectors
//                .Where(a => a.Account.Id == accountId)
//                .Select(i => i.Id).FirstOrDefault();
//
//            return inspector;
            // Check if the answer already exists 
            var answer = GetAnswer(answerDto.QuestionId, answerDto.InspectorId);
            if (answer != null)
            {
                answer.Content = answerDto.Content;
                return Update(answer);
            }

            answer = ToModel(answerDto);

            return Create(answer);
        }


        public Answers Create(Answers answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
            return answer;
        }

        public Answers Update(Answers answer)
        {
            _context.Answers.Update(answer);
            _context.SaveChanges();
            return answer;
        }

        public Answers ToModel(AnswerDto answerDto)
        {
            var question = GetQuestion(answerDto.QuestionId);
            var inspector = GetInspector(answerDto.InspectorId);
            var answer = new Answers
            {
                Content = answerDto.Content,
                QuestionId = answerDto.QuestionId,
                Question = question,
                InspectorId = answerDto.InspectorId,
                Inspector = inspector
            };
            return answer;
        }
    }
}