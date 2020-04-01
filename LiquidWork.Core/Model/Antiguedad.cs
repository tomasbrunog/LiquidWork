using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class Antiguedad : Concepto
    {
        public new int CodigoConcepto { get; } = 102;

        public override decimal CalcularMonto()
        {
            throw new NotImplementedException();
        }
    }
}
