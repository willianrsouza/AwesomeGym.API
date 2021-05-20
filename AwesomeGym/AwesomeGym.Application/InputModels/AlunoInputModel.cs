using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeGym.Application.InputModels
{
    public class AlunoInputModel
    {
        public string nomeAluno { get; set; }
        public string cpfAluno { get; set; }
        public NotaFiscal[] NotasFiscais { get; set; }
    }

    public class NotaFiscal
    {
        public int Serie { get; set; }
        public int Numero { get; set; }
        public DateTime Emissao { get; set; }
    }


}
