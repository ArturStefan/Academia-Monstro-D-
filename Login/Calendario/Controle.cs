using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login.Calendario
{
    class Controle
    {
        int cont = 0;

        //Retorna o tamanho do mês
        private int tamanhoMes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

        //Pega que dia da semana que o mês começa
        public string primeiroDia()
        {
            string zero = DateTime.Now.Month < 10 ? "0" : "";
            DateTime dia = Convert.ToDateTime("01/" + zero + DateTime.Now.Month + "/" + DateTime.Now.Year);
            return dia.DayOfWeek.ToString();
        }

        public int botoes(int anterior, int atual, Button button)
        {
            if (anterior != 0 && anterior + 1 <= tamanhoMes || atual == 1)
            {
                atual = anterior + 1;
                button.Text = atual.ToString();
                return atual;
            }
            else
            {
                button.Visible = false;
                return atual;
            }
        }

        //Permite o usuario marca a prensença apenas naquela dia especifico
        public int marcarPresenca(int controle, int valor, Button button)
        {
            if (valor != 0)
            {
                string zero1 = valor < 10 ? "0" : "";
                string zero = DateTime.Now.Month < 10 ? "0" : "";
                DateTime botao = Convert.ToDateTime(zero1 + valor + "/" + zero + DateTime.Now.Month + "/" + DateTime.Now.Year);

                string zero2 = DateTime.Now.Day < 10 ? "0" : "";
                string zero3 = DateTime.Now.Month < 10 ? "0" : "";
                DateTime agora = Convert.ToDateTime(zero2 + DateTime.Now.Day + "/" + zero3 + DateTime.Now.Month + "/" + DateTime.Now.Year);

                if (botao == agora)
                {
                    MessageBox.Show("Prensença Confirmada");
                    button.BackColor = Color.Green;
                    return 1;
                }
                else
                {
                    MessageBox.Show("Não é possivel registrar sua presença");
                }
            }
            return 0;

        }
        //seta as cores dos botões
        public void CoresBotoes(int controle, int data, Button button)
        {
            if (data != 0)
            {
                Console.WriteLine("Controle: " + controle);
                Console.WriteLine("data: " + data);
                Console.WriteLine("botao: " + button);
                Console.WriteLine("------------------------------------------");

                string zero1 = data < 10 ? "0" : "";
                string zero = DateTime.Now.Month < 10 ? "0" : "";
                DateTime agora = Convert.ToDateTime(zero1 + data + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);

                if (controle == 1) button.BackColor = Color.Green;
                if (agora != DateTime.Now && controle == 2) button.BackColor = Color.Red;

            }
        }

        //Seta as variaveis de controle
        public int setControle(int controle, int data)
        {
            if (data != 0)
            {
                //monta a da data referente ao botão
                string zero1 = data < 10 ? "0" : "";
                string zero = DateTime.Now.Month < 10 ? "0" : "";
                DateTime botao = Convert.ToDateTime(zero1 + data + "/" + zero + DateTime.Now.Month + "/" + DateTime.Now.Year);

                //monta a data atual
                string zero2 = DateTime.Now.Day < 10 ? "0" : "";
                string zero3 = DateTime.Now.Month < 10 ? "0" : "";
                DateTime agora = Convert.ToDateTime(zero2 + DateTime.Now.Day + "/" + zero3 + DateTime.Now.Month + "/" + DateTime.Now.Year);

                //inicio comparações do controle

                if (controle == 0 && botao < agora)
                {
                    return 2;
                }
                else return controle;

            }
            return 0;


        }

        public void setContPresenca(int valor)
        {
            if(valor == 1)
            {
                cont++;
            }
        }

        public int getContPresenca()
        {
            return cont;
        }
    }
}
