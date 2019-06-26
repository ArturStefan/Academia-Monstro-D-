using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Academia.model;
using System.Data;
using System.Windows.Forms;
using Login.Model;

namespace Academia.Dao
{
    public class FuncionarioDAO : Conexao
    {
        MySqlCommand comando = null;

        // os atributos de set e get de pessoa model e salva no Banco
        public void salvar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO cadastro_funcionarios(nome, sobrenome, email, cpf, nascimento, idade, cep, rua, numero, bairro, cidade, estado," +
                    " login, senha, datacadastro, tipo, confef, img) " +
                    "Values " +
                    "(@nome, @sobrenome, @email ,@cpf, @nascimento, @idade, @cep, @rua, @numero, @bairro, @cidade, @estado, @login, @senha," +
                    " @datacadastro, @tipo, @confef, @img)", conexao);

                comando.Parameters.AddWithValue("@nome", pessoa.nome);
                comando.Parameters.AddWithValue("@sobrenome", pessoa.sobrenome);
                comando.Parameters.AddWithValue("@email", pessoa.email);
                comando.Parameters.AddWithValue("@cpf", pessoa.cpf);
                comando.Parameters.AddWithValue("@nascimento", pessoa.nascimento);
                comando.Parameters.AddWithValue("@idade", pessoa.idade);
                comando.Parameters.AddWithValue("@cep", pessoa.cep);
                comando.Parameters.AddWithValue("@rua", pessoa.rua);
                comando.Parameters.AddWithValue("@numero", pessoa.numero);
                comando.Parameters.AddWithValue("@bairro", pessoa.bairro);
                comando.Parameters.AddWithValue("@cidade", pessoa.cidade);
                comando.Parameters.AddWithValue("@estado", pessoa.estado);
                comando.Parameters.AddWithValue("@login", pessoa.login);
                comando.Parameters.AddWithValue("@senha", pessoa.senha);        
                comando.Parameters.AddWithValue("@datacadastro", pessoa.datacadastro);
                comando.Parameters.AddWithValue("@tipo", pessoa.tipo_usuario);
                comando.Parameters.AddWithValue("@confef", pessoa.confef);
                comando.Parameters.AddWithValue("@img", pessoa.img);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //Selecionar usuarios - no datatable
        public DataTable listar()
        {
            try
            {
                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                comando = new MySqlCommand("SELECT * FROM cadastro_funcionarios ORDER BY nome", conexao);

                da.SelectCommand = comando;

                da.Fill(dt);

                return dt;
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        // os atributos de set e get de pessoa model e salva no Banco
        public void salvarExercicio(Exercicios exercicios)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO cadastro_exercicios(nomeExercicio, numRepeticoes) Values (@nomeExercicio, @numRepeticoes)", conexao);

                comando.Parameters.AddWithValue("@nomeExercicio", exercicios.nomeExercicio);
                comando.Parameters.AddWithValue("@numRepeticoes", exercicios.numRepeticoes);
                

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //Selecionar lista de exercicios - no datatable
        public DataTable listarExercicio()
        {
            try
            {
                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                comando = new MySqlCommand("SELECT * FROM cadastro_exercicios ORDER BY nomeExercicio", conexao);

                da.SelectCommand = comando;

                da.Fill(dt);

                return dt;
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //alterar no banco de dados
        public void alterar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE cadastro_funcionarios set nome = ?, sobrenome = ?, email = ?, cpf = ?, nascimento = ?, idade = ?, cep = ?, " +
                    "rua = ?, numero = ?, bairro = ?, cidade = ?, estado = ?, login = ?, senha = ?, " +
                    "datacadastro = ?, tipo = ?, confef = ?, where id = ?", conexao);

                comando.Parameters.AddWithValue("@nome", pessoa.nome);
                comando.Parameters.AddWithValue("@sobrenome", pessoa.sobrenome);
                comando.Parameters.AddWithValue("@email", pessoa.email);
                comando.Parameters.AddWithValue("@cpf", pessoa.cpf);
                comando.Parameters.AddWithValue("@nascimento", pessoa.nascimento);
                comando.Parameters.AddWithValue("@idade", pessoa.idade);
                comando.Parameters.AddWithValue("@cep", pessoa.cep);
                comando.Parameters.AddWithValue("@rua", pessoa.rua);
                comando.Parameters.AddWithValue("@numero", pessoa.numero);
                comando.Parameters.AddWithValue("@bairro", pessoa.bairro);
                comando.Parameters.AddWithValue("@cidade", pessoa.cidade);
                comando.Parameters.AddWithValue("@estado", pessoa.estado);
                comando.Parameters.AddWithValue("@login", pessoa.login);
                comando.Parameters.AddWithValue("@senha", pessoa.senha);               
                comando.Parameters.AddWithValue("@datacadastro", pessoa.datacadastro);
                comando.Parameters.AddWithValue("@tipo", pessoa.tipo_usuario);
                comando.Parameters.AddWithValue("@confef", pessoa.confef);
                comando.Parameters.AddWithValue("@id", pessoa.id);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //alterar no banco de dados
        public void deletar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE from cadastro_funcionarios where id = ?", conexao);

                comando.Parameters.AddWithValue("@id", pessoa.id);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //pesquisar no banco de dados
        public Pessoa pesquisar(int id)
        {
            Pessoa pessoas = new Pessoa();
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT * from cadastro_funcionarios where id = ?", conexao);

                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();

                //recebe todos os dados da pesquisa e armazema aqui
                MySqlDataReader dados;
                dados = comando.ExecuteReader();

                dados.Read();

                pessoas.id = Convert.ToInt32(dados[0]);
                pessoas.nome = dados[1].ToString();
                pessoas.sobrenome = dados[2].ToString();
                pessoas.email = dados[3].ToString();
                pessoas.cpf = dados[4].ToString();
                pessoas.nascimento = dados[5].ToString();
                pessoas.idade = Convert.ToInt32(dados[6]);
                pessoas.cep = dados[7].ToString();
                pessoas.rua = dados[8].ToString();
                pessoas.numero = Convert.ToInt32(dados[9]);
                pessoas.bairro = dados[10].ToString();
                pessoas.cidade = dados[11].ToString();
                pessoas.estado = dados[12].ToString();
                pessoas.login = dados[13].ToString();
                pessoas.senha = dados[14].ToString();               
                pessoas.datacadastro = dados[15].ToString();              
                pessoas.tipo_usuario = Convert.ToInt32(dados[16]);
                pessoas.confef = Convert.ToInt32(dados[17]);

                return pessoas;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //validação de login e senha no banco de dados
        public Pessoa loginValidar2(string login1, string senha1)
        {
            Pessoa pessoas = new Pessoa();
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT * from cadastro_funcionarios where login = @login and senha = @senha", conexao);

                comando.Parameters.AddWithValue("@login", login1);
                comando.Parameters.AddWithValue("@senha", senha1);

                comando.ExecuteNonQuery();

                //recebe todos os dados da pesquisa e armazema aqui
                MySqlDataReader dados;
                dados = comando.ExecuteReader();

                dados.Read();

                pessoas.id = Convert.ToInt32(dados[0]);
                pessoas.nome = dados[1].ToString();
                pessoas.cpf = dados[4].ToString();
                pessoas.login = dados[13].ToString();
                pessoas.senha = dados[14].ToString();
                pessoas.tipo_usuario = Convert.ToInt32(dados[16]);
                pessoas.confef = Convert.ToInt32(dados[17]);

                //pega os dados binarios da imagem e guarda num array de bytes
                byte[] imagem = (byte[])(dados[18]);
                pessoas.img = imagem;

                return pessoas;
            }
            catch (Exception erro)
            {
                throw erro;
                //MessageBox.Show("Senha ou usuario incorretos!");
            }
            finally
            {
                FecharConexao();
            }
        }

        //Alterar atualizar imagem de cadastro do funcionario
        public void AlterarImagemFuncionario(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE cadastro_funcionarios set img = ? where cpf = ?", conexao);

                comando.Parameters.AddWithValue("@img", pessoa.img);
                comando.Parameters.AddWithValue("@cpf", pessoa.cpf);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //Pesquisar se existe usuario com CPF e Dica de senha no banco
        public Pessoa ValidarCPFMudaSenha(string cpf, string nascimento)
        {
            Pessoa pessoa = new Pessoa();
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT * FROM cadastro_funcionarios where cpf = ? and nascimento = ?", conexao);

                comando.Parameters.AddWithValue("@cpf", cpf);
                comando.Parameters.AddWithValue("@nascimento", nascimento);

                comando.ExecuteNonQuery();

                //recebe todos os dados da pesquisa e armazena aqui
                MySqlDataReader dados;
                dados = comando.ExecuteReader();

                dados.Read();

                pessoa.cpf = dados[4].ToString();
                pessoa.nascimento = dados[5].ToString();
                pessoa.login = dados[13].ToString();

                return pessoa;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //Alterar atualizar mensalidade do aluno
        public void AlterarLogineSenha(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE cadastro_aluno set login = ?, senha = ? where cpf = ?", conexao);

                comando.Parameters.AddWithValue("@login", pessoa.login);
                comando.Parameters.AddWithValue("@senha", pessoa.senha);
                comando.Parameters.AddWithValue("@cpf", pessoa.cpf);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //Pesquisar se existe usuario com CPF e Dica de senha no banco
        public Pessoa buscarDadosUsuario(string cpf)
        {
            Pessoa pessoa = new Pessoa();
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT * FROM cadastro_funcionarios where cpf = ?", conexao);

                comando.Parameters.AddWithValue("@cpf", cpf);

                comando.ExecuteNonQuery();

                //recebe todos os dados da pesquisa e armazena aqui
                MySqlDataReader dados;
                dados = comando.ExecuteReader();

                dados.Read();

                pessoa.nome = dados[1].ToString();
                pessoa.sobrenome = dados[2].ToString();
                pessoa.email = dados[3].ToString();
                pessoa.cpf = dados[4].ToString();
                pessoa.nascimento = dados[5].ToString();
                pessoa.idade = Convert.ToInt32(dados[6]);
                pessoa.cep = dados[7].ToString();
                pessoa.rua = dados[8].ToString();
                pessoa.numero = Convert.ToInt32(dados[9]);
                pessoa.bairro = dados[10].ToString();
                pessoa.cidade = dados[11].ToString();
                pessoa.estado = dados[12].ToString();
                pessoa.login = dados[13].ToString();
                pessoa.senha = dados[14].ToString();

                return pessoa;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //alterar dados de cadastro do usuario
        public void alterarDadosCadastro(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE cadastro_funcionarios set nome = ?, sobrenome = ?, email = ?, nascimento = ?, idade = ?, cep = ?, " +
                    "rua = ?, numero = ?, bairro = ?, cidade = ?, estado = ? where cpf = ?", conexao);

                comando.Parameters.AddWithValue("@nome", pessoa.nome);
                comando.Parameters.AddWithValue("@sobrenome", pessoa.sobrenome);
                comando.Parameters.AddWithValue("@email", pessoa.email);
                comando.Parameters.AddWithValue("@nascimento", pessoa.nascimento);
                comando.Parameters.AddWithValue("@idade", pessoa.idade);
                comando.Parameters.AddWithValue("@cep", pessoa.cep);
                comando.Parameters.AddWithValue("@rua", pessoa.rua);
                comando.Parameters.AddWithValue("@numero", pessoa.numero);
                comando.Parameters.AddWithValue("@bairro", pessoa.bairro);
                comando.Parameters.AddWithValue("@cidade", pessoa.cidade);
                comando.Parameters.AddWithValue("@estado", pessoa.estado);
                comando.Parameters.AddWithValue("@cpf", pessoa.cpf);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}

