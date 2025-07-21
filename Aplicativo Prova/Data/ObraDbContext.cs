using Aplicativo_Prova.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Aplicativo_Prova.Data
{
    public class ObraDbContext : DbContext
    {
        public ObraDbContext(DbContextOptions<ObraDbContext> options) : base(options) { }

        public DbSet<RegistroObra> RegistrosObra { get; set; }
    }
}
