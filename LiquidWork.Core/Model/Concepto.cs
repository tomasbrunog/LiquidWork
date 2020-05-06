using System;
using System.ComponentModel.DataAnnotations;

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
        public decimal Monto { get; set; }
        [Range(0, 999)]
        public decimal Factor { get; set; }
        [Range(0, 99)]
        public TipoConcepto TipoConcepto { get; set; }

        public int LiquidacionId { get; set; }
        public virtual Liquidacion Liquidacion { get; set; }

        public void UpdateMonto()
        {
            Monto += CalculateMonto();
        }

        public decimal CalculateMonto()
        {
            return Liquidacion.TotalRemunerativo * Factor / 100;
        }

    }

    public enum TipoConcepto
    {
        Remunerativo,
        NoRemunerativo,
        Deduccion
    }


}

