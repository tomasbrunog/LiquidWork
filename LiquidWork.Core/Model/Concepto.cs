using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquidWork.Core.Model
{
    public class Concepto
    {
        public int ConceptoId { get; set; }
        [Range(0, 999)]
        public int CodigoConcepto { get; set; }
        [Required]
        public string NombreConcepto { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Monto { get; set; }
        [Range(0, 999)]
        public double Cantidad { get; set; }
        [Range(0, 99)]
        public TipoConcepto TipoConcepto { get; set; }

        public int? LiquidacionId { get; set; }
        public virtual Liquidacion Liquidacion { get; set; }
        public int? NumeroLegajo { get; set; }
        public virtual Legajo Legajo { get; set; }

    }

    public enum TipoConcepto
    {
        Remunerativo,
        NoRemunerativo,
        Deduccion
    }
}

