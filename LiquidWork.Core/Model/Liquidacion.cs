using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class Liquidacion
    {
        public int LiquidacionId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM yyyy}")]
        public DateTime Periodo { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalRemunerativo { get; set; } = 0;
        [DataType(DataType.Currency)]
        public decimal TotalNoRemunerativo { get; set; } = 0;
        [DataType(DataType.Currency)]
        public decimal TotalDeducciones { get; set; } = 0;
        [DataType(DataType.Currency)]
        public decimal Neto { get; set; } = 0;

        public int? NumeroLegajo { get; set; }
        public virtual Legajo Legajo { get; set; }
        public virtual ICollection<Concepto> Conceptos { get; set; }

    }
}
