using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class FaltasInjustificadas : Concepto
    {
        public new int CodigoConcepto { get; } = 206;
        public override decimal CalcularMonto()
        {
            throw new NotImplementedException();
        }
    }
}
