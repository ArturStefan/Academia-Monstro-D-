using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Dao;
using Academia.model;
using System.Windows.Forms;
using System.Data;
using Login.Model;

namespace Academia.Bll
{

    //esta classe faz intermediação entre o formulario e a classe de salvar no banco
    public class PessoaBLL
    {
        PessoaDAO pessoaDao = new PessoaDAO();

        //Metodo para Salvar no Banco
        public void salvar(Pessoa pessoa)
        {
            try
            {
                pessoaDao.salvar(pessoa);
                MessageBox.Show("Dados Salvo com Sucesso!");
            }
            catch 
            {
                MessageBox.Show("Ja existe um usuario cadastrado com este cpf");
            }
        }

        //Metodo para listar na Table
        public DataTable listar()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = pessoaDao.listar();

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Alterar dados no Banco
        public void alterar(Pessoa pessoa)
        {
            try
            {
                pessoaDao.alterar(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Deletar dados no Banco
        public void deletar(Pessoa pessoa)
        {
            try
            {
                pessoaDao.deletar(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Pesquisar dados no Banco
        public void pesquisar(int id)
        {
            try
            {
                pessoaDao.pesquisar(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Alterar dados no Banco
        public void alterarMatricula(Pessoa pessoa)
        {
            try
            {
                pessoaDao.alterarMensalidade(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Salvar exercicio no Banco
        public void salvarExerciciosAluno(Exercicios exercicio)
        {
            try
            {
                pessoaDao.salvarExerciciosAluno(exercicio);
                MessageBox.Show("Dados Salvo com Sucesso!");
            }
            catch
            {
                MessageBox.Show("Ja existe um usuario cadastrado com este cpf");
            }
        }

        //Metodo para Alterar dados no Banco
        public void alterarExerciciosAcad(Exercicios exercicios)
        {
            try
            {
                pessoaDao.alterarExerciciosAcad(exercicios);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Deletar dados no Banco
        public void deletarExerciciosAcad(Exercicios exercicios)
        {
            try
            {
                pessoaDao.deletarExerciciosAcad(exercicios);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Pesquisar Exercicios Aluno
        public void pesquisarExercicioAluno(string cpf)
        {
            try
            {
                pessoaDao.pesquisarExercicioAluno(cpf);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Salvar no Banco
        public void salvarMedidasAluno(MedidasAluno medidas)
        {
            try
            {
                pessoaDao.salvarMedidasAluno(medidas);
                MessageBox.Show("Dados Salvo com Sucesso!");
            }
            catch
            {
                MessageBox.Show("Ja foram cadastrado medidas com este cpf");
            }
        }

        //Metodo para Pesquisar Exercicios Aluno
        public void pesquisarMedidasAluno(string cpf)
        {
            try
            {
                pessoaDao.pesquisarMedidasAluno(cpf);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Alterar dados no Banco
        public void alterarMedidasAluno(MedidasAluno medidas)
        {
            try
            {
                pessoaDao.alterarMedidasAluno(medidas);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //pesquisar se existe novas medidas cadastradas do Aluno
        public void existeNovasMedidasAluno(string cpf)
        {
            try
            {
                pessoaDao.existeNovasMedidasAluno(cpf);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //pesquisar se existe novas medidas cadastradas do Aluno
        public void existeExercicioAluno(string cpf)
        {
            try
            {
                pessoaDao.existeExercicioAluno(cpf);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Alterar Imagem do Aluno no Banco de dados
        public void AlterarImagemFuncionario(Pessoa pessoa)
        {
            try
            {
                pessoaDao.AlterarImagemAluno(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Pesquisar se existe usuario com CPF e Dica de senha no banco
        public void ValidarCPFMudaSenha(string cpf, string nascimento)
        {
            try
            {
                pessoaDao.ValidarCPFMudaSenha(cpf, nascimento);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Alterar Login e Senha no dados no Banco
        public void AlterarLogineSenha(Pessoa pessoa)
        {
            try
            {
                pessoaDao.AlterarLogineSenha(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Salvar no Banco
        public void salvarDicaseReceitas(Exercicios exercicios)
        {
            try
            {
                pessoaDao.salvarDicaseReceitas(exercicios);
                MessageBox.Show("Dica Salva com Sucesso!");
            }
            catch
            {
                MessageBox.Show("Ja existe uma dica semelhante cadastrada!");
            }
        }

        //Metodo para listar na Table
        public DataTable listarDicaseReceitas()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = pessoaDao.listarDicaseReceitas();

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Salvar no Banco
        public void salvarCalendario(Pessoa pessoa)
        {
            try
            {
                pessoaDao.salvarCalendario(pessoa);
            }
            catch
            {
                MessageBox.Show("Ja existe um usuario cadastrado com este cpf");
            }
        }

        //Metodo para Pesquisar dados no Banco para alterar dados
        public void buscarDadosUsuario(string cpf)
        {
            try
            {
                pessoaDao.buscarDadosUsuario(cpf);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Pesquisar dicas de exercicios e receitas
        public void buscarDicasExerciciosAluno()
        {
            try
            {
                pessoaDao.buscarDicasExerciciosAluno();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //alterar dados de cadastro do usuario
        public void alterarDadosCadastro(Pessoa pessoa)
        {
            try
            {
                pessoaDao.alterarDadosCadastro(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //metodo para Pesquisar se o aluno marcou presença
        public void verificarPresenca(string cpf)
        {
            try
            {
                pessoaDao.verificarPresenca(cpf);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
