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
    public class PessoaDAO : Conexao
    {
        MySqlCommand comando = null;

        int cont = 0;
        // os atributos de set e get de pessoa model e salva no Banco
        public void salvar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO cadastro_aluno(nome, sobrenome, email, cpf, nascimento, idade, cep, rua, numero, bairro, cidade, estado," +
                    " login, senha, peso, altura, sexo, imc, indice_gordura, situacao, datacadastro, vencimento_matr, tipo, bicepis, anti_braco, coxa, panturilha, peitoral, cintura, img) " +
                    "Values " +
                    "(@nome, @sobrenome, @email ,@cpf, @nascimento, @idade, @cep, @rua, @numero, @bairro, @cidade, @estado, @login, @senha, @peso, @altura," +
                    " @sexo, @imc, @indice_gordura, @situacao, @datacadastro, @vencimento_matr, @tipo, @bicepis, @anti_braco, @coxa, @panturilha, @peitoral, @cintura, @img)", conexao);

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
                comando.Parameters.AddWithValue("@peso", pessoa.peso);
                comando.Parameters.AddWithValue("@altura", pessoa.altura);
                comando.Parameters.AddWithValue("@sexo", pessoa.sexo);
                comando.Parameters.AddWithValue("@imc", pessoa.imc);
                comando.Parameters.AddWithValue("@indice_gordura", pessoa.indice_gordura);
                comando.Parameters.AddWithValue("@situacao", pessoa.situacao);
                comando.Parameters.AddWithValue("@datacadastro", pessoa.datacadastro);
                comando.Parameters.AddWithValue("@vencimento_matr", pessoa.vencimento_matr);
                comando.Parameters.AddWithValue("@tipo", pessoa.tipo_usuario);
                comando.Parameters.AddWithValue("@bicepis", pessoa.bicepis);
                comando.Parameters.AddWithValue("@anti_braco", pessoa.anti_braco);
                comando.Parameters.AddWithValue("@coxa", pessoa.coxa);
                comando.Parameters.AddWithValue("@panturilha", pessoa.panturilha);
                comando.Parameters.AddWithValue("@peitoral", pessoa.peitoral);
                comando.Parameters.AddWithValue("@cintura", pessoa.cintura);
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

                comando = new MySqlCommand("SELECT * FROM cadastro_aluno ORDER BY nome", conexao);

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

                comando = new MySqlCommand("UPDATE cadastro_aluno set nome = ?, sobrenome = ?, email = ?, cpf = ?, nascimento = ?, idade = ?, cep = ?, " +
                    "rua = ?, numero = ?, bairro = ?, cidade = ?, estado = ?, login = ?, senha = ?, peso = ?, altura = ?, sexo = ?, imc = ?, " +
                    "indice_gordura = ?, situacao = ?, datacadastro = ?, vencimento_matr = ?, tipo = ?, bicepis = ?, anti_braco = ?, coxa = ?, " +
                    "panturilha = ?, peitoral = ?, cintura = ?, where id = ?", conexao);

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
                comando.Parameters.AddWithValue("@peso", pessoa.peso);
                comando.Parameters.AddWithValue("@altura", pessoa.altura);
                comando.Parameters.AddWithValue("@sexo", pessoa.sexo);
                comando.Parameters.AddWithValue("@imc", pessoa.imc);
                comando.Parameters.AddWithValue("@indice_gordura", pessoa.indice_gordura);
                comando.Parameters.AddWithValue("@situacao", pessoa.situacao);
                comando.Parameters.AddWithValue("@datacadastro", pessoa.datacadastro);
                comando.Parameters.AddWithValue("@vencimento_matr", pessoa.vencimento_matr);
                comando.Parameters.AddWithValue("@tipo", pessoa.tipo_usuario);
                comando.Parameters.AddWithValue("@bicepis", pessoa.bicepis);
                comando.Parameters.AddWithValue("@anti_braco", pessoa.anti_braco);
                comando.Parameters.AddWithValue("@coxa", pessoa.coxa);
                comando.Parameters.AddWithValue("@panturilha", pessoa.panturilha);
                comando.Parameters.AddWithValue("@peitoral", pessoa.peitoral);
                comando.Parameters.AddWithValue("@cintura", pessoa.cintura);
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

                comando = new MySqlCommand("DELETE from cadastro_aluno where id = ?", conexao);

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

                comando = new MySqlCommand("SELECT * from cadastro_aluno where id = ?", conexao);

                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();

                //recebe todos os dados da pesquisa e armazema aqui
                MySqlDataReader dados;
                dados = comando.ExecuteReader();

                dados.Read();

                pessoas.id= Convert.ToInt32( dados[0]);
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
                pessoas.peso = Convert.ToDouble(dados[15]);
                pessoas.altura = Convert.ToDouble(dados[16]);
                pessoas.sexo = Convert.ToInt32(dados[17]);
                pessoas.imc = Convert.ToDouble(dados[18]);
                pessoas.indice_gordura = Convert.ToDouble(dados[19]);
                pessoas.situacao = dados[20].ToString();
                pessoas.datacadastro = dados[21].ToString();
                pessoas.vencimento_matr = dados[22].ToString();
                pessoas.tipo_usuario = Convert.ToInt32(dados[23]);

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
        public Pessoa loginValidar(string login1, string senha1)
        {
            Pessoa pessoas = new Pessoa();
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT * from cadastro_aluno where login = @login and senha = @senha", conexao);

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
                pessoas.nascimento = dados[5].ToString();
                pessoas.login = dados[13].ToString();
                pessoas.senha = dados[14].ToString();
                pessoas.peso = Convert.ToDouble(dados[15]);
                pessoas.sexo = Convert.ToInt32(dados[17]);
                pessoas.imc = Convert.ToDouble(dados[18]);
                pessoas.indice_gordura = Convert.ToDouble(dados[19]);
                pessoas.vencimento_matr = dados[22].ToString();
                pessoas.tipo_usuario = Convert.ToInt32(dados[23]);
                pessoas.bicepis = Convert.ToDouble(dados[24]);
                pessoas.anti_braco = Convert.ToDouble(dados[25]);
                pessoas.coxa = Convert.ToDouble(dados[26]);
                pessoas.panturilha = Convert.ToDouble(dados[27]);
                pessoas.peitoral = Convert.ToDouble(dados[28]);
                pessoas.cintura = Convert.ToDouble(dados[29]);

                //pega os dados binarios da imagem e guarda num array de bytes
                byte[] imagem = (byte[])(dados[30]);
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

        //validação de CPF no banco de dados
        public Pessoa alunoValidarCPF(string aluno_cpf)
        {
            Pessoa pessoas = new Pessoa();
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT * from cadastro_aluno where cpf = @cpf", conexao);

                comando.Parameters.AddWithValue("@cpf", aluno_cpf);

                comando.ExecuteNonQuery();

                //recebe todos os dados da pesquisa e armazema aqui
                MySqlDataReader dados;
                dados = comando.ExecuteReader();

                dados.Read();

                pessoas.id = Convert.ToInt32(dados[0]);
                pessoas.nome = dados[1].ToString();
                pessoas.cpf = dados[4].ToString();
                pessoas.vencimento_matr = dados[22].ToString();

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

        //Alterar atualizar mensalidade do aluno
        public void alterarMensalidade(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE cadastro_aluno set vencimento_matr = ? where id = ?", conexao);

                comando.Parameters.AddWithValue("@vencimento_matr", pessoa.vencimento_matr);
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

        // os atributos de set e get do exercicio model e salva no Banco
        public void salvarExerciciosAluno(Exercicios exercicio)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO exercicio_aluno(id_aluno, nome_aluno, cpf_aluno," +
                    "seg01_exerc, seg01_serie, seg01_peso, seg02_exerc, seg02_serie, seg02_peso, seg03_exerc, seg03_serie, seg03_peso," +
                    "ter01_exerc, ter01_serie, ter01_peso, ter02_exerc, ter02_serie, ter02_peso, ter03_exerc, ter03_serie, ter03_peso," +
                    "qua01_exerc, qua01_serie, qua01_peso, qua02_exerc, qua02_serie, qua02_peso, qua03_exerc, qua03_serie, qua03_peso," +
                    "qui01_exerc, qui01_serie, qui01_peso, qui02_exerc, qui02_serie, qui02_peso, qui03_exerc, qui03_serie, qui03_peso," +
                    "sex01_exerc, sex01_serie, sex01_peso, sex02_exerc, sex02_serie, sex02_peso, sex03_exerc, sex03_serie, sex03_peso," +
                    "sab01_exerc, sab01_serie, sab01_peso, sab02_exerc, sab02_serie, sab02_peso, sab03_exerc, sab03_serie, sab03_peso)" +
                    "Values " +
                    "(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", conexao);

                comando.Parameters.AddWithValue("@id_aluno", exercicio.idAluno);
                comando.Parameters.AddWithValue("@nome_aluno", exercicio.nomeAluno);
                comando.Parameters.AddWithValue("@cpf_aluno", exercicio.cpfAluno);
                comando.Parameters.AddWithValue("@seg01_exerc", exercicio.seg01_exerc);
                comando.Parameters.AddWithValue("@seg01_serie", exercicio.seg01_serie);
                comando.Parameters.AddWithValue("@seg01_peso", exercicio.seg01_peso);
                comando.Parameters.AddWithValue("@seg02_exerc", exercicio.seg02_exerc);
                comando.Parameters.AddWithValue("@seg02_serie", exercicio.seg02_serie);
                comando.Parameters.AddWithValue("@seg02_peso", exercicio.seg02_peso);
                comando.Parameters.AddWithValue("@seg03_exerc", exercicio.seg03_exerc);
                comando.Parameters.AddWithValue("@seg03_serie", exercicio.seg03_serie);
                comando.Parameters.AddWithValue("@seg03_peso", exercicio.seg03_peso);
                comando.Parameters.AddWithValue("@ter01_exerc", exercicio.ter01_exerc);
                comando.Parameters.AddWithValue("@ter01_serie", exercicio.ter01_serie);
                comando.Parameters.AddWithValue("@ter01_peso", exercicio.ter01_peso);
                comando.Parameters.AddWithValue("@ter02_exerc", exercicio.ter02_exerc);
                comando.Parameters.AddWithValue("@ter02_serie", exercicio.ter02_serie);
                comando.Parameters.AddWithValue("@ter02_peso", exercicio.ter02_peso);
                comando.Parameters.AddWithValue("@ter03_exerc", exercicio.ter03_exerc);
                comando.Parameters.AddWithValue("@ter03_serie", exercicio.ter03_serie);
                comando.Parameters.AddWithValue("@ter03_peso", exercicio.ter03_peso);
                comando.Parameters.AddWithValue("@qua01_exerc", exercicio.qua01_exerc);
                comando.Parameters.AddWithValue("@qua01_serie", exercicio.qua01_serie);
                comando.Parameters.AddWithValue("@qua01_peso", exercicio.qua01_peso);
                comando.Parameters.AddWithValue("@qua02_exerc", exercicio.qua02_exerc);
                comando.Parameters.AddWithValue("@qua02_serie", exercicio.qua02_serie);
                comando.Parameters.AddWithValue("@qua02_peso", exercicio.qua02_peso);
                comando.Parameters.AddWithValue("@qua03_exerc", exercicio.qua03_exerc);
                comando.Parameters.AddWithValue("@qua03_serie", exercicio.qua03_serie);
                comando.Parameters.AddWithValue("@qua03_peso", exercicio.qua03_peso);
                comando.Parameters.AddWithValue("@qui01_exerc", exercicio.qui01_exerc);
                comando.Parameters.AddWithValue("@qui01_serie", exercicio.qui01_serie);
                comando.Parameters.AddWithValue("@qui01_peso", exercicio.qui01_peso);
                comando.Parameters.AddWithValue("@qui02_exerc", exercicio.qui02_exerc);
                comando.Parameters.AddWithValue("@qui02_serie", exercicio.qui02_serie);
                comando.Parameters.AddWithValue("@qui02_peso", exercicio.qui02_peso);
                comando.Parameters.AddWithValue("@qui03_exerc", exercicio.qui03_exerc);
                comando.Parameters.AddWithValue("@qui03_serie", exercicio.qui03_serie);
                comando.Parameters.AddWithValue("@qui03_peso", exercicio.qui03_peso);
                comando.Parameters.AddWithValue("@sex01_exerc", exercicio.sex01_exerc);
                comando.Parameters.AddWithValue("@sex01_serie", exercicio.sex01_serie);
                comando.Parameters.AddWithValue("@sex01_peso", exercicio.sex01_peso);
                comando.Parameters.AddWithValue("@sex02_exerc", exercicio.sex02_exerc);
                comando.Parameters.AddWithValue("@sex02_serie", exercicio.sex02_serie);
                comando.Parameters.AddWithValue("@sex02_peso", exercicio.sex02_peso);
                comando.Parameters.AddWithValue("@sex03_exerc", exercicio.sex03_exerc);
                comando.Parameters.AddWithValue("@sex03_serie", exercicio.sex03_serie);
                comando.Parameters.AddWithValue("@sex03_peso", exercicio.sex03_peso);
                comando.Parameters.AddWithValue("@sab01_exerc", exercicio.sab01_exerc);
                comando.Parameters.AddWithValue("@sab01_serie", exercicio.sab01_serie);
                comando.Parameters.AddWithValue("@sab01_peso", exercicio.sab01_peso);
                comando.Parameters.AddWithValue("@sab02_exerc", exercicio.sab02_exerc);
                comando.Parameters.AddWithValue("@sab02_serie", exercicio.sab02_serie);
                comando.Parameters.AddWithValue("@sab02_peso", exercicio.sab02_peso);
                comando.Parameters.AddWithValue("@sab03_exerc", exercicio.sab03_exerc);
                comando.Parameters.AddWithValue("@sab03_serie", exercicio.sab03_serie);
                comando.Parameters.AddWithValue("@sab03_peso", exercicio.sab03_peso);

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
        public void alterarExerciciosAcad(Exercicios exercicios)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE cadastro_exercicios set nomeExercicio = ?, numRepeticoes = ? where idExercicio = ?", conexao);

                comando.Parameters.AddWithValue("@nomeExercicio", exercicios.nomeExercicio);
                comando.Parameters.AddWithValue("@numRepeticoes", exercicios.numRepeticoes);
                comando.Parameters.AddWithValue("@idExercicio", exercicios.idExercicio);

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
        public void deletarExerciciosAcad(Exercicios exercicios)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE from cadastro_exercicios where idExercicio = ?", conexao);

                comando.Parameters.AddWithValue("@idExercicio", exercicios.idExercicio);

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

        //pesquisar Exercicios do Aluno
        public Exercicios pesquisarExercicioAluno(string cpf)
        {
            Exercicios exercicio = new Exercicios();
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT * from exercicio_aluno where cpf_aluno = ?", conexao);

                comando.Parameters.AddWithValue("@cpf_aluno", cpf);

                comando.ExecuteNonQuery();

                //recebe todos os dados da pesquisa e armazema aqui
                MySqlDataReader dados;
                dados = comando.ExecuteReader();

                dados.Read();

                exercicio.cpfAluno = dados[2].ToString();
                exercicio.seg01_exerc = dados[3].ToString();
                exercicio.seg01_serie = Convert.ToInt32(dados[4].ToString());
                exercicio.seg01_peso = Convert.ToDouble(dados[5].ToString());

                exercicio.seg02_exerc = dados[6].ToString();
                exercicio.seg02_serie = Convert.ToInt32(dados[7].ToString());
                exercicio.seg02_peso = Convert.ToDouble(dados[8].ToString());

                exercicio.seg03_exerc = dados[9].ToString();
                exercicio.seg03_serie = Convert.ToInt32(dados[10].ToString());
                exercicio.seg03_peso = Convert.ToDouble(dados[11].ToString());

                exercicio.ter01_exerc = dados[12].ToString();
                exercicio.ter01_serie = Convert.ToInt32(dados[13].ToString());
                exercicio.ter01_peso = Convert.ToDouble(dados[14].ToString());

                exercicio.ter02_exerc = dados[15].ToString();
                exercicio.ter02_serie = Convert.ToInt32(dados[16].ToString());
                exercicio.ter02_peso = Convert.ToDouble(dados[17].ToString());

                exercicio.ter03_exerc = dados[18].ToString();
                exercicio.ter03_serie = Convert.ToInt32(dados[19].ToString());
                exercicio.ter03_peso = Convert.ToDouble(dados[20].ToString());

                exercicio.qua01_exerc = dados[21].ToString();
                exercicio.qua01_serie = Convert.ToInt32(dados[22].ToString());
                exercicio.qua01_peso = Convert.ToDouble(dados[23].ToString());

                exercicio.qua02_exerc = dados[24].ToString();
                exercicio.qua02_serie = Convert.ToInt32(dados[25].ToString());
                exercicio.qua02_peso = Convert.ToDouble(dados[26].ToString());

                exercicio.qua03_exerc = dados[27].ToString();
                exercicio.qua03_serie = Convert.ToInt32(dados[28].ToString());
                exercicio.qua03_peso = Convert.ToDouble(dados[29].ToString());

                exercicio.qui01_exerc = dados[30].ToString();
                exercicio.qui01_serie = Convert.ToInt32(dados[31].ToString());
                exercicio.qui01_peso = Convert.ToDouble(dados[32].ToString());

                exercicio.qui02_exerc = dados[33].ToString();
                exercicio.qui02_serie = Convert.ToInt32(dados[34].ToString());
                exercicio.qui02_peso = Convert.ToDouble(dados[35].ToString());

                exercicio.qui03_exerc = dados[36].ToString();
                exercicio.qui03_serie = Convert.ToInt32(dados[37].ToString());
                exercicio.qui03_peso = Convert.ToDouble(dados[38].ToString());

                exercicio.sex01_exerc = dados[39].ToString();
                exercicio.sex01_serie = Convert.ToInt32(dados[40].ToString());
                exercicio.sex01_peso = Convert.ToDouble(dados[41].ToString());

                exercicio.sex02_exerc = dados[42].ToString();
                exercicio.sex02_serie = Convert.ToInt32(dados[43].ToString());
                exercicio.sex02_peso = Convert.ToDouble(dados[44].ToString());

                exercicio.sex03_exerc = dados[45].ToString();
                exercicio.sex03_serie = Convert.ToInt32(dados[46].ToString());
                exercicio.sex03_peso = Convert.ToDouble(dados[47].ToString());

                exercicio.sab01_exerc = dados[48].ToString();
                exercicio.sab01_serie = Convert.ToInt32(dados[49].ToString());
                exercicio.sab01_peso = Convert.ToDouble(dados[50].ToString());

                exercicio.sab02_exerc = dados[51].ToString();
                exercicio.sab02_serie = Convert.ToInt32(dados[52].ToString());
                exercicio.sab02_peso = Convert.ToDouble(dados[53].ToString());

                exercicio.sab03_exerc = dados[54].ToString();
                exercicio.sab03_serie = Convert.ToInt32(dados[55].ToString());
                exercicio.sab03_peso = Convert.ToDouble(dados[56].ToString());

                return exercicio;
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
        public void salvarMedidasAluno(MedidasAluno medidas)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO situacao_atual_aluno(cpf_aluno, nascimento, idade_atual, altura_atual, peso_atual, gordura_atual, imc_atual, situacao_atual, " +
                    "bicepis_atual, anti_braco_atual, coxa_atual, panturilha_atual, peitoral_atual, cintura_atual, contador, sexo) " +
                    "Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", conexao);

                comando.Parameters.AddWithValue("@cpf_aluno", medidas.cpf_aluno);
                comando.Parameters.AddWithValue("@nascimento", medidas.nascimento);
                comando.Parameters.AddWithValue("@idade_atual", medidas.idade_atual);
                comando.Parameters.AddWithValue("@altura_atual", medidas.altura_atual);
                comando.Parameters.AddWithValue("@peso_atual", medidas.peso_atual);
                comando.Parameters.AddWithValue("@gordura_atual", medidas.gordura_atual);
                comando.Parameters.AddWithValue("@imc_atual", medidas.imc_atual);
                comando.Parameters.AddWithValue("@situacao_atual", medidas.situacao_atual);
                comando.Parameters.AddWithValue("@bicepis_atual", medidas.bicepis_atual);
                comando.Parameters.AddWithValue("@anti_braco_atual", medidas.anti_braco_atual);
                comando.Parameters.AddWithValue("@coxa_atual", medidas.coxa_atual);
                comando.Parameters.AddWithValue("@panturilha_atual", medidas.panturilha_atual);
                comando.Parameters.AddWithValue("@peitoral_atual", medidas.peitoral_atual);
                comando.Parameters.AddWithValue("@cintura_atual", medidas.cintura_atual);
                comando.Parameters.AddWithValue("@contador", medidas.contador);
                comando.Parameters.AddWithValue("@sexo", medidas.sexo);

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

        //pesquisar Exercicios do Aluno
        public MedidasAluno pesquisarMedidasAluno(string cpf)
        {
            MedidasAluno medidas = new MedidasAluno();
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT * from situacao_atual_aluno where cpf_aluno = ?", conexao);

                comando.Parameters.AddWithValue("@cpf_aluno", cpf);

                comando.ExecuteNonQuery();

                //recebe todos os dados da pesquisa e armazema aqui
                MySqlDataReader dados;
                dados = comando.ExecuteReader();

                dados.Read();

                medidas.cpf_aluno = dados[1].ToString();
                medidas.nascimento = dados[2].ToString();
                medidas.idade_atual = Convert.ToInt32(dados[3]);
                medidas.altura_atual = Convert.ToDouble(dados[4]);
                medidas.peso_atual = Convert.ToDouble(dados[5]);
                medidas.gordura_atual = Convert.ToDouble(dados[6]);
                medidas.imc_atual = Convert.ToDouble(dados[7]);
                medidas.situacao_atual = dados[8].ToString();
                medidas.bicepis_atual = Convert.ToDouble(dados[9]);
                medidas.anti_braco_atual = Convert.ToDouble(dados[10]);
                medidas.coxa_atual = Convert.ToDouble(dados[11]);
                medidas.panturilha_atual = Convert.ToDouble(dados[12]);
                medidas.peitoral_atual = Convert.ToDouble(dados[13]);
                medidas.cintura_atual = Convert.ToDouble(dados[14]);
                medidas.contador = Convert.ToInt32(dados[15]);
                medidas.sexo = Convert.ToInt32(dados[16]);


                return medidas;
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
        public void alterarMedidasAluno(MedidasAluno medidas)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE situacao_atual_aluno set nascimento = ?, idade_atual = ?, altura_atual = ?, peso_atual = ?, gordura_atual = ?, imc_atual = ?, situacao_atual = ?" +
                    ", bicepis_atual = ?, anti_braco_atual = ?, coxa_atual = ?, panturilha_atual = ?, peitoral_atual = ?, cintura_atual = ? where cpf_aluno = ?", conexao);

                comando.Parameters.AddWithValue("@nascimento", medidas.nascimento);
                comando.Parameters.AddWithValue("@idade_atual", medidas.idade_atual);
                comando.Parameters.AddWithValue("@altura_atual", medidas.altura_atual);
                comando.Parameters.AddWithValue("@peso_atual", medidas.peso_atual);
                comando.Parameters.AddWithValue("@gordura_atual", medidas.gordura_atual);
                comando.Parameters.AddWithValue("@imc_atual", medidas.imc_atual);
                comando.Parameters.AddWithValue("@situacao_atual", medidas.situacao_atual);
                comando.Parameters.AddWithValue("@bicepis_atual", medidas.bicepis_atual);
                comando.Parameters.AddWithValue("@anti_braco_atual", medidas.anti_braco_atual);
                comando.Parameters.AddWithValue("@coxa_atual", medidas.coxa_atual);
                comando.Parameters.AddWithValue("@panturilha_atual", medidas.panturilha_atual);
                comando.Parameters.AddWithValue("@peitoral_atual", medidas.peitoral_atual);
                comando.Parameters.AddWithValue("@cintura_atual", medidas.cintura_atual);
                comando.Parameters.AddWithValue("@cpf_aluno", medidas.cpf_aluno);

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

        //pesquisar se existe novas medidas cadastradas do Aluno
        public MedidasAluno existeNovasMedidasAluno(string cpf)
        {
            MedidasAluno medidas = new MedidasAluno();

            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT COUNT(1) FROM situacao_atual_aluno WHERE cpf_aluno = ?", conexao);

                comando.Parameters.AddWithValue("@cpf_aluno", cpf);

                comando.ExecuteNonQuery();

                var result = comando.ExecuteScalar();

                int x = Convert.ToInt32(result);

                //verifica se existe um registro no banco com este cpf
                if (x >= 1)
                {

                    medidas.novas_med = 1;
                }
                else
                {
                    medidas.novas_med = 0;
                }

                return medidas;

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

        //pesquisar se ja existe exercicios cadastradas para o Aluno
        public Exercicios existeExercicioAluno(string cpf)
        {
            Exercicios exercicios = new Exercicios();

            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT COUNT(1) FROM exercicio_aluno WHERE cpf_aluno = ?", conexao);

                comando.Parameters.AddWithValue("@cpf_aluno", cpf);

                comando.ExecuteNonQuery();

                var result = comando.ExecuteScalar();

                int x = Convert.ToInt32(result);

                //verifica se existe um registro no banco com este cpf
                if (x >= 1)
                {

                    exercicios.cad_exerc = 1;
                }
                else
                {
                    exercicios.cad_exerc = 0;
                }

                return exercicios;

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

        //Alterar atualizar imagem de cadastro do aluno
        public void AlterarImagemAluno(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE cadastro_aluno set img = ? where cpf = ?", conexao);

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

                comando = new MySqlCommand("SELECT * FROM cadastro_aluno where cpf = ? and nascimento = ?", conexao);

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

        // salvar dicas e receitas da academia e salva no Banco
        public void salvarDicaseReceitas(Exercicios exercicios)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO dicas_e_receitas (dicas_acad) Values (?)", conexao);

                comando.Parameters.AddWithValue("@dicas", exercicios.dicas_exerc_acad);

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

        //Selecionar lista de dicas de exercicios e receitas - no datatable
        public DataTable listarDicaseReceitas()
        {
            try
            {
                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                comando = new MySqlCommand("SELECT * FROM dicas_e_receitas ORDER BY id_dicas_acad", conexao);

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

        // Inicia as variaveis do calendario
        public void salvarCalendario(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO variaveis(cpf,a1,b1,c1,d1,e1,f1,g1,a2,b2,c2,d2,e2,f2,g2,a3,b3,c3,d3,e3,f3,g3,a4,b4,c4,d4,e4,f4,g4,a5,b5,c5,d5,e5,f5,g5,a6,b6) Values (?,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)", conexao);

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

                comando = new MySqlCommand("SELECT * FROM cadastro_aluno where cpf = ?", conexao);

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

        //Metodo para Pesquisar dicas de exercicios e receitas
        public Exercicios buscarDicasExerciciosAluno()
        {
            Exercicios exercicios = new Exercicios();
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT * FROM dicas_e_receitas order by rand() Limit 1", conexao);

                comando.ExecuteNonQuery();

                //recebe todos os dados da pesquisa e armazena aqui
                MySqlDataReader dados;
                dados = comando.ExecuteReader();

                dados.Read();

                exercicios.dicas_exerc_aluno = dados[1].ToString();
                

                return exercicios;
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

                comando = new MySqlCommand("UPDATE cadastro_aluno set nome = ?, sobrenome = ?, email = ?, nascimento = ?, idade = ?, cep = ?, " +
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

        //metodo para Pesquisar se o aluno marcou presença
        public Pessoa verificarPresenca(string aluno_cpf)
        {
            Pessoa pessoas = new Pessoa();
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT * from variaveis where cpf = ?", conexao);

                comando.Parameters.AddWithValue("@cpf", aluno_cpf);

                comando.ExecuteNonQuery();

                //recebe todos os dados da pesquisa e armazema aqui
                MySqlDataReader dados;
                dados = comando.ExecuteReader();

                dados.Read();

                //melhorar o codigo se for possivel
              
                int a1 = Convert.ToInt32(dados[1]);
                int b1 = Convert.ToInt32(dados[2]);
                int c1 = Convert.ToInt32(dados[3]);
                int d1 = Convert.ToInt32(dados[4]);
                int e1 = Convert.ToInt32(dados[5]);
                int f1 = Convert.ToInt32(dados[6]);
                int g1 = Convert.ToInt32(dados[7]);

                int a2 = Convert.ToInt32(dados[8]);
                int b2 = Convert.ToInt32(dados[9]);
                int c2 = Convert.ToInt32(dados[10]);
                int d2 = Convert.ToInt32(dados[11]);
                int e2 = Convert.ToInt32(dados[12]);
                int f2 = Convert.ToInt32(dados[13]);
                int g2 = Convert.ToInt32(dados[14]);

                int a3 = Convert.ToInt32(dados[15]);
                int b3 = Convert.ToInt32(dados[16]);
                int c3 = Convert.ToInt32(dados[17]);
                int d3 = Convert.ToInt32(dados[18]);
                int e3 = Convert.ToInt32(dados[19]);
                int f3 = Convert.ToInt32(dados[20]);
                int g3 = Convert.ToInt32(dados[21]);

                int a4 = Convert.ToInt32(dados[22]);
                int b4 = Convert.ToInt32(dados[23]);
                int c4 = Convert.ToInt32(dados[24]);
                int d4 = Convert.ToInt32(dados[25]);
                int e4 = Convert.ToInt32(dados[26]);
                int f4 = Convert.ToInt32(dados[27]);
                int g4 = Convert.ToInt32(dados[28]);

                int a5 = Convert.ToInt32(dados[29]);
                int b5 = Convert.ToInt32(dados[30]);
                int c5 = Convert.ToInt32(dados[31]);
                int d5 = Convert.ToInt32(dados[32]);
                int e5 = Convert.ToInt32(dados[33]);
                int f5 = Convert.ToInt32(dados[34]);
                int g5 = Convert.ToInt32(dados[35]);

                int a6 = Convert.ToInt32(dados[36]);
                int b6 = Convert.ToInt32(dados[37]);

                int soma = a1 + b1 + c1 + d1 + e1 + f1 + g1 + a2 + b2 + c2 + d2 + e2 + f2 + g2
                    + a3 + b3 + c3 + d3 + e3 + f3 + g3 + a4 + b4 + c4 + d4 + e4 + f4 + g4
                    + a5 + b5 + c5 + d5 + e5 + f5 + g5 + a6 + b6;

                pessoas.presenca = soma;

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

    }
}
