using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class IndiceGordura
    {
        private double peso;
        private double altura;
        private int idade;
        private int sexo;
        private double imc_calc;
        private double indice;
        private string situacao;

        public IndiceGordura()
        {

        }

        public void setPeso(double p)
        {
            peso = p;
        }

        public void setAltura(double a)
        {
            altura = a;
        }

        public void setIdade(int i)
        {
            idade = i;
        }

        public void setSexo(int sx)
        {
            sexo = sx;
        }
        public double getPeso()
        {
            return peso;
        }

        public double getAltura()
        {
            return altura;
        }

        public int getIdade()
        {
            return idade;
        }

        public int getSexo()
        {
            return sexo;
        }

        //retorna o calculo do IMC
        public double IMC()
        {
            if (sexo == 1)
            {
                imc_calc = peso / Math.Pow(altura, 2);
            }
            else if (sexo == 0)
            {
                imc_calc = peso / Math.Pow(altura, 2);
            }
            return imc_calc;

        }

        //retorna o % de gordura do Aluno
        public double Indice()
        {

            imc_calc = peso / Math.Pow(altura, 2);

            if (sexo == 1)
            {
                indice = (1.20 * imc_calc) + (0.23 * idade) - (10.8 * 1) - 5.4;
            }
            else if (sexo == 0)
            {
                indice = (1.20 * imc_calc) + (0.23 * idade) - (10.8 * 0) - 5.4;
            }
            return indice;
        }

        //retorna a classificação do aluno se esta saudavel ou obeso
        public string SituacaoAluno()
        {
            if (sexo == 1)
            {

                if (idade >= 20 && idade <= 29)
                {
                    if (indice < 5.2)
                    {
                        situacao = "Muito Magro";
                    }

                    if (indice >= 5.2 && indice < 9.3)
                    {
                        situacao = "Magro";
                    }

                    if (indice >= 9.3 && indice < 14.01)
                    {
                        situacao = "Muito Bom";
                    }

                    if (indice >= 14.01 && indice < 17.5)
                    {
                        situacao = "Saudável";
                    }

                    if (indice >= 17.5 && indice < 22.4)
                    {
                        situacao = "Sobrepeso";
                    }

                    if (indice >= 22.4 && indice < 29.2)
                    {
                        situacao = "Gordo";
                    }

                    if (indice >= 29.2)
                    {
                        situacao = "Obeso";
                    }
                }

                if (idade >= 30 && idade <= 39)
                {
                    if (indice < 9.2)
                    {
                        situacao = "Muito Magro";
                    }

                    if (indice >= 9.2 && indice < 14)
                    {
                        situacao = "Magro";
                    }

                    if (indice >= 14 && indice < 17.5)
                    {
                        situacao = "Muito Bom";
                    }

                    if (indice >= 17.5 && indice < 20.6)
                    {
                        situacao = "Saudável";
                    }

                    if (indice >= 20.6 && indice < 24.2)
                    {
                        situacao = "Sobrepeso";
                    }

                    if (indice >= 24.2 && indice < 30)
                    {
                        situacao = "Gordo";
                    }

                    if (indice >= 30)
                    {
                        situacao = "Obeso";
                    }
                }

                if (idade >= 40 && idade <= 49)
                {
                    if (indice < 11.5)
                    {
                        situacao = "Muito Magro";
                    }

                    if (indice >= 11.5 && indice < 16.3)
                    {
                        situacao = "Magro";
                    }

                    if (indice >= 16.3 && indice < 19.6)
                    {
                        situacao = "Muito Bom";
                    }

                    if (indice >= 19.6 && indice < 22.5)
                    {
                        situacao = "Saudável";
                    }

                    if (indice >= 22.5 && indice < 26.2)
                    {
                        situacao = "Sobrepeso";
                    }

                    if (indice >= 26.2 && indice < 31.4)
                    {
                        situacao = "Gordo";
                    }

                    if (indice >= 31.4)
                    {
                        situacao = "Obeso";
                    }
                }

                if (idade >= 50 && idade <= 59)
                {
                    if (indice < 12.9)
                    {
                        situacao = "Muito Magro";
                    }

                    if (indice >= 12.9 && indice < 18.1)
                    {
                        situacao = "Magro";
                    }

                    if (indice >= 18.1 && indice < 21.2)
                    {
                        situacao = "Muito Bom";
                    }

                    if (indice >= 21.2 && indice < 24.2)
                    {
                        situacao = "Saudável";
                    }

                    if (indice >= 24.2 && indice < 27.6)
                    {
                        situacao = "Sobrepeso";
                    }

                    if (indice >= 27.6 && indice < 32.4)
                    {
                        situacao = "Gordo";
                    }

                    if (indice >= 32.4)
                    {
                        situacao = "Obeso";
                    }
                }

                if (idade >= 60 )
                {
                    if (indice < 13)
                    {
                        situacao = "Muito Magro";
                    }

                    if (indice >= 13 && indice < 18.5)
                    {
                        situacao = "Magro";
                    }

                    if (indice >= 18.5 && indice < 22)
                    {
                        situacao = "Muito Bom";
                    }

                    if (indice >= 22 && indice < 25)
                    {
                        situacao = "Saudável";
                    }

                    if (indice >= 25 && indice < 28.4)
                    {
                        situacao = "Sobrepeso";
                    }

                    if (indice >= 28.4 && indice < 33.5)
                    {
                        situacao = "Gordo";
                    }

                    if (indice >= 33.5)
                    {
                        situacao = "Obeso";
                    }
                }

            }

            if (sexo == 0)
            {

                if (idade >= 20 && idade <= 29)
                {
                    if (indice < 10.7)
                    {
                        situacao = "Muito Magro";
                    }

                    if (indice >= 10.7 && indice < 17)
                    {
                        situacao = "Magro";
                    }

                    if (indice >= 17 && indice < 20.5)
                    {
                        situacao = "Muito Bom";
                    }

                    if (indice >= 20.5 && indice < 23.8)
                    {
                        situacao = "Saudável";
                    }

                    if (indice >= 23.8 && indice < 27.6)
                    {
                        situacao = "Sobrepeso";
                    }

                    if (indice >= 27.6 && indice < 35.5)
                    {
                        situacao = "Gordo";
                    }

                    if (indice >= 35.5)
                    {
                        situacao = "Obeso";
                    }
                }

                if (idade >= 30 && idade <= 39)
                {
                    if (indice < 13.3)
                    {
                        situacao = "Muito Magro";
                    }

                    if (indice >= 13.3 && indice < 18)
                    {
                        situacao = "Magro";
                    }

                    if (indice >= 18 && indice < 21.8)
                    {
                        situacao = "Muito Bom";
                    }

                    if (indice >= 21.8 && indice < 24.8)
                    {
                        situacao = "Saudável";
                    }

                    if (indice >= 24.8 && indice < 30)
                    {
                        situacao = "Sobrepeso";
                    }

                    if (indice >= 30 && indice < 35.8)
                    {
                        situacao = "Gordo";
                    }

                    if (indice >= 35.8)
                    {
                        situacao = "Obeso";
                    }
                }

                if (idade >= 40 && idade <= 49)
                {
                    if (indice < 16.1)
                    {
                        situacao = "Muito Magro";
                    }

                    if (indice >= 16.1 && indice < 21.4)
                    {
                        situacao = "Magro";
                    }

                    if (indice >= 21.4 && indice < 25.1)
                    {
                        situacao = "Muito Bom";
                    }

                    if (indice >= 25.1 && indice < 28.3)
                    {
                        situacao = "Saudável";
                    }

                    if (indice >= 28.3 && indice < 32.1)
                    {
                        situacao = "Sobrepeso";
                    }

                    if (indice >= 32.1 && indice < 37.7)
                    {
                        situacao = "Gordo";
                    }

                    if (indice >= 37.7)
                    {
                        situacao = "Obeso";
                    }
                }

                if (idade >= 50 && idade <= 59)
                {
                    if (indice < 18.8)
                    {
                        situacao = "Muito Magro";
                    }

                    if (indice >= 18.8 && indice < 25.1)
                    {
                        situacao = "Magro";
                    }

                    if (indice >= 25.1 && indice < 28.6)
                    {
                        situacao = "Muito Bom";
                    }

                    if (indice >= 28.6 && indice < 32.5)
                    {
                        situacao = "Saudável";
                    }

                    if (indice >= 32.5 && indice < 35.6)
                    {
                        situacao = "Sobrepeso";
                    }

                    if (indice >= 35.6 && indice < 39.6)
                    {
                        situacao = "Gordo";
                    }

                    if (indice >= 39.6)
                    {
                        situacao = "Obeso";
                    }
                }

                if (idade >= 60)
                {
                    if (indice < 19.1)
                    {
                        situacao = "Muito Magro";
                    }

                    if (indice >= 19.1 && indice < 25)
                    {
                        situacao = "Magro";
                    }

                    if (indice >= 25 && indice < 29.5)
                    {
                        situacao = "Muito Bom";
                    }

                    if (indice >= 29.5 && indice < 32.8)
                    {
                        situacao = "Saudável";
                    }

                    if (indice >= 32.8 && indice < 36.7)
                    {
                        situacao = "Sobrepeso";
                    }

                    if (indice >= 36.7 && indice < 40.4)
                    {
                        situacao = "Gordo";
                    }

                    if (indice >= 40.4)
                    {
                        situacao = "Obeso";
                    }
                }
            }
            return situacao;
        }
    }
}
