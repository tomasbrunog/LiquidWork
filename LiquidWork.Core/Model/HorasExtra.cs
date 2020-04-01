using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class HorasExtra : Concepto
    {
        public new int CodigoConcepto { get; } = 105;
        public override decimal CalcularMonto()
        {
            throw new NotImplementedException();
        }
    }
}
