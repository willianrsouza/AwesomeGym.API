using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeGym.Core.Entidades
{
    public class Equipamento
    {
        public Equipamento(string nomeEquipamento, int anoAdquirido)
        {
            this.nomeEquipamento = nomeEquipamento;
            this.anoAdquirido = anoAdquirido;
        }

        public int id { get; set; }
        public string nomeEquipamento { get; set; }
        public int anoAdquirido { get; set; }

    }
}
