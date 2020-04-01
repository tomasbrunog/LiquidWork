using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class ItemConcepto
    {
        //private readonly Concepto _concepto;
        //public ItemConcepto(Concepto concepto)
        //{
        //    _concepto = concepto;
        //}
        public int ItemConceptoId { get; set; }
        [DataType(DataType.Currency)]
        public decimal Monto { get; set; }

        public int? ConceptoId { get; set; }
        public Concepto Concepto { get; set; }
        public int? LiquidacionId { get; set; }
        public Liquidacion Liquidacion { get; set; }
        public int? LegajoId { get; set; }
        public Legajo Legajo { get; set; }
    }
}
