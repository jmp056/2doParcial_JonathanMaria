using _2doParcial_JonathanMaria.Data;
using _2doParcial_JonathanMaria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _2doParcial_JonathanMaria.Controllers
{
    public class LlamadasController
    {
        public bool Guardar(Llamadas Llamada)
        {
            bool Paso = false;

            //try
            //{
            if (Llamada.LlamadaId == 0)
            {
                Paso = Insertar(Llamada);

            }
            else
            {
                Paso = Modificar(Llamada);

            }
            //}
            //catch (Exception)
            //{
            //    throw;

            //}

            return Paso;
        }
        public static bool Insertar(Llamadas Llamada)
        {
            bool Paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Llamadas.Add(Llamada);
                Paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return Paso;
        }

        public static bool Modificar(Llamadas Llamada)
        {
            bool Paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete From LlamadasDetalles where LlamadaId={Llamada.LlamadaId}");

                foreach (var item in Llamada.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Llamadas.Add(Llamada);
                contexto.Entry(Llamada).State = EntityState.Modified;
                Paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();

            }

            return Paso;
        }

        public Llamadas Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Llamadas Llamada = new Llamadas();

            try
            {
                Llamada = contexto.Llamadas.Where(e => e.LlamadaId == Id).Include(d => d.Detalle).FirstOrDefault();

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return Llamada;
        }

        public bool Eliminar(int Id)
        {
            Contexto contexto = new Contexto();
            Llamadas Llamada = new Llamadas();
            bool Paso = false;

            try
            {
                Llamada = contexto.Llamadas.Find(Id);
                contexto.Entry(Llamada).State = EntityState.Deleted;
                Paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return Paso;
        }

        public List<Llamadas> GetList(Expression<Func<Llamadas, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Llamadas> ListaLlamadas;

            try
            {
                ListaLlamadas = contexto.Llamadas.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return ListaLlamadas;
        }
    }
}
