using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

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
        public decimal BaseMonto { get; set; }
        public decimal Monto { get; set; }
        [Range(0, 999)]
        public decimal Factor { get; set; }
        public int Posicion { get; set; }
        [Range(0, 99)]
        public TipoConcepto TipoConcepto { get; set; }

        public int LiquidacionId { get; set; }
        public virtual Liquidacion Liquidacion { get; set; }

        public void UpdateMonto(decimal subTotalRemunerativo)
        {
            Monto = CalculateMonto(subTotalRemunerativo);
        }

        public decimal CalculateMonto(decimal subTotalRemunerativo)
        {
            return BaseMonto + subTotalRemunerativo * Factor;
        }

    }

    public enum TipoConcepto
    {
        Remunerativo,
        NoRemunerativo,
        Deduccion
    }


}

