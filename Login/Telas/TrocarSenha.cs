using Academia.Bll;
using Academia.Dao;
using Academia.model;
using Login.Ferramentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.Telas
{
    public partial class TrocarSenha : Form
    {
        FecharJanela janela = new FecharJanela();

        PessoaDAO pessoaDAO = new PessoaDAO();
        FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
        Pessoa pessoa = new Pessoa();

        Criptografia cript = new Criptografia();

        string senha_u;

        string cpf;
        string nascimento;
        string novo_user;
        string cpf_banco;
        string nasc_banco;
        string tipo;

        public TrocarSenha()
        {
            InitializeComponent();
        }

        //fechar a jenela
        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            janela.fecharJanela();
        }

        public void validarCPF()
        {
            //Validar CPF 
            string valor = maskValorCpf.Text;

            if (ValidaCPF.IsCpf(valor))
            {
                ValidarCPFMudaSenha(maskValorCpf.Text, maskNascimento.Text);

                btnPesquisar.Focus();
            }
            else
            {
                MessageBox.Show("CPF Inválido !");
                maskValorCpf.Focus();
                maskValorCpf.Text = "";
                maskValorCpf.Mask = "000,000,000-00";

            }
        }

        public void mascaraCPF()
        {
            maskValorCpf.Text = "";
            maskValorCpf.Mask = "000,000,000-00";
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            validarCPF();
        }

        //metodo para Pesquisar no banco de dados
        public void ValidarCPFMudaSenha(string c, string nasc)
        {
            cpf = maskValorCpf.Text;

            nascimento = maskNascimento.Text;


            Pessoa pessoa = new Pessoa();

            tipo = comboBox1.SelectedItem.ToString();

            if(tipo == "Aluno")
            {
                try
                {
                    pessoa = pessoaDAO.ValidarCPFMudaSenha(cpf, nascimento);
                }
                catch
                {

                }
            }

            if (tipo == "Professor" || tipo == "Secretaria")
            {
                try
                {
                    pessoa = funcionarioDAO.ValidarCPFMudaSenha(cpf, nascimento);
                }
                catch 
                {

                   
                }
            }


            if (pessoa.cpf == cpf && pessoa.nascimento == nascimento)
            {
                nasc_banco = pessoa.nascimento;
                cpf_banco = pessoa.cpf;
                panel1.Visible = true;

                novo_user = pessoa.login;
                txtLogin.Text = novo_user;


            }
            else
            {
                MessageBox.Show("Não Existe usuario cadastrado" +
                    " com este CPF!");
                maskValorCpf.Focus();
                mascaraCPF();
            }

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string pergunta = "Tem certeza que deseja alterar o login e Senha deste cadastro?";
            string titulo = "ALTERAR LOGIN E SENHA";

            if (MessageBox.Show(pergunta, titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Pessoa pessoa = new Pessoa();
                AlterarLogineSenha(pessoa);
            }
        }
        public void AlterarLogineSenha(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

            if (txtLogin.Text.Trim() == string.Empty && txtSenha.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Existem campos obrigatorios sem preenchimento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.BackColor = Color.Beige;
                txtSenha.BackColor = Color.Beige;
            }
            else
            {

                tipo = comboBox1.SelectedItem.ToString();

                if (tipo == "Aluno")
                {
                    pessoa.login = txtLogin.Text;
                    pessoa.senha = senha_u;
                    pessoa.cpf = maskValorCpf.Text;

                    pessoaBLL.AlterarLogineSenha(pessoa);

                    MessageBox.Show("Login e senha Alterados com Sucesso!");

                    txtLogin.BackColor = Color.White;
                    txtSenha.BackColor = Color.White;

                    maskValorCpf.Clear();
                    maskNascimento.Clear();
                    txtLogin.Clear();
                    txtSenha.Clear();
                    txtConf_senha.Clear();
                    comboBox1.Focus();
                    comboBox1.Text = "Escolha o tipo de Usuario :";
                    panel1.Visible = false;
                    txtConf_senha.Text = "Confirmar senha";
                    txtSenha.Text = "Senha";
                    txtLogin.Text = "Login";
                    txtSenha.PasswordChar = '\u0000';
                    txtConf_senha.PasswordChar = '\u0000';
                }

                if (tipo == "Professor" || tipo == "Secretaria")
                {
                    pessoa.login = txtLogin.Text;
                    pessoa.senha = senha_u;
                    pessoa.cpf = maskValorCpf.Text;

                    funcionarioBLL.AlterarLogineSenha(pessoa);

                    MessageBox.Show("Login e senha Alterados com Sucesso!");

                    txtLogin.BackColor = Color.White;
                    txtSenha.BackColor = Color.White;

                    maskValorCpf.Clear();
                    maskNascimento.Clear();
                    txtLogin.Clear();
                    txtSenha.Clear();
                    txtConf_senha.Clear();
                    comboBox1.Text = "Escolha o tipo de Usuario :";
                    panel1.Visible = false;
                    txtConf_senha.Text = "Confirmar senha";
                    txtSenha.Text = "Senha";
                    txtLogin.Text = "Login";
                    txtSenha.PasswordChar = '\u0000';
                    txtConf_senha.PasswordChar = '\u0000';
                }
                
 
            }
        }

        //metodo para Criptografar senhas
        public void CriptografarSenhas(string senha)
        {

            cript.setMD5Hash(txtSenha.Text);
            string senha_cript;
            senha_cript = cript.getMD5Hash();

            senha_u = senha_cript;
        }

        private void txtLogin_Enter(object sender, EventArgs e)
        {
            if (txtLogin.Text == "Login")
            {
                txtLogin.Clear();

            }

            txtLogin.ForeColor = Color.OrangeRed;
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            txtLogin.ForeColor = Color.Black;

            if (txtLogin.Text.Trim() == string.Empty && txtLogin.Text.Length <= 0)
            {
                txtLogin.Text = "";
                txtLogin.Text = "Login";
            }
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "Senha")
            {
                txtSenha.Clear();

            }

            txtSenha.ForeColor = Color.OrangeRed;

            if (txtSenha.Text.Trim() == string.Empty)
            {
                txtSenha.Text = "";
                txtSenha.PasswordChar = '*';
                txtSenha.MaxLength = 14;
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            txtSenha.ForeColor = Color.Black;

            if (txtSenha.Text.Trim() == string.Empty && txtSenha.Text.Length <= 0)
            {
                txtSenha.PasswordChar = '\u0000';
                txtSenha.Text = "Senha";

            }
        }

        private void txtConf_senha_Enter(object sender, EventArgs e)
        {
            if (txtConf_senha.Text == "Confirmar senha")
            {
                txtConf_senha.Clear();

            }

            txtConf_senha.ForeColor = Color.OrangeRed;

            if (txtConf_senha.Text.Trim() == string.Empty)
            {
                txtConf_senha.Text = "";
                txtConf_senha.PasswordChar = '*';
                txtConf_senha.MaxLength = 14;
            }
        }

        private void txtConf_Senha_Leave(object sender, EventArgs e)
        {
            txtConf_senha.ForeColor = Color.Black;

            //verificar se as senhas são iguais antes de salvar no banco
            if (txtSenha.Text.Trim() != string.Empty && txtSenha.Text != "Senha")
            {
                CriptografarSenhas(txtSenha.Text);
            }

            if (txtConf_senha.Text.Trim() == string.Empty && txtConf_senha.Text.Length <= 0)
            {
                txtConf_senha.PasswordChar = '\u0000';
                txtConf_senha.Text = "Confirmar senha";

            }
        }

        private void maskNascimento_Enter(object sender, EventArgs e)
        {
            maskNascimento.ForeColor = Color.OrangeRed;
        }

        private void maskNascimento_Leave(object sender, EventArgs e)
        {
            maskNascimento.ForeColor = Color.Black;

            //Obriga usuario digitar a data completa para proseguir
            if (maskNascimento.Text.Length < 10)
            {
                MessageBox.Show("Digite a data completa");
            }
 
        }

        private void maskValorCpf_Enter(object sender, EventArgs e)
        {
            maskValorCpf.ForeColor = Color.OrangeRed;
        }

        private void maskValorCpf_Leave(object sender, EventArgs e)
        {
            maskValorCpf.ForeColor = Color.Black;
        }
    }
}
