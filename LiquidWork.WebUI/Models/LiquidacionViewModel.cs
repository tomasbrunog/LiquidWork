using System;
using System.ComponentModel.DataAnnotations;

namespace LiquidWork.WebUI.Models
{
    public class LiquidacionViewModel
    {
        public int LiquidacionId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Periodo { get; set; }
        [DataType(DataType.Currency)]
        public decimal? TotalRemunerativo { get; set; }
        [DataType(DataType.Currency)]
        public decimal? TotalNoRemunerativo { get; set; }
        [DataType(DataType.Currency)]
        public decimal? TotalDeducciones { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Neto { get; set; }

        public int? NumeroLegajo { get; set; }
    }
}
