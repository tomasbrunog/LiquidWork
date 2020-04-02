using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class Legajo
    {
        public int LegajoId { get; set; }
        [Range(0,999999)]
        [Required]
        public int NumeroLegajo { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(50)]
        [Required]
        public string Apellido { get; set; }
        [Range(0, 99999999999)]
        [Required]
        public long CUIL { get; set; }
        [MaxLength(50)]
        public string Categoria { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime FechaIngreso { get; set; }

        public IEnumerable<Concepto> ConceptosFijos { get; set; }
        public IEnumerable<Liquidacion> Liquidaciones { get; set; }

    }
}
