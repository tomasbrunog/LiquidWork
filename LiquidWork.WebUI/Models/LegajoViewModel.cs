using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidWork.WebUI.Models
{
    public class LegajoViewModel
    {
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

    }
}
