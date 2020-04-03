using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Contracts.Services
{
    public interface ILiquidacionService
    {
        public void Create();
        public void AssignLegajo();
        public void AddConcepto();
        public void RemoveConcepto();

    }
}
