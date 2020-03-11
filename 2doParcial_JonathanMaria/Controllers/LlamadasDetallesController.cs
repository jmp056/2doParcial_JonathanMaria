using _2doParcial_JonathanMaria.Data;
using _2doParcial_JonathanMaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _2doParcial_JonathanMaria.Controllers
{

    public class LlamadasDetallesController
    {
        public List<LlamadasDetalles> GetList(Expression<Func<LlamadasDetalles, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<LlamadasDetalles> ListaLlamadasDetalle;

            try
            {

                ListaLlamadasDetalle = contexto.LlamadasDetalles.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return ListaLlamadasDetalle;
        }

        public LlamadasDetalles Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            LlamadasDetalles llamadasDetalles = new LlamadasDetalles();
            try
            {

                llamadasDetalles = contexto.LlamadasDetalles.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return llamadasDetalles;
        }
    }
}
