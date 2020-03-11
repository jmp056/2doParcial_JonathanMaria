using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2doParcial_JonathanMaria.Models
{
    public class LlamadasDetalles
    {
        [Key]
        public int LlamadaDetalleId { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public LlamadasDetalles()
        {
            LlamadaDetalleId = 0;
            Problema = string.Empty;
            Solucion = string.Empty;
        }

        public LlamadasDetalles(int llamadaDetalleId, string problema, string solucion)
        {
            LlamadaDetalleId = llamadaDetalleId;
            Problema = problema;
            Solucion = solucion;
        }
    }
}
