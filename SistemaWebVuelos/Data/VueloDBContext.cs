using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using SistemaWebVuelos.Models;

namespace SistemaWebVuelos.Data
{
    public class VueloDBContext : DbContext
    {
        public VueloDBContext() : base("KeyDB") { }
        public DbSet<Vuelo> Vuelos { get; set; }
    }
}