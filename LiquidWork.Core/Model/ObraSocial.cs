using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class ObraSocial : Concepto
    {
        public new int CodigoConcepto { get; } = 203;
        public override decimal CalcularMonto()
        {
            throw new NotImplementedException();
        }
    }
}
