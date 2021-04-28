using AwesomeGym.Application.Entidades;
using AwesomeGym.Application.InputModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.Infrastructure.Persistencia.Servicos
{
    public class AlunoDbContext : DbContext
    {
        public AlunoDbContext(DbContextOptions<AlunoDbContext> options) : base(options)
        {

        }

        public DbSet<Alunos> Alunos { get; set; }
    }

}
