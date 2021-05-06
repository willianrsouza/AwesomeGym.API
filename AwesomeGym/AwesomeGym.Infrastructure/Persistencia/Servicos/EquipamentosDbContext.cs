using AwesomeGym.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;

namespace AwesomeGym.Infrastructure.Persistencia.Servicos
{
   public class EquipamentosDbContext : DbContext
    {
        public EquipamentosDbContext(DbContextOptions<EquipamentosDbContext> options) : base(options)
        {

        }


        public DbSet<Equipamento> Equipamentos { get; set; }
    }
}
