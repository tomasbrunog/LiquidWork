using LiquidWork.Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
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
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get => $"{Nombre} {Apellido}"; }

        public ICollection<ConceptoLiquidacion> Conceptos { get; set; }

        public LiquidacionViewModel()
        {
            Conceptos = new List<ConceptoLiquidacion>();
        }
    }

    public class ConceptoLiquidacion
    {
        public int ConceptoId { get; set; }
        public int CodigoConcepto { get; set; }
        public string NombreConcepto { get; set; }
        public decimal Monto { get; set; }
        public decimal Factor { get; set; }
        public TipoConcepto TipoConcepto { get; set; }
        public int Posicion { get; set; }
    }
}
