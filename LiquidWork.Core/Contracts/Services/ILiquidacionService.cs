using LiquidWork.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Contracts.Services
{
    public interface ILiquidacionService
    {
        public void Create();
        public void AssignLegajo();
        public void RemoveConcepto();

        public void AddLiquidacion(Legajo legajo, Liquidacion liquidacion);
        public void RemoveLiquidacion(Legajo legajo, Liquidacion liquidacion);

    }
}
