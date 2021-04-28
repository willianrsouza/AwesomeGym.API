using AwesomeGym.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeGym.Infrastructure.Persistencia.Servicos
{
   public class FuncionarioDbContext : DbContext
    {
        public FuncionarioDbContext(DbContextOptions<FuncionarioDbContext> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionario { get; set; }
    }
}
