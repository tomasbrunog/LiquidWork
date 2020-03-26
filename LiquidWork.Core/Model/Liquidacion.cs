using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class Liquidacion
    {
        public int LiquidacionId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Periodo { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalRemunerativo { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalNoRemunerativo { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalDeducciones { get; set; }
        [DataType(DataType.Currency)]
        public decimal Neto { get; set; }

        public int? LegajoId { get; set; }
        public Legajo Legajo { get; set; }
        public IEnumerable<Concepto> Conceptos { get; set; }

    }
}
