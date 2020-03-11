using _2doParcial_JonathanMaria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2doParcial_JonathanMaria.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Llamadas> Llamadas { get; set; }
        public DbSet<LlamadasDetalles> LlamadasDetalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Database/2doParcial.Db");
        }
    }
}
