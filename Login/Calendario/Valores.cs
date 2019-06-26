using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Calendario
{
    public class Valores
    {
        public string CPF { get; set; }
        public List<int> Vetor { get; set; }

        public Valores(string cpf, List<int> vetor)
        {
            CPF = cpf;
            Vetor = vetor;
        }
    }
}
