using System;
using System.Collections.Generic;
using System.Linq;
using Festispec_WebApp.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Festispec_WebApp.Services
{
    public interface IInspectionService
    {
        IEnumerable<Inspections> GetAll();
        Inspections GetById(int id);
        Inspections GetByAccountId(int id);
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
//                .Include(inspections => inspections.InspectionDates)
                .Include(inspections => inspections.Questionnaires)
                .Include(inspections => inspections.Quotations)
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