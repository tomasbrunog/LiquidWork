﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquidWork.Core.Model
{
    public class Concepto
    {
        public int ConceptoId { get; set; }
        [Range(0, 999)]
        public int CodigoConcepto { get; }
        public string NombreConcepto { get; set; }
        [DataType(DataType.Currency)]
        public decimal Monto { get; set; }
        [Range(0, 999)]
        public double Unidad { get; set; }
        [Range(0, 99)]
        public int Precedencia { get; set; } 

        public TipoConcepto TipoConcepto { get; set; }
        public Liquidacion Liquidacion { get; set; }
        public Legajo Legajo { get; set; }

    }
}

