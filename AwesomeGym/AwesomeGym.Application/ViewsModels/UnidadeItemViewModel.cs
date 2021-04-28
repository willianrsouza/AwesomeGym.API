using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeGym.Application.ViewsModels
{
    class UnidadeItemViewModel
    {
        public int id { get; set; }
        public String nome { get; set; }

        public UnidadeItemViewModel(int id, String nome)
        {
            this.id = id;
            this.nome = nome;
        }
    }
}
