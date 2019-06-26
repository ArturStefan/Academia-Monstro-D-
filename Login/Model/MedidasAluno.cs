using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Model
{
    public class MedidasAluno
    {
        public string cpf_aluno { get; set; }

        public string nascimento { get; set; }

        public int idade_atual { get; set; }

        public double altura_atual { get; set; }

        public double peso_atual { get; set; }

        public double gordura_atual { get; set; }

        public double imc_atual { get; set; }

        public string situacao_atual { get; set; }

        public double bicepis_atual { get; set; }

        public double anti_braco_atual { get; set; }

        public double coxa_atual { get; set; }

        public double panturilha_atual { get; set; }

        public double peitoral_atual { get; set; }

        public double cintura_atual { get; set; }

        public int contador { get; set; }

        public int sexo { get; set; }

        public int novas_med { get; set; }

    }
}
