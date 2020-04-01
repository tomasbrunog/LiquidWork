using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class Feriado : Concepto
    {
        public new int CodigoConcepto { get; } = 104;

        public override decimal CalcularMonto()
        {
            throw new NotImplementedException();
        }
    }
}
