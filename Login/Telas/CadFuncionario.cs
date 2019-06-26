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
using Login.Ferramentas;

namespace Login
{
    public partial class CadFuncionario : Form
    {
        private readonly string caminho = Environment.CurrentDirectory + "\\..\\..\\Imagem_Modelo\\img _modelo.png";

        Idade idade = new Idade();

        Pessoa pessoa = new Pessoa();

        Criptografia cript = new Criptografia();

        DateTime data_hora;

        FecharJanela janela = new FecharJanela();

        ImagemBanco imagem = new ImagemBanco();

        byte[] imagem_byte = null;

        int tipos_usuario;
        int num_confef;

        string senha;
        string conf_senha;

        public CadFuncionario()
        {
            InitializeComponent();
        }

        private void CadFuncionario_Load(object sender, EventArgs e)
        {
            data_hora = DateTime.Now;
            maskDataCadastro.Text = data_hora.ToShortDateString();

            ActiveControl = comboBox1;

            txtNumero.Text = "Nº";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            data_hora = DateTime.Now;
            txtHoracadastro.Text = data_hora.ToLongTimeString();

        }

        //calcular a idade vinda da classe UMl Idade
        public void calcularIdade()
        {
            try
            {
                idade.setDataAtual(Convert.ToDateTime(maskDataCadastro.Text));
                idade.setDataNasc(Convert.ToDateTime(maskNascimento.Text));

                string idadeAluno;
                idadeAluno = idade.IdadeAluno();
                txtIdade.Text = idadeAluno;
                maskDataCadastro.Focus();
            }
            catch
            {
                maskValorCpf.Focus();
            }
        }

        public void ValidarSenha()
        {
            //enviar senhas para criptografar
            cript.setMD5Hash(txtSenha.Text);
            cript.setMD5Hash(txtConf_senha.Text);

            //senhas criptografadas para comparação
            senha = cript.getMD5Hash();
            conf_senha = cript.getMD5Hash();

            btnCadastrar.Focus();

            if (txtSenha.Text != txtConf_senha.Text)
            {
                MessageBox.Show("A senha esta Incorreta!" +
                    "Preencher novamente os campos para prosseguir.");
                txtSenha.Clear();
                txtConf_senha.Clear();
                txtConf_senha.PasswordChar = '\u0000';
                txtConf_senha.Text = "Confirmar senha";
                txtSenha.Focus();
            }
        }

        public void tipo_user()
        {
            if (comboBox1.Text == "Escolha o tipo de usuário")
            {
                MessageBox.Show("Escolha o tipo de usuário para prosseguir!");
                comboBox1.BackColor = Color.Beige;
                txtNumConfef.Visible = false;
            }

            if (comboBox1.Text == "Professor")
            {
                tipos_usuario = 2;

                comboBox1.BackColor = Color.White;
                txtNumConfef.Visible = true;
                panel14.Visible = true;
            }

            if (comboBox1.Text == "Secretária")
            {
                tipos_usuario = 3;
                comboBox1.BackColor = Color.White;
                txtNumConfef.Visible = false;
                panel14.Visible = false;
                txtNumConfef.Clear();
            }
            
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

        public void validarEmail()
        {
            string email = txtEmail.Text;

            if (email.IndexOf("@") == -1 || email.IndexOf(".com") == -1)
            {
                MessageBox.Show("E-mail é invalido! ");
                txtEmail.Text = "";
                txtEmail.Text = "Email";
                maskNascimento.Focus();
            }
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

        //buscar foto de usuario no computador
        public void buscarImagem()
        {
            imagem.setSelecionaImagem();

            string foto;

            foto = imagem.getSelecionaImagem();
            pictureBox1.ImageLocation = foto;

            //envia endereço da foto para converter para array de bytes[]
            imagem.ImagemPC(foto);

            //byte[] imagem_byte;
            imagem_byte = imagem.getImagemPC();
      
        }

        //Bloquear letras no textBox
        public void bloquearLetras(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Bloquear numeros no textBox
        public void bloquearNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearNumeros(sender, e);
         
        }

        private void txtSobrenome_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearNumeros(sender, e);           
        }

        private void txtCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearNumeros(sender, e);
        }

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearNumeros(sender, e);
        }

        private void maskNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);        
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void txtNumConfef_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            if (txtNome.Text == "Nome")
            {
                txtNome.Clear();

            }

            txtNome.ForeColor = Color.OrangeRed;
            panel1.BackColor = Color.OrangeRed;
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            txtNome.ForeColor = Color.Black;
            panel1.BackColor = Color.Black;

            if (txtNome.Text.Trim() == string.Empty && txtNome.Text.Length <= 0)
            {
                txtNome.Text = "";
                txtNome.Text = "Nome";
            }
        }

        private void txtSobrenome_Enter(object sender, EventArgs e)
        {
            if (txtSobrenome.Text == "Sobrenome")
            {
                txtSobrenome.Clear();

            }

            txtSobrenome.ForeColor = Color.OrangeRed;
            panel2.BackColor = Color.OrangeRed;
        }

        private void txtSobrenome_Leave(object sender, EventArgs e)
        {
            txtSobrenome.ForeColor = Color.Black;
            panel2.BackColor = Color.Black;

            if (txtSobrenome.Text.Trim() == string.Empty && txtSobrenome.Text.Length <= 0)
            {
                txtSobrenome.Text = "";
                txtSobrenome.Text = "Sobrenome";
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Clear();

            }

            txtEmail.ForeColor = Color.OrangeRed;
            panel3.BackColor = Color.OrangeRed;
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

            //validar e-mail
            validarEmail();
        }

        private void maskNascimento_Enter(object sender, EventArgs e)
        {
            maskNascimento.ForeColor = Color.OrangeRed;
            label6.ForeColor = Color.OrangeRed;
        }

        private void maskNascimento_Leave(object sender, EventArgs e)
        {
            
            maskNascimento.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;

            //Obriga usuario digitar a data completa para proseguir
            if (maskNascimento.Text.Length < 10)
            {
                MessageBox.Show("Digite a data completa");
                maskNascimento.Text = "";
                maskNascimento.Mask = "00/00/0000";
                maskValorCpf.Focus();
            }
            calcularIdade();
        }

        private void maskValorCpf_Enter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.OrangeRed;
            maskValorCpf.ForeColor = Color.OrangeRed;
        }

        private void maskValorCpf_Leave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Black;
            maskValorCpf.ForeColor = Color.Black;

            //Validar CPF e CNPJ
            validarCPF();
        }

        private void maskCep_Enter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.OrangeRed;
            maskCep.ForeColor = Color.OrangeRed;
        }

        private void maskCep_Leave(object sender, EventArgs e)
        {
            buscarCEP();
            label7.ForeColor = Color.Black;
            maskCep.ForeColor = Color.Black;
        }

        private void txtRua_Enter(object sender, EventArgs e)
        {
            if (txtRua.Text == "Endereço")
            {
                txtRua.Clear();

            }

            txtRua.ForeColor = Color.OrangeRed;
            panel4.BackColor = Color.OrangeRed;
        }

        private void txtRua_Leave(object sender, EventArgs e)
        {
            txtRua.ForeColor = Color.Black;
            panel4.BackColor = Color.Black;

            if (txtRua.Text.Trim() == string.Empty && txtRua.Text.Length <= 0)
            {
                txtRua.Text = "";
                txtRua.Text = "Endereço";
            }
        }


        private void txtNumero_Enter(object sender, EventArgs e)
        {
            if (txtNumero.Text == "Nº")
            {
                txtNumero.Clear();
            }

            txtNumero.ForeColor = Color.OrangeRed;
            panel11.BackColor = Color.OrangeRed;

            if (txtRua.Enabled && txtRua.Text == "Endereço")
            {
                txtRua.Focus();

                if (txtRua.Text == "")
                {
                    txtNumero.Text = "";
                    txtNumero.Text = "Nº";

                    txtNumero.ForeColor = Color.Black;
                    panel11.BackColor = Color.Black;
                }
            }
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            txtNumero.ForeColor = Color.Black;
            panel11.BackColor = Color.Black;

            if (txtNumero.Text.Trim() == string.Empty && txtNumero.Text.Length <= 0)
            {
                txtNumero.Text = "";
                txtNumero.Text = "Nº";
            }
        }

        private void txtBairro_Enter(object sender, EventArgs e)
        {
            if (txtBairro.Text == "Bairro")
            {
                txtBairro.Clear();

            }

            txtBairro.ForeColor = Color.OrangeRed;
            panel5.BackColor = Color.OrangeRed;
        }

        private void txtBairro_Leave(object sender, EventArgs e)
        {
            txtBairro.ForeColor = Color.Black;
            panel5.BackColor = Color.Black;

            if (txtBairro.Text.Trim() == string.Empty && txtBairro.Text.Length <= 0)
            {
                txtBairro.Text = "";
                txtBairro.Text = "Bairro";
            }
        }

        private void txtEstado_Enter(object sender, EventArgs e)
        {
            if (txtEstado.Text == "UF")
            {
                txtEstado.Clear();

            }

            txtEstado.ForeColor = Color.OrangeRed;
            panel10.BackColor = Color.OrangeRed;
        }

        private void txtEstado_Leave(object sender, EventArgs e)
        {
            txtEstado.ForeColor = Color.Black;
            panel10.BackColor = Color.Black;

            if (txtEstado.Text.Trim() == string.Empty && txtEstado.Text.Length <= 0)
            {
                txtEstado.Text = "";
                txtEstado.Text = "UF";
            }
        }

        private void txtCidade_Enter(object sender, EventArgs e)
        {
            if (txtCidade.Text == "Cidade")
            {
                txtCidade.Clear();

            }

            txtCidade.ForeColor = Color.OrangeRed;
            panel6.BackColor = Color.OrangeRed;
        }

        private void txtCidade_Leave(object sender, EventArgs e)
        {
            txtCidade.ForeColor = Color.Black;
            panel6.BackColor = Color.Black;

            if (txtCidade.Text.Trim() == string.Empty && txtCidade.Text.Length <= 0)
            {
                txtCidade.Text = "";
                txtCidade.Text = "Cidade";
            }
        }

        private void txtLogin_Enter(object sender, EventArgs e)
        {
            if (txtLogin.Text == "Login")
            {
                txtLogin.Clear();

            }

            txtLogin.ForeColor = Color.OrangeRed;
            panel7.BackColor = Color.OrangeRed;
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            txtLogin.ForeColor = Color.Black;
            panel7.BackColor = Color.Black;

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
            panel9.BackColor = Color.OrangeRed;

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
            panel9.BackColor = Color.Black;

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
            panel8.BackColor = Color.OrangeRed;

            if (txtConf_senha.Text.Trim() == string.Empty)
            {
                txtConf_senha.Text = "";
                txtConf_senha.PasswordChar = '*';
                txtConf_senha.MaxLength = 14;
            }
        }

        private void txtConf_senha_Leave(object sender, EventArgs e)
        {
            txtConf_senha.ForeColor = Color.Black;
            panel8.BackColor = Color.Black;

            //verificar se as senhas são iguais antes de salvar no banco
            if (txtSenha.Text.Trim() != string.Empty && txtSenha.Text != "Senha")
            {
                ValidarSenha();
            }

            if (txtConf_senha.Text.Trim() == string.Empty && txtConf_senha.Text.Length <= 0)
            {
                txtConf_senha.PasswordChar = '\u0000';
                txtConf_senha.Text = "Confirmar senha";
            }
        }

        private void txtNumConfef_Enter(object sender, EventArgs e)
        {
            if (txtNumConfef.Text == "N° Confef")
            {
                txtNumConfef.Clear();
            }

            txtNumConfef.ForeColor = Color.OrangeRed;
            panel14.BackColor = Color.OrangeRed;
        }

        private void txtNumConfef_Leave(object sender, EventArgs e)
        {
            if (txtNumConfef.Text.Trim() == string.Empty && txtNumConfef.Text.Length <= 0)
            {
                txtNumConfef.Text = "";
                txtNumConfef.Text = "N° Confef";
            }

            txtNumConfef.ForeColor = Color.Black;
            panel14.BackColor = Color.Black;
        }

        private void btn_Imagem_Click(object sender, EventArgs e)
        {
            buscarImagem();
        }

        //metodo para salvar no banco de dados
        private void salvar(Pessoa pessoa)
        {
            FuncionarioBLL pessoaBLL = new FuncionarioBLL();

            // faz verificação de erros e campos sem preenchimento antes de salvar no banco
            if (txtNome.Text == "Nome" || txtSobrenome.Text == "Sobrenome" || txtRua.Text == "Endereço" || txtBairro.Text == "Bairro" || txtCidade.Text == "Cidade" || txtEmail.Text == "Email"
                || txtEstado.Text == "UF" || maskNascimento.Text == "__/__/____" || maskValorCpf.Text.Trim() == "000,000,000-00" || maskCep.Text.Trim() == "00000-000" || txtSenha.Text == "Senha"
                || txtLogin.Text == "Login")
            {
                MessageBox.Show("Existem campos obrigatorios sem preenchimento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.BackColor = Color.Beige;
                txtSobrenome.BackColor = Color.Beige;
                txtEmail.BackColor = Color.Beige;
                maskValorCpf.BackColor = Color.Beige;
                maskNascimento.BackColor = Color.Beige;
                maskCep.BackColor = Color.Beige;
                txtRua.BackColor = Color.Beige;
                txtBairro.BackColor = Color.Beige;
                txtCidade.BackColor = Color.Beige;
                txtEstado.BackColor = Color.Beige;
                txtLogin.BackColor = Color.Beige;
                txtSenha.BackColor = Color.Beige;
                txtConf_senha.BackColor = Color.Beige;

            }
            else
            {

                //verifica tipo de usuario
                tipo_user();

                try
                {
                    // pega os valores dos textBox e envia para o banco de dados
                    pessoa.nome = txtNome.Text;
                    pessoa.sobrenome = txtSobrenome.Text;
                    pessoa.email = txtEmail.Text;
                    pessoa.cpf = maskValorCpf.Text;
                    pessoa.nascimento = maskNascimento.Text;
                    pessoa.idade = Convert.ToInt32(txtIdade.Text);
                    pessoa.cep = maskCep.Text;
                    pessoa.rua = txtRua.Text;
                    pessoa.numero = Convert.ToInt32(txtNumero.Text);
                    pessoa.bairro = txtBairro.Text;
                    pessoa.cidade = txtCidade.Text;
                    pessoa.estado = txtEstado.Text;
                    pessoa.login = txtLogin.Text;
                    pessoa.senha = senha;
                    pessoa.conf_senha = conf_senha;
                    pessoa.datacadastro = maskDataCadastro.Text;

                    if (comboBox1.SelectedItem.ToString() == "Professor")
                    {
                        pessoa.tipo_usuario = tipos_usuario;
                        num_confef = Convert.ToInt32(txtNumConfef.Text);
                        pessoa.confef = num_confef;
                    }
                    if (comboBox1.SelectedItem.ToString() == "Secretária")
                    {
                        pessoa.tipo_usuario = tipos_usuario;
                    }

                    if (imagem_byte != null)
                    {
                        pessoa.img = imagem_byte;
                    }
                    else
                    {
                        try
                        {

                            //envia endereço da foto para converter para array de bytes[]
                            imagem.ImagemPC(caminho);

                            //byte[] imagem_byte;
                            imagem_byte = imagem.getImagemPC();

                            pessoa.img = imagem_byte;
                        }
                        catch
                        {
                            MessageBox.Show("Não foi possivel encontrar a imagem!" +
                                "Selecione manualmente a image desejada!");
                        }

                    }

                    pessoaBLL.salvar(pessoa);

                    this.Dispose();
                    janela.fecharJanela();
                }
                catch (Exception)
                {

                    MessageBox.Show("Preencha todos os campos obrigatorios");
                }
            }
        }

        //Faz aparecer o campo Numero do Confef se for tipo professor
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            tipo_user();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            janela.fecharJanela();
        }

        //Botão de salvar no banco de dados
        private void button1_Click(object sender, EventArgs e)
        {
            //salvar no banco de dados
            Pessoa pessoa = new Pessoa();
            salvar(pessoa);
        }

    }
}
