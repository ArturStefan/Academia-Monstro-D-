using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.Common;
using Academia.Bll;
using Academia.model;
using Academia.Dao;
using MySql.Data.MySqlClient;
using Login.Ferramentas;


namespace Login
{
    public partial class CadAluno : Form
    {
        private readonly string caminho = Environment.CurrentDirectory + "\\..\\..\\Imagem_Modelo\\img _modelo.png";
        //String path = new File("../src/main/webapp/resources/logo.png").getCanonicalPath();

        Idade idade = new Idade();

        IndiceGordura indice = new IndiceGordura();

        Pessoa pessoa = new Pessoa();

        Criptografia cript = new Criptografia();

        DateTime data_hora;

        FecharJanela janela = new FecharJanela();

        ImagemBanco imagem = new ImagemBanco();

        byte[] imagem_byte = null;

        int tipos_usuario;

        string senha;
        string conf_senha;

        //calculo indice gordura
        int sexo;

        int sexo_aluno;

        public CadAluno()
        {
            InitializeComponent();
        }
      

        //Botão para salvar a pessoa no banco de dados
        private void button1_Click(object sender, EventArgs e)
        {
            //salvar no banco de dados
            Pessoa pessoa = new Pessoa();
            salvar(pessoa);  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnCadastrar;          
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
            catch(Exception Error)
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
                MessageBox.Show("E-mail invalido!");

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

        public void mascaraCPF()
        {
            maskValorCpf.Text = "";
            maskValorCpf.Mask = "000,000,000-00";
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

        public void tipo_user()
        {
            if (comboBox1.Text == "Aluno")
            {
                tipos_usuario = 1;
                comboBox1.BackColor = Color.White;
            }
            if(comboBox1.Text == "Escolha o tipo de usuário")
            {
                MessageBox.Show("Escolha um tipo de usuario para prosseguir!");
                comboBox1.BackColor = Color.Beige;
            }
        }

        private void Cadastrar_Load(object sender, EventArgs e)
        {

            ActiveControl = comboBox1;
            txtNome.Focus();

            mascaraCPF();

            txtSenha.Text = "Senha";
            txtConf_senha.Text = "Confirmar senha";
            txtNumero.Text = "Nº";

            radioHomem.ForeColor = Color.OrangeRed;
            radioMulher.ForeColor = Color.Black;

            data_hora = DateTime.Now;
            maskDataCadastro.Text = data_hora.ToShortDateString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            data_hora = DateTime.Now;
            txtHoracadastro.Text = data_hora.ToLongTimeString();
        }

        //bloquear letras nos textBox
        public void BloquearLetras(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearLetras(sender, e);
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearNumeros(sender, e);
        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearNumeros(sender, e); ;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearNumeros(sender, e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearNumeros(sender, e);
        }

        private void maskAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearNumeros(sender, e);
        }

        private void maskPeso_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            bloquearNumeros(sender, e);
        }

        private void maskedTextBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            bloquearNumeros(sender, e);
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearLetras(sender, e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearNumeros(sender, e);
        }


        private void maskBicepis_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearLetras(sender, e);
        }

        private void maskCoxa_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearLetras(sender, e);
        }

        private void maskPeitoral_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearLetras(sender, e);
        }

        private void maskAnti_Braco_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearLetras(sender, e);
        }

        private void maskPanturilha_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearLetras(sender, e);
        }

        private void maskCintura_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearLetras(sender, e);
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

        /////////////// APAGAR ?????????????
        private void maskedTextBox4_Leave(object sender, EventArgs e)
        {
            try
            {
                idade.setDataAtual(Convert.ToDateTime(maskDataCadastro.Text));
                idade.setDataMens(Convert.ToDateTime(maskTempoMensalidade.Text));

                string DiasMensalidade;
                DiasMensalidade = idade.Mensalidade();
   
            }
            catch
            {
                MessageBox.Show("");
            }
        }

        //retorna o resultado do calculo do indice de gordura da Classe
        public void indiceGordura()
        {
            try
            {
                indice.setPeso((Convert.ToDouble(maskPeso.Text)) / 100);
                indice.setAltura((Convert.ToDouble(maskAltura.Text)) / 100);
                indice.setIdade(Convert.ToInt32(txtIdade.Text));

                if (radioHomem.Checked)
                {
                    sexo = 1;
                    indice.setSexo(sexo);
                }
                if (radioMulher.Checked)
                {
                    sexo = 0;
                    indice.setSexo(sexo);
                }

                double percent;
                percent = indice.Indice();
                txtIndiceGordura.Text = Convert.ToString(Math.Round(percent, 2));

                string situacao;
                situacao = indice.SituacaoAluno();
                txtSituacao.Text = situacao;

                double imc;
                imc = indice.IMC();
                txtImc.Text = Convert.ToString(Math.Round(imc, 2));

                maskPeso.BackColor = Color.White;
                maskAltura.BackColor = Color.White;
                maskNascimento.BackColor = Color.White;
            }
            catch (Exception)
            {

                MessageBox.Show("Existem campos obrigatorios sem preenchimento");
                maskPeso.BackColor = Color.Beige;
                maskAltura.BackColor = Color.Beige;
                maskNascimento.BackColor = Color.Beige;
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

            if (txtSenha.Text != txtConf_senha.Text)
            {
                MessageBox.Show("A senha esta Incorreta! \n\n" +
                    "Preencher novamente os campos para prosseguir.");
                txtSenha.Clear();
                txtConf_senha.Clear();
                txtConf_senha.PasswordChar = '\u0000';
                txtConf_senha.Text = "Confirmar senha";
                txtSenha.Focus();
            }
        }

        //metodo para salvar no banco de dados
        private void salvar(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            // faz verificação de erros e campos sem preenchimento antes de salvar no banco
            if (txtNome.Text == "Nome" || txtSobrenome.Text == "Sobrenome" || txtRua.Text == "Endereço" || txtBairro.Text == "Bairro" || txtCidade.Text == "Cidade" || txtEmail.Text == "Email"
                || txtEstado.Text == "UF" || maskNascimento.Text == "__/__/____" || maskValorCpf.Text.Trim() == "000,000,000-00" || maskCep.Text.Trim() == "00000-000" || txtSenha.Text == "Senha"
                || txtLogin.Text == "Login" || maskTempoMensalidade.Text == "__/__/____" || maskPeso.Text == "00,00" || maskAltura.Text == "0,00" || maskBicepis.Text == "0,00" || maskAnte_Braco.Text == "0,00"
                || maskCoxa.Text == "0,00" || maskPanturilha.Text == "0,00" || maskPeitoral.Text == "0,00" || maskCintura.Text == "0,00")
            {
                MessageBox.Show("Existem campos obrigatorios sem preenchimento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.BackColor = Color.Beige;
                txtSobrenome.BackColor = Color.Beige;
                txtEmail.BackColor = Color.Beige;
                maskValorCpf.BackColor = Color.Beige;
                maskNascimento.BackColor = Color.Beige;
                maskTempoMensalidade.BackColor = Color.Beige;
                maskCep.BackColor = Color.Beige;
                txtRua.BackColor = Color.Beige;
                txtBairro.BackColor = Color.Beige;
                txtCidade.BackColor = Color.Beige;
                txtEstado.BackColor = Color.Beige;
                txtLogin.BackColor = Color.Beige;
                txtSenha.BackColor = Color.Beige;
                txtConf_senha.BackColor = Color.Beige;
                maskPeso.BackColor = Color.Beige;
                maskAltura.BackColor = Color.Beige;
                maskBicepis.BackColor = Color.Beige;
                maskAnte_Braco.BackColor = Color.Beige;
                maskCoxa.BackColor = Color.Beige;
                maskPanturilha.BackColor = Color.Beige;
                maskPeitoral.BackColor = Color.Beige;
                maskCintura.BackColor = Color.Beige;

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
                    pessoa.peso = Convert.ToDouble(maskPeso.Text) / 100;
                    pessoa.altura = Convert.ToDouble(maskAltura.Text) / 100;

                    if (radioHomem.Checked)
                    {
                        //sexo_aluno = indice.getSexo();
                        sexo_aluno = 1;
                        pessoa.sexo = Convert.ToInt32(sexo_aluno);
                    }
                    if (radioMulher.Checked)
                    {
                        //sexo_aluno = indice.getSexo();
                        sexo_aluno = 0;
                        pessoa.sexo = Convert.ToInt32(sexo_aluno);
                    }

                    pessoa.imc = Convert.ToDouble(txtImc.Text)/ 100;
                    pessoa.indice_gordura = Convert.ToDouble(txtIndiceGordura.Text) / 100;
                    pessoa.situacao = txtSituacao.Text;
                    pessoa.datacadastro = maskDataCadastro.Text;
                    pessoa.vencimento_matr = maskTempoMensalidade.Text;

                    if (comboBox1.SelectedItem.ToString() == "Aluno")
                    {
                        pessoa.tipo_usuario = tipos_usuario;
                    }


                    pessoa.bicepis = Convert.ToDouble(maskBicepis.Text) / 100;
                    pessoa.anti_braco = Convert.ToDouble(maskAnte_Braco.Text) / 100;
                    pessoa.coxa = Convert.ToDouble(maskCoxa.Text) / 100;
                    pessoa.panturilha = Convert.ToDouble(maskPanturilha.Text) / 100;
                    pessoa.peitoral = Convert.ToDouble(maskPeitoral.Text) / 100;  
                    pessoa.cintura = Convert.ToDouble(maskCintura.Text) / 100;

                    if(imagem_byte != null)
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

                    salvarCalendario(pessoa);

                    this.Dispose();
                    janela.fecharJanela();
                }
                catch (Exception)
                {

                    MessageBox.Show("Preencha todos os campos obrigatorios");
                }
            }
        }

        // Encerrar e voltar ao login
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            janela.fecharJanela();
        }

        // Efeitos da interface
        private void txtNome_Enter(object sender, EventArgs e)
        {
            if(txtNome.Text == "Nome")
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

            if(txtNome.Text.Trim() == string.Empty && txtNome.Text.Length <= 0 )
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
            if(txtEmail.Text == "Email")
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

            validarEmail();
        }

        private void txtRua_Enter(object sender, EventArgs e)
        {
            if(txtRua.Text == "Endereço")
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

                if(txtRua.Text == "")
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

        private void maskValorCpf_Enter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.OrangeRed;
            maskValorCpf.ForeColor = Color.OrangeRed;
        }

        private void maskValorCpf_Leave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Black;
            maskValorCpf.ForeColor = Color.Black;

            validarCPF();
        }
  
        private void maskCep_Enter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.OrangeRed;
            maskCep.ForeColor = Color.OrangeRed;
        }

        //busca endereço por CEP ao mudar de textbox
        private void maskedTextBox2_Leave(object sender, EventArgs e)
        {
            buscarCEP();
            label7.ForeColor = Color.Black;
            maskCep.ForeColor = Color.Black;
        }

        private void txtLogin_Enter(object sender, EventArgs e)
        {
            if(txtLogin.Text == "Login")
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
            if(txtSenha.Text.Trim() != string.Empty && txtSenha.Text != "Senha")
            {
                ValidarSenha();
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
            label6.ForeColor = Color.OrangeRed;
        }

        //calcula idade ao mudar de textbox
        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            
            maskNascimento.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;

            //Obriga usuario digitar a data completa para proseguir
            if (maskNascimento.Text.Length < 10 )
            {
                MessageBox.Show("Digite a data completa");
                maskNascimento.Text = "";
                maskNascimento.Mask = "00/00/0000";
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

        private void maskPeso_Leave_1(object sender, EventArgs e)
        {
            maskPeso.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;

            if (maskPeso.Text.Length < 4)
            {
                MessageBox.Show("Digite o peso com 4 digitos");
                maskPeso.Clear();
                maskPeso.Mask = "00,00";
                maskAltura.Focus();
            }
        }

        private void maskPeso_Enter_1(object sender, EventArgs e)
        {
            maskPeso.ForeColor = Color.OrangeRed;
            label1.ForeColor = Color.OrangeRed;
        }

        private void maskAltura_Leave_1(object sender, EventArgs e)
        {
            maskAltura.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;

            if (maskAltura.Text.Length < 4)
            {
                MessageBox.Show("Digite o peso com 3 digitos");
                maskAltura.Clear();
                maskAltura.Mask = "0,00";
                btn_Calc_Indice.Focus();
            }
        }

        private void maskAltura_Enter_1(object sender, EventArgs e)
        {
            maskAltura.ForeColor = Color.OrangeRed;
            label2.ForeColor = Color.OrangeRed;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buscarImagem();
        }

        private void btn_Calc_Indice_Click(object sender, EventArgs e)
        {
            indiceGordura();
        }

        private void radioHomem_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioHomem.Checked)
            {
                radioHomem.ForeColor = Color.OrangeRed;
                radioMulher.ForeColor = Color.Black;
            }
        }

        private void radioMulher_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioMulher.Checked)
            {
                radioHomem.ForeColor = Color.Black;
                radioMulher.ForeColor = Color.OrangeRed;
            }
        }

        private void maskTempoMensalidade_Leave(object sender, EventArgs e)
        {
            maskTempoMensalidade.ForeColor = Color.Black;
            label18.ForeColor = Color.Black;

            if (maskTempoMensalidade.Text.Length < 10)
            {
                MessageBox.Show("Digite a data da mensalidade completa");
                maskPeso.Focus();
                maskTempoMensalidade.Clear();
                maskTempoMensalidade.Text = "__/__/____";
            }

            //verifica se a data foi preenchida de forma completa
            if(maskTempoMensalidade.Text.Length > 2 && maskTempoMensalidade.Text.Length == 10)
            {
                idade.setDataAtual(Convert.ToDateTime(maskDataCadastro.Text));
                idade.setDataVal(Convert.ToDateTime(maskTempoMensalidade.Text));
            }
 
            int data = Convert.ToInt32(idade.VerificarAnoValidoMensalidade());

            if (data < 0)
            {
                MessageBox.Show("Data de matricula invalida! \n\n" +
                    "A data precisa ser superior a data atual!");

                maskPeso.Focus();
                maskTempoMensalidade.Clear();
                maskTempoMensalidade.Text = "__/__/____";
            }
        }

        private void maskTempoMensalidade_Enter(object sender, EventArgs e)
        {
            maskTempoMensalidade.ForeColor = Color.OrangeRed;
            label18.ForeColor = Color.OrangeRed;
        }

        private void maskBicepis_Enter(object sender, EventArgs e)
        {
            maskBicepis.ForeColor = Color.OrangeRed;
            label3.ForeColor = Color.OrangeRed;
            panel14.BackColor = Color.OrangeRed;
        }

        private void maskBicepis_Leave(object sender, EventArgs e)
        {
            maskBicepis.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            panel14.BackColor = Color.Black;

            if (maskBicepis.Text.Length < 4)
            {
                MessageBox.Show("Digite a medida com 3 digitos");
                maskBicepis.Clear();
                maskBicepis.Mask = "0,00";
                maskCoxa.Focus();
            }
        }

        private void maskCoxa_Enter(object sender, EventArgs e)
        {
            maskCoxa.ForeColor = Color.OrangeRed;
            label4.ForeColor = Color.OrangeRed;
            panel18.BackColor = Color.OrangeRed;
        }

        private void maskCoxa_Leave(object sender, EventArgs e)
        {
            maskCoxa.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            panel18.BackColor = Color.Black;

            if (maskCoxa.Text.Length < 4)
            {
                MessageBox.Show("Digite a medida com 3 digitos");
                maskCoxa.Clear();
                maskCoxa.Mask = "0,00";
                maskPeitoral.Focus();
            }
        }

        private void maskPeitoral_Enter(object sender, EventArgs e)
        {
            maskPeitoral.ForeColor = Color.OrangeRed;
            label5.ForeColor = Color.OrangeRed;
            panel19.BackColor = Color.OrangeRed;
        }

        private void maskPeitoral_Leave(object sender, EventArgs e)
        {
            maskPeitoral.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            panel19.BackColor = Color.Black;

            if (maskPeitoral.Text.Length < 4)
            {
                MessageBox.Show("Digite a medida com 3 digitos");
                maskPeitoral.Focus();
            }
        }

        private void maskAnti_Braco_Enter(object sender, EventArgs e)
        {
            maskAnte_Braco.ForeColor = Color.OrangeRed;
            label11.ForeColor = Color.OrangeRed;
            panel22.BackColor = Color.OrangeRed;
        }

        private void maskAnti_Braco_Leave(object sender, EventArgs e)
        {
            maskAnte_Braco.ForeColor = Color.Black;
            label11.ForeColor = Color.Black;
            panel22.BackColor = Color.Black;

            if (maskAnte_Braco.Text.Length < 4)
            {
                MessageBox.Show("Digite a medida com 3 digitos");
                maskAnte_Braco.Clear();
                maskAnte_Braco.Mask = "0,00";
                maskPanturilha.Focus();
            }
        }

        private void maskPanturilha_Enter(object sender, EventArgs e)
        {
            maskPanturilha.ForeColor = Color.OrangeRed;
            label10.ForeColor = Color.OrangeRed;
            panel21.BackColor = Color.OrangeRed;
        }

        private void maskPanturilha_Leave(object sender, EventArgs e)
        {
            maskPanturilha.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
            panel21.BackColor = Color.Black;

            if (maskPanturilha.Text.Length < 4)
            {
                MessageBox.Show("Digite a medida com 3 digitos");
                maskPanturilha.Clear();
                maskPanturilha.Mask = "0,00";
                maskCintura.Focus();
            }
        }

        private void maskCintura_Enter(object sender, EventArgs e)
        {
            maskCintura.ForeColor = Color.OrangeRed;
            label9.ForeColor = Color.OrangeRed;
            panel20.BackColor = Color.OrangeRed;
        }

        private void maskCintura_Leave(object sender, EventArgs e)
        {
            maskCintura.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            panel20.BackColor = Color.Black;

            if (maskCintura.Text.Length < 4)
            {
                MessageBox.Show("Digite a medida com 3 digitos");
                maskCintura.Clear();
                maskCintura.Mask = "0,00";
                btnCadastrar.Focus();
            }
        }

        //metodo para salvar no banco de dados
        private void salvarCalendario(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            try
            {
                // pega os valores dos textBox e envia para o banco de dados

                pessoa.cpf = maskValorCpf.Text;

                pessoaBLL.salvarCalendario(pessoa);

            }
            catch
            {


            }

        }

    }
}
