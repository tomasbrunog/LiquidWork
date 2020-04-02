using LiquidWork.Core.Model;
using LiquidWork.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiquidWork.Persistence.Repositories
{
    public class LegajoRepository : ILegajoRepository
    {
        private readonly DataContext _context;

        public LegajoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Legajo>> GetAll()
        {
            return await _context.Legajos.AsNoTracking().ToListAsync();
        }


        public async Task<Legajo> GetById(int id)
        {
            var legajo = await _context.Legajos
                .FirstOrDefaultAsync(m => m.LegajoId == id);
            return legajo;
        }

        public async Task Create(Legajo legajo)
        {

           await _context.Legajos.AddAsync(legajo);

        }

        public async Task Update(int id)
        {
            var legajo = await _context.Legajos
                .FirstOrDefaultAsync(m => m.LegajoId == id);
            _context.Update(legajo);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var legajo = await _context.Legajos.FindAsync(id);
            _context.Legajos.Remove(legajo);
            await _context.SaveChangesAsync();

        }
    }
}
