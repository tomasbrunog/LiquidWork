using LiquidWork.Core.Model;
using LiquidWork.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiquidWork.Persistence.Repositories
{
    public class LiquidacionRepository : ILiquidacionRepository
    {
        private readonly DataContext _context;

        public LiquidacionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Liquidacion>> GetAll()
        {
            return await _context.Liquidaciones.AsNoTracking().ToListAsync();
        }


        public async Task<Liquidacion> GetById(int id)
        {
            var liquidacion = await _context.Liquidaciones
                .FirstOrDefaultAsync(m => m.LiquidacionId == id);
            return liquidacion;
        }

        public async Task Create(Liquidacion liquidacion)
        {

           await _context.Liquidaciones.AddAsync(liquidacion);

        }

        public async Task Update(int id)
        {
            var liquidacion = await _context.Liquidaciones
                .FirstOrDefaultAsync(m => m.LiquidacionId == id);
            _context.Update(liquidacion);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var liquidacion = await _context.Liquidaciones.FindAsync(id);
            _context.Liquidaciones.Remove(liquidacion);
            await _context.SaveChangesAsync();

        }
    }
}
