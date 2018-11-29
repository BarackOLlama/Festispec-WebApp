using System.Collections.Generic;
using Festispec_WebApp.Models;

namespace Festispec_WebApp.Services
{
    public interface IInspectionService
    {
        IEnumerable<Inspections> GetAll();
        Inspections GetById(int id);
        Inspections GetByAccountId(int id);
    }
    public class InspectionService: IInspectionService
    {
        private readonly FSContext _context;

        public InspectionService(FSContext fsContext)
        {
            _context = fsContext;
        }
        public IEnumerable<Inspections> GetAll()
        {
            return _context.Inspections;
        }

        public Inspections GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Inspections GetByAccountId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}