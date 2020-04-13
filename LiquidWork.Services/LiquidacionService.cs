using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LiquidWork.Services
{
    public class LiquidacionService
    {
        private readonly DataContext _context;
        public LiquidacionService(DataContext context)
        {
            _context = context;
        }

        public void AddConcepto(Concepto concepto)
        {
            _context.Add(concepto);

            var liquidacion = _context
                .Liquidaciones
                .Include(li => li.Conceptos)
                .FirstOrDefault(li => li.LiquidacionId == concepto.LiquidacionId);

            UpdateNeto(liquidacion);
        }
        public async void UpdateNeto(Concepto newConcepto)
        {
            var liquidacion = await _context.Liquidaciones
                .Include(li => li.Conceptos)
                .FirstOrDefaultAsync(li => li.LiquidacionId == newConcepto.LiquidacionId);

            liquidacion.Neto = 0;
            foreach (var item in liquidacion.Conceptos)
            {
                liquidacion.Neto += item.Monto;
            }
        }
        public async void UpdateNeto(int? liquidacionId)
        {
            var liquidacion = await _context.Liquidaciones
                .Include(li => li.Conceptos)
                .FirstOrDefaultAsync(li => li.LiquidacionId == liquidacionId);

            liquidacion.Neto = 0;
            foreach (var item in liquidacion.Conceptos)
            {
                liquidacion.Neto += item.Monto;
            }
        }

        public void UpdateNeto(Liquidacion liquidacion)
        {
            liquidacion.Neto = 0;
            foreach (var item in liquidacion.Conceptos)
            {
                liquidacion.Neto += item.Monto;
            }
        }


    }
}
