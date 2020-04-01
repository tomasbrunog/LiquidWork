using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class Pami : Concepto
    {
        public new int CodigoConcepto { get; } = 202;
        public override decimal CalcularMonto()
        {
            throw new NotImplementedException();
        }
    }
}
