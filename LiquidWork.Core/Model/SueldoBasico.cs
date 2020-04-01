using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class SueldoBasico : Concepto
    {
        public new int CodigoConcepto { get; } = 101;

        public override decimal CalcularMonto()
        {
            throw new NotImplementedException();
        }
    }
}
