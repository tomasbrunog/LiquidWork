using LiquidWork.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidWork.WebUI.Models
{
    public class ConceptoViewModel
    {
        public int ConceptoId { get; set; }
        [Range(0, 999)]
        public int CodigoConcepto { get; set; }
        [Required]
        public string NombreConcepto { get; set; }
        [DataType(DataType.Currency)]
        public decimal Monto { get; set; }
        [Range(0, 99)]
        public int Porcentaje { get; set; }
        [Range(0, 99)]
        public int? Posicion { get; set; }
        public int TipoConcepto { get; set; }
        public int LiquidacionId { get; set; }
    }
}
