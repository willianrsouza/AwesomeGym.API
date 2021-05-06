using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeGym.Application.Entidades
{
    public class Alunos
    {
        public Alunos(string nomeAluno, String cpfAluno)
        {
            this.nomeAluno = nomeAluno;
            this.cpfAluno = cpfAluno;
        }

        public int id { get; set; }
        public string nomeAluno { get; set; }
        public string cpfAluno { get; set; }

 
    }
}
