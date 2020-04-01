using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class Jubilacion : Concepto
    {
        public new int CodigoConcepto { get; } = 201;
        public override decimal CalcularMonto()
        {
            throw new NotImplementedException();
        }
    }
}
