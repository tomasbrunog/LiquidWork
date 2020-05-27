using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using Microsoft.EntityFrameworkCore.Internal;
using System;
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

        public void AddConcepto(Concepto concepto)
        {
            _context.Conceptos.Add(concepto);

            UpdateTotales(concepto.LiquidacionId);
        }

        public void AddLiquidacion(Liquidacion liquidacion)
        {
            _context.Add(liquidacion);
        }

        public void RemoveConcepto(Concepto concepto)
        {
            var liquidacion = concepto.Liquidacion;
            liquidacion.Conceptos.Remove(concepto);

            UpdateTotales(liquidacion);
        }

        public void UpdateTotales(Liquidacion liquidacion)
        {
            var sortedConceptosList = SortConceptos(liquidacion.Conceptos);

            var subTotals = new List<decimal> { 0, 0, 0 };

            foreach (var item in sortedConceptosList)
            {
                item.UpdateMonto(subTotals[0]);
                subTotals[(int)item.TipoConcepto] += item.Monto;
            }

            liquidacion.TotalRemunerativo = subTotals[0];
            liquidacion.TotalNoRemunerativo = subTotals[1];
            liquidacion.TotalDeducciones = subTotals[2];

            liquidacion.Neto = liquidacion.TotalRemunerativo
                + liquidacion.TotalNoRemunerativo
                - liquidacion.TotalDeducciones;
        }

        private ICollection<Concepto> SortConceptos(ICollection<Concepto> conceptos)
        {
            var incomingItem = conceptos.First();
            var sortedList = new ObservableCollection<Concepto>(conceptos.OrderBy(c => c.Posicion));

            int incomingPosition = incomingItem.Posicion;
            if (incomingPosition == 0)
            {
                incomingItem.Posicion = sortedList.Count();
            }

            sortedList.Move(sortedList.IndexOf(incomingItem), incomingPosition - 1);

            for (int i = 0; i < sortedList.Count(); i++)
            {
                sortedList[i].Posicion = i + 1;
            }

            return sortedList;
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
