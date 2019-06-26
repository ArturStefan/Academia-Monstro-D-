using Academia;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.Calendario
{
    class DAO: Conexao
    {
        private MySqlCommand cmd;

        public DAO() => cmd = null;

        public void salvarBd(string posicao, int atual, string cpf)
        {
            try
            {
                AbrirConexao();             

                cmd = new MySqlCommand("UPDATE variaveis set "+ posicao +" = @atual  where cpf = @cpf ", conexao);

                cmd.Parameters.AddWithValue("@atual", atual);
                cmd.Parameters.AddWithValue("@cpf", cpf);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro de conexão 1", "Aviso");
            }
            finally
            {
                FecharConexao();

            }

        }

        public Valores Valor(string cpf)
        {
            try
            {
                AbrirConexao();

                Valores valores;


                MySqlCommand cmd = new MySqlCommand("SELECT * from variaveis where cpf = ?", conexao);

                cmd.Parameters.AddWithValue("@cpf", cpf);

                cmd.ExecuteNonQuery();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        List<int> lista = new List<int>();
                        for (int i = 1; i <= 37; i++)
                        {
                            lista.Add((int)reader[i]);
                        }

                        valores = new Valores(reader[0].ToString(), lista);

                        return valores;
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Valores> Consultas(string cpf)
        {
            List<Valores> listaValores = new List<Valores>();

            try
            {
                AbrirConexao();

                MySqlCommand cmd = new MySqlCommand(
                    "SELECT * FROM variaveis where cpf LIKE @cpf;",
                    conexao);

                cmd.Parameters.AddWithValue("@cpf", "%" + cpf + "%");
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        List<int> lista = new List<int>();
                        for (int i = 1; i <= 37; i++)
                        {
                            lista.Add((int)reader[i]);
                        }

                        Valores valores = new Valores(reader[0].ToString(), lista);
                        listaValores.Add(valores);
                    }
                }
                return listaValores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Valores> LerTodos()
        {
            List<Valores> listaValores = new List<Valores>();

            try
            {
                AbrirConexao();

                MySqlCommand cmd = new MySqlCommand(
                    "SELECT * FROM variaveis;",
                    conexao);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        List<int> lista = new List<int>();
                        for (int i = 1; i <= 37; i++)
                        {
                            lista.Add((int)reader[i]);
                        }

                        Valores valores = new Valores(reader[0].ToString(), lista);
                        listaValores.Add(valores);
                    }
                }
                return listaValores;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                FecharConexao();
            }
        }

        //atualiza todas as variaveis no bd
        public void atualizaBd(string cpf, List<int> vetor)
        {
            try
            {
                AbrirConexao();

                MySqlCommand cmd = new MySqlCommand(
                     "UPDATE variaveis SET a1 =   " + vetor[0] + ", b1 = " + vetor[1] + ", c1 = " + vetor[2] + ", " +
                     "d1 = " + vetor[3] + ", e1 = " + vetor[4] + ", f1= " + vetor[5] + ", g1 = " + vetor[6] + ", " +
                     "a2 = " + vetor[7] + ", b2 = " + vetor[8] + ", c2= " + vetor[9] + ", d2 = " + vetor[10] + ", " +
                     "e2 = " + vetor[11] + ", f2 = " + vetor[12] + ", g2 = " + vetor[13] + ", a3 = " + vetor[14] + ", " +
                     "b3 = " + vetor[15] + ", c3 = " + vetor[16] + ", d3 = " + vetor[17] + ", e3 = " + vetor[18] + ", " +
                     "f3 = " + vetor[19] + ", g3 = " + vetor[20] + ", a4 = " + vetor[21] + ", b4 = " + vetor[22] + ", " +
                     "c4 = " + vetor[23] + ", d4 = " + vetor[24] + ", e4 = " + vetor[25] + ", f4 = " + vetor[26] + ", " +
                     "g4 = " + vetor[27] + ", a5 = " + vetor[28] + ", b5 = " + vetor[29] + ", c5 = " + vetor[30] + ", " +
                     "d5 = " + vetor[31] + ", e5 = " + vetor[32] + ", f5 = " + vetor[33] + ", g5 = " + vetor[34] + ", " +
                     "a6 = " + vetor[35] + ", b6 = " + vetor[36] + " WHERE cpf = " + cpf + " ;", conexao
                    );

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //MessageBox.Show("Erro de conexão 2", "Aviso");
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
