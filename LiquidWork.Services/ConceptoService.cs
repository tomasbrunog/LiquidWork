using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiquidWork.Services
{
    public class ConceptoService
    {
        private readonly DataContext _context;
        private readonly LiquidacionService _liquidacionService;

        public ConceptoService(DataContext context)
        {
            _context = context;
            _liquidacionService = new LiquidacionService(_context);
        }

        public void AddConcepto(Concepto concepto)
        {
            _liquidacionService.AddConcepto(concepto);
        }

        public void DeleteConcepto(Concepto concepto)
        {
            _liquidacionService.RemoveConcepto(concepto);
        }

        public void UpdateConcepto(Concepto concepto)
        {
            _context.Update(concepto);
            _liquidacionService.UpdateTotales(concepto.LiquidacionId);
        }

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
