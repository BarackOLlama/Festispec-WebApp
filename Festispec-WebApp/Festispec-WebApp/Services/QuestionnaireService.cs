using System.Collections.Generic;
using Festispec_WebApp.Models;

namespace Festispec_WebApp.Services
{
    public interface IQuestionnaireService
    {
        IEnumerable<Questionnaires> GetAll();
        Questionnaires GetById(int id);
        Questionnaires GetByAccountId(int id);
    }
    public class QuestionnaireService: IQuestionnaireService
    {
        private FSContext _context;

        public QuestionnaireService(FSContext fsContext)
        {
            _context = fsContext;
        }
        public IEnumerable<Questionnaires> GetAll()
        {
            return _context.Questionnaires;
        }

        public Questionnaires GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Questionnaires GetByAccountId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}