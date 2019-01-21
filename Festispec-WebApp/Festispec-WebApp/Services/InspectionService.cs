using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Festispec_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Festispec_WebApp.Services
{
    public interface IInspectionService
    {
        IEnumerable<Inspections> GetAll();
        Inspections GetById(int id);
        Inspections GetByAccountId(int id);
        IEnumerable<Inspections> GetInspectionsByInspectorId(int inspectorId);
        IEnumerable<InspectionDates> Test();
    }

    public class InspectionService : IInspectionService
    {
        private readonly FSContext _context;

        public InspectionService(FSContext fsContext)
        {
            _context = fsContext;
        }

        public IEnumerable<Inspections> GetAll()
        {
            var ins = _context.Inspections
                .Include(inspections => inspections.InspectionInspectors)
                .ThenInclude(inspectors => inspectors.Inspector)
                .Include(inspections => inspections.Event)
                .Include(inspections => inspections.Status)
                .Include(inspections => inspections.InspectionDate)
                .Include(inspections => inspections.Questionnaires)
                .Include(inspections => inspections.Quotations)
                .ToList();
            return ins;
        }

        public Inspections GetById(int id)
        {
            var inspection = _context.Inspections.Include(inspections => inspections.InspectionInspectors)
                .ThenInclude(inspectors => inspectors.Inspector)
                .Include(inspections => inspections.Event)
                .Include(inspections => inspections.Status)
                .Include(inspections => inspections.InspectionDate)
                .Include(inspections => inspections.Questionnaires)
                .Include(inspections => inspections.Quotations).ToList().FirstOrDefault(i => i.Id == id);
            return inspection;
        }

        private IEnumerable<int> GetInspectionIdsByInspectorId(int inspectorId)
        {
            var inspections = _context.InspectionInspectors
                .Where(a => a.InspectorId == inspectorId)
                .Include(a => a.Inspection.InspectionDate)
                .Include(a => a.Inspection.Event)
                .Select(a => a.Inspection.Id);
            return inspections;
        }

        private int GetInspectorIdBasedOnAccountId(int accountId)
        {
            var inspector = _context.Inspectors
                .Where(a => a.Account.Id == accountId)
                .Select(i => i.Id).FirstOrDefault();

            return inspector;
        }
        public IEnumerable<Inspections> GetInspectionsByInspectorId(int inspectorId)
        {
            inspectorId = GetInspectorIdBasedOnAccountId(inspectorId);
            
            IEnumerable <int> idList = GetInspectionIdsByInspectorId(inspectorId);
            var list = idList.ToList();
            if (!list.Any())
            {
                return null;
            }
            
            var inspection = _context.Inspections.Include(inspections => inspections.InspectionInspectors)
                .ThenInclude(inspectors => inspectors.Inspector)
                .Include(inspections => inspections.Event)
                .Include(inspections => inspections.Status)
                .Include(inspections => inspections.InspectionDate)
                .Include(inspections => inspections.Questionnaires)
                .Include(inspections => inspections.Quotations)
                .Where(a => list.Contains(a.Id))
                .ToList();
            return inspection;
        }
        
        public IEnumerable<InspectionDates> Test()
        {
            var dats = _context.InspectionDates.ToList();
            return dats;
        }
        public Inspections GetByAccountId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}