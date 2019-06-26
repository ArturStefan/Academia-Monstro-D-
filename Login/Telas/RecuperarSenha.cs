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

namespace Login
{
    public partial class RecuperarSenha : Form
    {
        PessoaDAO pessoaDAO = new PessoaDAO();

        FuncionarioDAO funcionarioDAO = new FuncionarioDAO();

        FecharJanela janela = new FecharJanela();

        Criptografia cript = new Criptografia();

        Idade idade = new Idade();

        DateTime data_hora;

        string cpf_user;
        int tipo_user;

        string nome;
        string sobrenome;
        string email;
        string cep;
        string nascimento;
        int idade_user;
        string rua;
        int numero;
        string bairro;
        string cidade;
        string Estado;


        public RecuperarSenha()
        {
            InitializeComponent();
        }

        public RecuperarSenha(string cpf, int tipo)
        {
            InitializeComponent();

            cpf_user = cpf;
            maskValorCpf.Text = cpf_user;

            tipo_user = tipo;
        }

        private void RecuperarSenha_Load(object sender, EventArgs e)
        {
           // ActiveControl = maskValorCpf;

            data_hora = DateTime.Now;
            maskDataAtual.Text = data_hora.ToShortDateString();

            buscarDadosUsuario(maskValorCpf.Text);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtNome.Text == "Nome")
            {
                txtNome.Clear();
            }

            txtNome.ForeColor = Color.OrangeRed;
            panel1.BackColor = Color.OrangeRed;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(txtNome.Text == "")
            {
                txtNome.Text = "Nome";
            }

            txtNome.ForeColor = Color.Black;
            panel1.BackColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(txtSobrenome.Text == "Sobrenome")
            {
                txtSobrenome.Clear();
            }

            txtSobrenome.ForeColor = Color.OrangeRed;
            panel3.BackColor = Color.OrangeRed;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if(txtSobrenome.Text == "")
            {
                txtSobrenome.Text = "Sobrenome";
            }

            txtSobrenome.ForeColor = Color.Black;
            panel3.BackColor = Color.Black;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if(txtEmail.Text == "Email")
            {
                txtEmail.Clear();
            }

            txtEmail.ForeColor = Color.OrangeRed;
            panel2.BackColor = Color.OrangeRed;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            txtEmail.ForeColor = Color.Black;
            panel3.BackColor = Color.Black;

            if (txtEmail.Text.Trim() == string.Empty && txtEmail.Text.Length <= 0)
            {
                txtEmail.Text = "";
                txtEmail.Text = "Email";
            }

            validarEmail();
        }

        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            maskNascimento.ForeColor = Color.OrangeRed;
            label6.ForeColor = Color.OrangeRed;
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            maskNascimento.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;

            //Obriga usuario digitar a data completa para proseguir
            if (maskNascimento.Text.Length < 10)
            {
                MessageBox.Show("Digite a data completa");
                maskValorCpf.Focus();

            }

            // Verifica se o aluno tem no minimo 20 anos 
            if (maskNascimento.Text.Length == 10)
            {
                calcularIdade();

                if (Convert.ToInt32(txtIdade.Text) < 20)
                {

                    MessageBox.Show("Você tem apenas " + txtIdade.Text + " de idade. \n\n" +
                        "Precisa ter pelo menos 20 anos para realizar o cadastro!");

                    maskNascimento.Clear();
                    maskValorCpf.Focus();

                    txtIdade.Text = "";
                    txtIdade.Text = "Nº";

                }
            }
        }

        //validar email
        public void validarEmail()
        {
            string email = txtEmail.Text;

            if (email.IndexOf("@") == -1 || email.IndexOf(".com") == -1)
            {
                MessageBox.Show("E-mail invalido! \n\n" +
                   "Verifique se digitou '@' e '.com'");

                txtEmail.Text = "";
                txtEmail.Text = "Email";
                maskNascimento.Focus();
            }
        }

        //calcular a idade vinda da classe UMl Idade
        public void calcularIdade()
        {
            try
            {
                idade.setDataAtual(Convert.ToDateTime(maskDataAtual.Text));
                idade.setDataNasc(Convert.ToDateTime(maskNascimento.Text));

                string idadeAluno;
                idadeAluno = idade.IdadeAluno();
                txtIdade.Text = idadeAluno;
            }
            catch
            {
                maskValorCpf.Focus();
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            txtIdade.ForeColor = Color.OrangeRed;
            label14.ForeColor = Color.OrangeRed;
            panel13.BackColor = Color.OrangeRed;
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            txtIdade.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;
            panel13.BackColor = Color.Black;
        }

        private void maskValorCpfCnpj_Enter(object sender, EventArgs e)
        {
            maskValorCpf.ForeColor = Color.OrangeRed;
            label8.ForeColor = Color.OrangeRed;
        }

        private void maskValorCpfCnpj_Leave(object sender, EventArgs e)
        {
            maskValorCpf.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;

            validarCPF();
        }

        private void maskedTextBox2_Enter(object sender, EventArgs e)
        {
            maskCep.ForeColor = Color.OrangeRed;
            label7.ForeColor = Color.OrangeRed;
        }

        private void maskedTextBox2_Leave(object sender, EventArgs e)
        {
            buscarCEP();
            label7.ForeColor = Color.Black;
            maskCep.ForeColor = Color.Black;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if(txtRua.Text == "Endereço")
            {
                txtRua.Clear();
            }

            txtRua.ForeColor = Color.OrangeRed;
            panel5.BackColor = Color.OrangeRed;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (txtRua.Text == "")
            {
                txtRua.Text = "Endereço";
            }

            txtRua.ForeColor = Color.Black;
            panel5.BackColor = Color.Black;
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if(txtCidade.Text == "Cidade")
            {
                txtCidade.Clear();
            }

            txtCidade.ForeColor = Color.OrangeRed;
            panel4.BackColor = Color.OrangeRed;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (txtCidade.Text == "")
            {
                txtCidade.Text = "Cidade";
            }

            txtCidade.ForeColor = Color.Black;
            panel4.BackColor = Color.Black;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if(txtBairro.Text == "Bairro")
            {
                txtBairro.Clear();
            }

            txtBairro.ForeColor = Color.OrangeRed;
            panel6.BackColor = Color.OrangeRed;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (txtBairro.Text == "")
            {
                txtBairro.Text = "Bairro";
            }

            txtBairro.ForeColor = Color.Black;
            panel6.BackColor = Color.Black;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (txtNumero.Text == "N°")
            {
                txtNumero.Clear();
            }

            txtNumero.ForeColor = Color.OrangeRed;
            panel11.BackColor = Color.OrangeRed;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (txtNumero.Text == "")
            {
                txtNumero.Text = "N°";
            }

            txtNumero.ForeColor = Color.Black;
            panel11.BackColor = Color.Black;
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (txtEstado.Text == "UF") {
                txtEstado.Clear();
            }

            txtEstado.ForeColor = Color.OrangeRed;
            panel10.BackColor = Color.OrangeRed;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (txtEstado.Text == "")
            {
                txtEstado.Text = "UF";
            }

            txtEstado.ForeColor = Color.Black;
            panel10.BackColor = Color.Black;
        }

        //busca automatica do endereço por CEP
        public void buscarCEP()
        {
            try
            {
                string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", maskCep.Text);

                DataSet ds = new DataSet();

                ds.ReadXml(xml);

                if (ds.Tables[0].Rows[0][0].ToString().Equals("0"))
                {
                    throw new Exception();
                }
                else
                {
                    txtRua.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtBairro.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtCidade.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtEstado.Text = ds.Tables[0].Rows[0][2].ToString();

                    txtNumero.Focus();
                }
            }
            catch (Exception Error)
            {
                MessageBox.Show("CEP invalido, inesistente ou não consta na lista de endereços! \n\n" +
                    "Por favor digitar manualmente o endereço.", "CEP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtRua.Enabled = true;
                txtBairro.Enabled = true;
                txtCidade.Enabled = true;
                txtEstado.Enabled = true;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //botão de salvar as alterações de cadastro
        private void btnSalvarAlteracao_Click(object sender, EventArgs e)
        {
            string pergunta = "Tem certeza que deseja alterar " +
                "os dados do cadastro?";
            string titulo = "ALTERAR CADASTRO";

            if (MessageBox.Show(pergunta, titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Pessoa pessoa = new Pessoa();
                alterarDadosCadastro(pessoa);
            }
        }

        //buscar os dados no banco de dados e jogarnos campos
        public void buscarDadosUsuario(string cpf)
        {
            Pessoa pessoa = new Pessoa();

            cpf_user = maskValorCpf.Text;

            if (tipo_user == 1)
            {
                pessoa = pessoaDAO.buscarDadosUsuario(cpf_user);
            }

            if (tipo_user == 2 || tipo_user == 3)
            {
                pessoa = funcionarioDAO.buscarDadosUsuario(cpf_user);
            }


            if (pessoa.cpf == cpf_user)
            {

                nome = pessoa.nome;
                txtNome.Text = nome;

                sobrenome = pessoa.sobrenome;
                txtSobrenome.Text = sobrenome;

                email = pessoa.email;
                txtEmail.Text = email;

                nascimento = pessoa.nascimento;
                maskNascimento.Text = nascimento;

                idade_user = pessoa.idade;
                txtIdade.Text = idade_user.ToString();

                cpf_user = cpf;
                maskValorCpf.Text = cpf_user;

                cep = pessoa.cep;
                maskCep.Text = cep;

                rua = pessoa.rua;
                txtRua.Text = rua;

                numero = pessoa.numero;
                txtNumero.Text = numero.ToString();

                bairro = pessoa.bairro;
                txtBairro.Text = bairro;

                cidade = pessoa.cidade;
                txtCidade.Text = cidade;

                Estado = pessoa.estado;
                txtEstado.Text = Estado;


            }
            else
            {
                MessageBox.Show("Não Existe usuario cadastrado" +
                    " com este CPF!");
                maskValorCpf.Focus();
                mascaraCPF();
            }
        }

        public void mascaraCPF()
        {
            maskValorCpf.Text = "";
            maskValorCpf.Mask = "000,000,000-00";
        }

        public void validarCPF()
        {
            //Validar CPF 
            string valor = maskValorCpf.Text;

            if (ValidaCPF.IsCpf(valor))
            {
                maskCep.Focus();
            }
            else
            {
                MessageBox.Show("CPF Inválido !");
                maskCep.Focus();
                maskValorCpf.Text = "";
                maskValorCpf.Mask = "000,000,000-00";

            }
        }

        //alterar dados de cadastro do usuario
        private void alterarDadosCadastro(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

            if (txtNome.Text.Trim() == string.Empty || txtSobrenome.Text.Trim() == string.Empty || txtEmail.Text.Trim() == string.Empty ||
                txtRua.Text.Trim() == string.Empty || txtNumero.Text.Trim() == string.Empty || txtBairro.Text.Trim() == string.Empty ||
                txtCidade.Text.Trim() == string.Empty || txtEstado.Text.Trim() == string.Empty || maskNascimento.Text == "__/__/____" || 
                maskValorCpf.Text.Trim() == "000,000,000-00" || maskCep.Text.Trim() == "00000-000")
            {
                MessageBox.Show("Existem campos obrigatorios sem preenchimento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.BackColor = Color.Beige;
                txtSobrenome.BackColor = Color.Beige;
                txtEmail.BackColor = Color.Beige;
                txtRua.BackColor = Color.Beige;
                txtNumero.BackColor = Color.Beige;
                txtBairro.BackColor = Color.Beige;
                txtCidade.BackColor = Color.Beige;
                txtEstado.BackColor = Color.Beige;
                maskCep.BackColor = Color.Beige;
                maskNascimento.BackColor = Color.Beige;
                maskValorCpf.BackColor = Color.Beige;
            }
            else
            {
                pessoa.cpf = maskValorCpf.Text;
                pessoa.nome = txtNome.Text;
                pessoa.sobrenome = txtSobrenome.Text;
                pessoa.email = txtEmail.Text;
                pessoa.nascimento = maskNascimento.Text;
                pessoa.idade = Convert.ToInt32(txtIdade.Text);
                pessoa.cep = maskCep.Text;
                pessoa.rua = txtRua.Text;
                pessoa.numero = Convert.ToInt32(txtNumero.Text);
                pessoa.bairro = txtBairro.Text;
                pessoa.cidade = txtCidade.Text;
                pessoa.estado = txtEstado.Text;
                

                if (tipo_user == 1)
                {
                   pessoaBLL.alterarDadosCadastro(pessoa);
                }

                if (tipo_user == 2 || tipo_user == 3)
                {
                   funcionarioBLL.alterarDadosCadastro(pessoa);
                }


                MessageBox.Show("Cadastro Alterado com Sucesso!");

                txtNome.BackColor = Color.White;
                txtSobrenome.BackColor = Color.White;
                txtEmail.BackColor = Color.White;
                txtRua.BackColor = Color.White;
                txtNumero.BackColor = Color.White;
                txtBairro.BackColor = Color.White;
                txtCidade.BackColor = Color.White;
                txtEstado.BackColor = Color.White;
                maskCep.BackColor = Color.White;
                maskNascimento.BackColor = Color.White;
                maskValorCpf.BackColor = Color.White;


            }
        }
    }
}
