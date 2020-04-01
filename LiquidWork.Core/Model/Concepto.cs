using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquidWork.Core.Model
{
    public abstract class Concepto
    {
        [Range(0, 999)]
        public int CodigoConcepto { get; }
        [Range(0, 999)]
        public double Unidad { get; set; }
        [Range(0, 99)]
        public int Precedencia { get; set; }

        public TipoConcepto TipoConcepto { get; set; }
        public abstract decimal CalcularMonto();
    }
}
