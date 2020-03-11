using _2doParcial_JonathanMaria.Data;
using _2doParcial_JonathanMaria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2doParcial_JonathanMaria.Controllers
{
    public class LlamadasController
    {
        public bool Guardar(Llamadas Llamada)
        {
            bool Paso = false;

            try
            {
                if(Llamada.LlamadaId == 0)
                {
                    Paso = Guardar(Llamada);

                }
                else
                {
                    Paso = Modificar(Llamada);

                }
            }
            catch (Exception)
            {
                throw;

            }

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
                Llamadas LlamadaAnterior = contexto.Llamadas.Find(Llamada.LlamadaId);
                foreach (var item in LlamadaAnterior.Detalle)
                {

                    if (item.LlamadaDetalleId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;

                    }
                    else if (!Llamada.Detalle.Any(d => d.LlamadaDetalleId == item.LlamadaDetalleId))
                    {
                        contexto.Entry(item).State = EntityState.Deleted;
                    
                    }
                    else
                    {

                        contexto.Entry(item).State = EntityState.Modified;
                    }
                }

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
                Llamada = contexto.Llamadas.Find(Id);

            }
            catch(Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return Llamada;
        }
    }
}
