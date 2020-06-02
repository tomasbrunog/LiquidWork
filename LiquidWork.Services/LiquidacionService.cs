using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public void AddLiquidacion(Liquidacion liquidacion)
        {
            _context.Add(liquidacion);
        }

        public void AddConcepto(Concepto concepto)
        {
            _context.Conceptos.Add(concepto);

            UpdateTotales(concepto.LiquidacionId);
        }


        public void RemoveConcepto(Concepto concepto)
        {
            var liquidacion = concepto.Liquidacion;
            liquidacion.Conceptos.Remove(concepto);

            var updatedSubTotals = CalculateSubTotals(liquidacion.Conceptos.OrderBy(c => c.Posicion));
            UpdateTotales(liquidacion, updatedSubTotals);
        }

        public List<decimal> CalculateSubTotals(IEnumerable<Concepto> conceptoCollection)
        {
            var subTotals = new List<decimal> { 0, 0, 0 };

            foreach (var item in conceptoCollection)
            {
                item.UpdateMonto(subTotals[0]);
                subTotals[(int)item.TipoConcepto] += item.Monto;
            }

            return subTotals;
        }
        public void UpdateTotales(int? liquidacionId)
        {
            var liquidacion = _context.Liquidaciones
                .FirstOrDefault(li => li.LiquidacionId == liquidacionId);

            var updatedConceptoCollection = InsertOrMoveConcepto(liquidacion.Conceptos);
            var updatedSubTotals = CalculateSubTotals(updatedConceptoCollection);

            UpdateTotales(liquidacion, updatedSubTotals);
        }

        public void UpdateTotales(Liquidacion liquidacion, List<decimal> updatedSubTotals)
        {
            liquidacion.TotalRemunerativo = updatedSubTotals[0];
            liquidacion.TotalNoRemunerativo = updatedSubTotals[1];
            liquidacion.TotalDeducciones = updatedSubTotals[2];

            liquidacion.Neto = liquidacion.TotalRemunerativo
                + liquidacion.TotalNoRemunerativo
                - liquidacion.TotalDeducciones;
        }

        private List<Concepto> InsertOrMoveConcepto(ICollection<Concepto> conceptos)
        {
            var incomingItem = conceptos.First();
            var sortedList = new ObservableCollection<Concepto>(conceptos.OrderBy(c => c.Posicion));

            int incomingPosition = incomingItem.Posicion;
            if (incomingPosition == 0)
            {
                incomingPosition = sortedList.Count();
            }

            sortedList.Move(sortedList.IndexOf(incomingItem), incomingPosition - 1);

            for (int i = 0; i < sortedList.Count(); i++)
            {
                sortedList[i].Posicion = i + 1;
            }

            return new List<Concepto>(sortedList);
        }


        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
