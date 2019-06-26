using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academia.Bll;
using Academia.model;
using Academia.Dao;
using MySql.Data.MySqlClient;
using Academia;
using Login.Telas;

namespace Login 
{
    public partial class Login : Form  
    {
        Conexao conexao = new Conexao();

        PessoaDAO pessoaDAO = new PessoaDAO();
        FuncionarioDAO funcionarioDAO = new FuncionarioDAO();

        Pessoa pessoa = new Pessoa();

        Criptografia cript = new Criptografia();

        string nome_user = "";

        string vencimento= "";

        string cpfAluno;
        string dataNasc;
        int sexo;
        double imc_user;
        double gordura_user;
        double peso_user;
        double bicepis;
        double anti_braco;
        double coxa;
        double panturilha;
        double peitoral;
        double cintura;
        string tipo_user;
        int tipo;
        int confef;

        string cpf_funcionario;

        byte[] imagem = null;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ActiveControl = comboBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //validar login e ir para pagina inicial
            loginValidar(txtLogin.Text, txtSenha.Text);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecuperarSenha senha = new RecuperarSenha();
            senha.Show();
            this.Hide();
        }

        //metodo para Pesquisar no banco de dados
        public void loginValidar(string login, string senha)
        {

            cript.setMD5Hash(txtSenha.Text);
            string senha_cript;
            senha_cript = cript.getMD5Hash();

            string login_u = txtLogin.Text;
            string senha_u = senha_cript;

            Pessoa pessoa = new Pessoa();

            if (comboBox1.Text == "Escolha o tipo de Usuario :" || txtLogin.Text == "Login" || txtSenha.Text == "Senha")
            {
                MessageBox.Show("Existem campos obrigatorios " +
                    "sem preenchimento!");
            }
            else
            {
                tipo_user = comboBox1.SelectedItem.ToString();

                if (tipo_user == "Aluno")
                {
                    try
                    {
                        pessoa = pessoaDAO.loginValidar(login_u, senha_u);
                    }
                    catch
                    {
                        MessageBox.Show("Senha ou Usuario invalidos!");
                    }
                }

                if (tipo_user == "Professor" || tipo_user == "Secretaria")
                {
                    try
                    {
                        pessoa = funcionarioDAO.loginValidar2(login_u, senha_u);
                    }
                    catch
                    {
                        MessageBox.Show("Senha ou Usuario invalidos!");
                    }
                }

                if (pessoa.login == login_u && pessoa.senha == senha_u)
                {

                    nome_user = pessoa.nome;
                    cpfAluno = pessoa.cpf;

                    vencimento = pessoa.vencimento_matr;
                    tipo = pessoa.tipo_usuario;
                    confef = pessoa.confef;
                    cpf_funcionario = pessoa.cpf;
                    dataNasc = pessoa.nascimento;
                    imc_user = pessoa.imc;
                    gordura_user = pessoa.indice_gordura;
                    peso_user = pessoa.peso;
                    bicepis = pessoa.bicepis;
                    anti_braco = pessoa.anti_braco;
                    coxa = pessoa.coxa;
                    panturilha = pessoa.panturilha;
                    peitoral = pessoa.peitoral;
                    cintura = pessoa.cintura;
                    tipo = pessoa.tipo_usuario;
                    sexo = pessoa.sexo;
                    byte[] imagem = pessoa.img;

                    if (tipo == 1)
                    {
                        PaginaInicial inicio = new PaginaInicial(nome_user, cpfAluno, vencimento, peso_user, gordura_user, imc_user, bicepis,
                        anti_braco, coxa, panturilha, peitoral, cintura, tipo, sexo, imagem, dataNasc);

                        inicio.Show();
                        this.Hide();
                    }

                    if (tipo == 2)
                    {
                        AreaProfessor professor = new AreaProfessor(nome_user, confef, imagem, cpf_funcionario, tipo);
                        professor.Show();
                        this.Hide();
                    }

                    if (tipo == 3)
                    {
                        AreaSecretaria secretaria = new AreaSecretaria(nome_user, imagem, cpf_funcionario, tipo);
                        secretaria.Show();
                        this.Hide();
                    }

                    //limpar campos apos logar
                    txtSenha.PasswordChar = '\u0000';
                    txtSenha.Text = "Senha";
                    txtLogin.Text = "";
                    txtLogin.Text = "Login";
                    comboBox1.Focus();
                    comboBox1.Text = "Escolha o tipo de Usuario :";

                }
                else
                {
                    //limpar campos apos erro ao logar
                    txtSenha.PasswordChar = '\u0000';
                    txtSenha.Text = "Senha";
                    txtLogin.Text = "";
                    txtLogin.Text = "Login";
                    comboBox1.Focus();
                    comboBox1.Text = "Escolha o tipo de Usuario :";
                }
            }

        }

        // Encerrar a aplicação
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Efeito de ativado textbox login
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtLogin.Text == "Login")
            {
                txtLogin.Clear();

            }

            txtLogin.ForeColor = Color.OrangeRed;
            panel1.BackColor = Color.OrangeRed;
        }

        // Efeito de desativado textbox login
        private void textBox1_Leave(object sender, EventArgs e)
        {
            txtLogin.ForeColor = Color.Black;
            panel1.BackColor = Color.Black;

            if (txtLogin.Text.Trim() == string.Empty && txtLogin.Text.Length <= 0)
            {
                txtLogin.Text = "";
                txtLogin.Text = "Login";
            }
        }

        // Efeito de ativado textbox senha
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(txtSenha.Text == "Senha")
            {
                txtSenha.Clear();
            }
                
            txtSenha.ForeColor = Color.OrangeRed;
            panel2.BackColor = Color.OrangeRed;

            if (txtSenha.Text.Trim() == string.Empty)
            {
                txtSenha.Text = "";
                txtSenha.PasswordChar = '*';
                txtSenha.MaxLength = 14;
            }
        }

        // Efeito de desativado textbox senha
        private void textBox2_Leave(object sender, EventArgs e)
        {
            txtSenha.ForeColor = Color.Black;
            panel2.BackColor = Color.Black;

            if (txtSenha.Text.Trim() == string.Empty && txtSenha.Text.Length <= 0)
            {
                txtSenha.PasswordChar = '\u0000';
                txtSenha.Text = "Senha";
            }
        }

        // Botao restaurar senha
        private void button3_Click(object sender, EventArgs e)
        {
            TrocarSenha trocarSenha = new TrocarSenha();
            trocarSenha.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TipoCadastro cadastro = new TipoCadastro();
            cadastro.Show();
            this.Hide();
        }

        private void btnRecuperarSenha_MouseEnter(object sender, EventArgs e)
        {
            btnRecuperarSenha.ForeColor = Color.OrangeRed;
        }

        private void btnRecuperarSenha_MouseLeave(object sender, EventArgs e)
        {
            btnRecuperarSenha.ForeColor = Color.Black;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = Color.OrangeRed;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.Black;
        }

        //bloquear letras nos textBox
        public void bloquearLetras(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //bloquearLetras(sender, e); 
        }

        //bloquear numeros nos textBox
        public void bloquearNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            //bloquearNumeros(sender, e);

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearNumeros(sender, e);
            bloquearLetras(sender, e);
        }

        private void linkLabel1_MouseEnter(object sender, EventArgs e)
        {
            linkLabel1.LinkColor = Color.Black;
        }

        private void linkLabel1_MouseLeave(object sender, EventArgs e)
        {
            linkLabel1.LinkColor = Color.OrangeRed;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_Sobre.Visible = true;
        }

        private void panel_Sobre_MouseLeave(object sender, EventArgs e)
        {
            panel_Sobre.Visible = false;
        }
    }
}
