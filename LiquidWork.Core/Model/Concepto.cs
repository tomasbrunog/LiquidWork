using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Model
{
    public abstract class Concepto
    {
        public int ConceptoId { get; set; }
        public int CodigoConcepto { get; set; }
        public double Unidad { get; set; }
        public int Precedencia { get; set; }
        public double Monto { get; set; }

        public int? LiquidacionId { get; set; }
        public Liquidacion Liquidacion { get; set; }
        public int? LegajoId { get; set; }
        public Legajo Legajo { get; set; }
        public TipoConcepto TipoConcepto { get; set; }

        public abstract double CalcularMonto();
    }
}
