using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class Liquidacion
    {
        public int LiquidacionId { get; set; }
        public DateTime Periodo { get; set; }
        public double TotalRemunerativo { get; set; }
        public double TotalNoRemunerativo { get; set; }
        public double TotalDeducciones { get; set; }
        public double Neto { get; set; }

        public int LegajoId { get; set; }
        public Legajo Legajo { get; set; }
        public IEnumerable<Concepto> Conceptos { get; set; }

    }
}
