using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class Legajo
    {
        public int LegajoId { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CUIL { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaIngreso { get; set; }

        public IEnumerable<Concepto> ConceptosFijos { get; set; }
        public IEnumerable<Liquidacion> Liquidaciones { get; set; }

    }
}
