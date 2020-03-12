using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2doParcial_JonathanMaria.Models
{
    public class Llamadas
    {
        [Key]
        public int LlamadaId { get; set; }
        [Required(ErrorMessage ="La llamada debe tener una descripcion!")]
        public string Descripcion { get; set; }
        public List<LlamadasDetalles> Detalle { get; set; }

        public Llamadas()
        {
            LlamadaId = 0;
            Descripcion = string.Empty;
            Detalle = new List<LlamadasDetalles>();
        }
    }
}
