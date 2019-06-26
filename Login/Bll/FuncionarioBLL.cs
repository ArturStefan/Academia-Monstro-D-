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
    public class FuncionarioBLL
    {
        FuncionarioDAO funcionarioDao = new FuncionarioDAO();

        //Metodo para Salvar no Banco
        public void salvar(Pessoa pessoa)
        {
            try
            {
                funcionarioDao.salvar(pessoa);
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

                dt = funcionarioDao.listar();

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Salvar no Banco
        public void salvarExercicio(Exercicios exercicios)
        {
            try
            {
                funcionarioDao.salvarExercicio(exercicios);
                MessageBox.Show("Dados Salvo com Sucesso!");
            }
            catch
            {
                MessageBox.Show("Ja existe um exercicio cadastro com este nome.");
            }
        }

        //Metodo para listar na Table os Exercicios
        public DataTable listarExercicio()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = funcionarioDao.listarExercicio();

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
                funcionarioDao.alterar(pessoa);
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
                funcionarioDao.deletar(pessoa);
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
                funcionarioDao.pesquisar(id);
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
                funcionarioDao.AlterarImagemFuncionario(pessoa);
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
                funcionarioDao.ValidarCPFMudaSenha(cpf, nascimento);
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
                funcionarioDao.AlterarLogineSenha(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para Pesquisar dados no Banco para alterar dados
        public void buscarDadosUsuario(string cpf)
        {
            try
            {
                funcionarioDao.buscarDadosUsuario(cpf);
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
                funcionarioDao.alterarDadosCadastro(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
