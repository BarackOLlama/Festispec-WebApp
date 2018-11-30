using System.Collections.Generic;
using System.Linq;
using Festispec_WebApp.Models;
using Microsoft.EntityFrameworkCore;

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
            //var ins1 = _context.Inspections;
            var ins = _context.Inspections
                .Include(nameof(Inspections.InspectionInspectors))
                .ToList();
            return ins;
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