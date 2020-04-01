using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class Presentismo : Concepto
    {
        public new int CodigoConcepto { get; } = 103;

        public override decimal CalcularMonto()
        {
            throw new NotImplementedException();
        }
    }
}
