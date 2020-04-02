using LiquidWork.Core.Model;
using LiquidWork.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiquidWork.Persistence.Repositories
{
    public class ConceptoRepository : IConceptoRepository
    {
        private readonly DataContext _context;

        public ConceptoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Concepto>> GetAll()
        {
            return await _context.Conceptos.AsNoTracking().ToListAsync();
        }


        public async Task<Concepto> GetById(int id)
        {
            var concepto = await _context.Conceptos
                .FirstOrDefaultAsync(m => m.ConceptoId == id);
            return concepto;
        }

        public async Task Create(Concepto concepto)
        {

           await _context.Conceptos.AddAsync(concepto);

        }

        public async Task Update(int id)
        {
            var concepto = await _context.Conceptos
                .FirstOrDefaultAsync(m => m.ConceptoId == id);
            _context.Update(concepto);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var concepto = await _context.Conceptos.FindAsync(id);
            _context.Conceptos.Remove(concepto);
            await _context.SaveChangesAsync();

        }
    }
}
