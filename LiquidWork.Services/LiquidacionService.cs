using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

            UpdateTotales(concepto.LiquidacionId);
        }

        public void RemoveConcepto(Concepto concepto)
        {
            var liquidacion = _context
                .Liquidaciones
                .Include(li => li.Conceptos)
                .FirstOrDefault(li => li.LiquidacionId == concepto.LiquidacionId);

            liquidacion.Conceptos = liquidacion.Conceptos.Where(c => c != concepto).ToList();

            UpdateTotales(liquidacion);
        }

        public void UpdateTotales(Liquidacion liquidacion)
        {
            decimal? subTotalRemunerativo = 0;
            decimal? subTotalNoRemunerativo = 0;
            decimal? subTotalDeducciones = 0;

            List<decimal?> subTotals = new List<decimal?>
            {
                subTotalRemunerativo,
                subTotalNoRemunerativo,
                subTotalDeducciones
            };

            foreach (var item in liquidacion.Conceptos)
            {
                subTotals[(int)item.TipoConcepto] += item.Monto;
            }

            liquidacion.TotalRemunerativo = subTotals[0];
            liquidacion.TotalNoRemunerativo = subTotals[1];
            liquidacion.TotalDeducciones = subTotals[2];

            liquidacion.Neto = liquidacion.TotalRemunerativo
                + liquidacion.TotalNoRemunerativo
                + liquidacion.TotalDeducciones;
        }
        public void UpdateTotales(int? liquidacionId)
        {
            var liquidacion = _context.Liquidaciones
                .Include(li => li.Conceptos)
                .FirstOrDefault(li => li.LiquidacionId == liquidacionId);

            UpdateTotales(liquidacion);
        }
    }
}
