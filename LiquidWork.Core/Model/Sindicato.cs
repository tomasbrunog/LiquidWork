using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class Sindicato : Concepto
    {
        public new int CodigoConcepto { get; } = 205;
        public override decimal CalcularMonto()
        {
            throw new NotImplementedException();
        }
    }
}
