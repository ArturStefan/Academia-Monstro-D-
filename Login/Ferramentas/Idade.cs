using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Idade
    {
        DateTime data_pc;
        DateTime nasc;
        DateTime mensalidade;
        DateTime data_valida;

        public Idade()
        {
        }

        public void setDataAtual(DateTime data_at)
        {
            data_pc = data_at;
        }

        public void setDataNasc(DateTime data_nasc)
        {
            nasc = data_nasc;
        }

        public void setDataMens(DateTime data_mens)
        {
            mensalidade = data_mens;
        }

        public void setDataVal(DateTime val)
        {
            data_valida = val;
        }

        public DateTime getDataAtual()
        {
            return data_pc;
        }

        public DateTime getDataNasc()
        {
            return nasc;
        }

        public DateTime getDataMens()
        {
            return mensalidade;
        }

        public DateTime getDataVal()
        {
            return data_valida;
        }

        //Retorna a idade do aluno para o textBox
        public string IdadeAluno()
        {
            //pega data atual do PC e converte
            string data_comp;
            data_comp = Convert.ToString(getDataAtual());

            DateTime pc_convertido;
            pc_convertido = DateTime.Parse(data_comp);

            //pega data de nascimeto e converte
            string data_nascim;
            data_nascim = Convert.ToString(getDataNasc());

            DateTime nasc_convertido;
            nasc_convertido = DateTime.Parse(data_nascim);

            //Executa o calcula para saber quantos anos a pessoa tem
            TimeSpan id;
            id = pc_convertido - nasc_convertido;

            //converte o resultado em dias para anos
            string res_idade = Convert.ToString(id.Days / 30 / 12);

            return res_idade;
        }

        //Retorna os dias para vencer a mensalidade do aluno para o textBox
        public string Mensalidade()
        {
            //pega data atual do PC e converte
            string data_comp;
            data_comp = Convert.ToString(getDataAtual());

            DateTime pc_convertido;
            pc_convertido = DateTime.Parse(data_comp);

            //pega data de nascimeto e converte
            string data_vencimento;
            data_vencimento = Convert.ToString(getDataMens());

            DateTime venc_convertido;
            venc_convertido = DateTime.Parse(data_vencimento);

            //Executa o calcula para saber quantos anos a pessoa tem
            TimeSpan id;
            id = venc_convertido - pc_convertido;

            //converte o resultado em dias
            string dias_restante = Convert.ToString(id.Days);

            return dias_restante;
        }

        //Verificação para saber se a data da mensalidade e valida
        public string VerificarAnoValidoMensalidade()
        {
            //pega data atual do PC e converte
            string data_comp1;
            data_comp1 = Convert.ToString(getDataAtual());

            DateTime pc_convertido1;
            pc_convertido1 = DateTime.Parse(data_comp1);

            //pega data de nascimeto e converte
            string data_validade;
            data_validade = Convert.ToString(getDataVal());

            DateTime val_convertido;
            val_convertido = DateTime.Parse(data_validade);

            //Executa o calcula para saber quantos anos a pessoa tem
            TimeSpan id1;
            id1 = val_convertido - pc_convertido1;

            //converte o resultado em dias
            string dias_restante_val = Convert.ToString(id1.Days);

            return dias_restante_val;
        }
    }
}
