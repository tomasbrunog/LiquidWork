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

        public void RemoveConcepto(Concepto concepto)
        {
            var liquidacion = _context
                .Liquidaciones
                .Include(li => li.Conceptos)
                .FirstOrDefault(li => li.LiquidacionId == concepto.LiquidacionId);

            liquidacion.Conceptos = liquidacion.Conceptos.Where(c => c != concepto).ToList();

            UpdateNeto(liquidacion);
        }

        public async void UpdateNeto(Concepto concepto)
        {
            var liquidacion = await _context.Liquidaciones
                .Include(li => li.Conceptos)
                .FirstOrDefaultAsync(li => li.LiquidacionId == concepto.LiquidacionId);

            decimal? neto = 0;
            foreach (var item in liquidacion.Conceptos)
            {
                neto += item.Monto;
            }
            liquidacion.Neto = neto;
        }

        public void UpdateNeto(int? liquidacionId)
        {
            var liquidacion = _context.Liquidaciones
                .Include(li => li.Conceptos)
                .FirstOrDefault(li => li.LiquidacionId == liquidacionId);

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
