using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquidWork.Core.Model
{
    public abstract class Concepto
    {
        public int ConceptoId { get; set; }
        [Range(0, 999)]
        public int CodigoConcepto { get; set; }
        [Range(0, 999)]
        public double Unidad { get; set; }
        [Range(0, 99)]
        public int Precedencia { get; set; }
        [DataType(DataType.Currency)]
        public decimal Monto { get; set; }

        public int? LiquidacionId { get; set; }
        public Liquidacion Liquidacion { get; set; }
        public int? LegajoId { get; set; }
        public Legajo Legajo { get; set; }
        public TipoConcepto TipoConcepto { get; set; }

        public abstract double CalcularMonto();
    }
}
