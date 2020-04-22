using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using System.Collections.Generic;
using System.Linq;
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

        public void AddConcepto(Concepto concepto)
        {
            _context.Add(concepto);

            UpdateTotales(concepto.LiquidacionId);
        }

        public void AddLiquidacion(Liquidacion liquidacion)
        {
            _context.Add(liquidacion);

            UpdateTotales(liquidacion);
        }

        public void RemoveConcepto(Concepto concepto)
        {
            var liquidacion = concepto.Liquidacion;
            liquidacion.Conceptos.Remove(concepto);

            UpdateTotales(liquidacion);
        }

        public void UpdateTotales(Liquidacion liquidacion)
        {
            var subTotals = new List<decimal?> { 0, 0, 0 };

            if (liquidacion.Conceptos != null)
            {
                foreach (var item in liquidacion.Conceptos)
                {
                    subTotals[(int)item.TipoConcepto] += item.Monto;
                } 
            }

            liquidacion.TotalRemunerativo = subTotals[0];
            liquidacion.TotalNoRemunerativo = subTotals[1];
            liquidacion.TotalDeducciones = subTotals[2];

            liquidacion.Neto = liquidacion.TotalRemunerativo
                + liquidacion.TotalNoRemunerativo
                - liquidacion.TotalDeducciones;
        }

        public void UpdateTotales(int? liquidacionId)
        {
            var liquidacion = _context.Liquidaciones
                .FirstOrDefault(li => li.LiquidacionId == liquidacionId);

            UpdateTotales(liquidacion);
        }

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
