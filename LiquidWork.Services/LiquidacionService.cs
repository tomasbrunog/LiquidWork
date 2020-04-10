using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LiquidWork.Services
{
    public class LiquidacionService
    {
        private readonly DataContext _context;
        public LiquidacionService(DataContext context)
        {
            _context = context;
        }
        public async void AddConcepto(Concepto concepto)
        {
            var liquidacion = await _context.Liquidaciones
                .Include(li => li.Conceptos)
                .FirstOrDefaultAsync(li => li.LiquidacionId == concepto.LiquidacionId);

            liquidacion.Neto = 0;
            foreach (var item in liquidacion.Conceptos)
            {
                liquidacion.Neto += item.Monto;
            }
        }


    }
}
