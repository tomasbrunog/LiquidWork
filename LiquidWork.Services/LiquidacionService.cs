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

            decimal? neto = 0;
            foreach (var item in liquidacion.Conceptos)
            {
                neto += item.Monto;
            }
            liquidacion.Neto = neto;
        }

        public async void UpdateNeto(int? liquidacionId)
        {
            var liquidacion = await _context.Liquidaciones
                .Include(li => li.Conceptos)
                .FirstOrDefaultAsync(li => li.LiquidacionId == liquidacionId);

            decimal? neto = 0;
            foreach (var item in liquidacion.Conceptos)
            {
                neto += item.Monto;
            }
            liquidacion.Neto = neto;
        }

        public void UpdateNeto(Liquidacion liquidacion)
        {
            decimal? neto = 0;
            foreach (var item in liquidacion.Conceptos)
            {
                neto += item.Monto;
            }
            liquidacion.Neto = neto;

        }


    }
}
