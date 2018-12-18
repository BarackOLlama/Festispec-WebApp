using System.Collections.Generic;
using System.Linq;
using Festispec_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Festispec_WebApp.Services
{
    public interface IQuestionnaireService
    {
        IEnumerable<Questionnaires> GetAll();
        Questionnaires GetById(int questionnaireId);
        IEnumerable<Questionnaires> GetByAccountId(int id);
        Questionnaires GetByInspection(int inspectionId);
    }

    public class QuestionnaireService : IQuestionnaireService
    {
        private FSContext _context;

        public QuestionnaireService(FSContext fsContext)
        {
            _context = fsContext;
        }

        public IEnumerable<Questionnaires> GetAll()
        {
            return _context.Questionnaires
                .Include(questionnaire => questionnaire.Questions).ThenInclude(a => a.QuestionType)
                .Include(questionnaire => questionnaire.Questions).ThenInclude(a => a.Answers);
        }

        public Questionnaires GetById(int questionnaireId)
        {
            return _context.Questionnaires.Include(questionnaire => questionnaire.Questions)
                .ThenInclude(a => a.QuestionType).Include(questionnaire => questionnaire.Questions)
                .ThenInclude(a => a.Answers).FirstOrDefault(c => c.Id == questionnaireId);
        }

        public IEnumerable<Questionnaires> GetByAccountId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Questionnaires GetByInspection(int inspectionId)
        {
            return _context.Questionnaires.Include(questionnaire => questionnaire.Questions)
                .ThenInclude(a => a.QuestionType).Include(questionnaire => questionnaire.Questions)
                .ThenInclude(a => a.Answers).FirstOrDefault(c => c.InspectionId == inspectionId);
        }
    }
}