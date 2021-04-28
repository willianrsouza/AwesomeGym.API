using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeGym.Core.Entidades
{
   public class Funcionario
    {
        public Funcionario(int id, string funcionarioNome, string funcionarioCpf)
        {
            this.id = id;
            this.funcionarioNome = funcionarioNome;
            this.funcionarioCpf = funcionarioCpf;
        }

        public int id { get; set; }
        public string funcionarioNome { get; set; }
        public string funcionarioCpf { get; set; }

    }
}
