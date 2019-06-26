using Academia.Bll;
using Academia.Dao;
using Academia.model;
using Login.Ferramentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class AreaSecretaria : Form
    {
        string nome = "";
        int id_aluno;
        string aluno_cpf = "";
        string nome_aluno = "";
        string data_matric = "";
        int tipo_user;
        string funcionario_cpf = "";

        byte[] imagem = null;

        Idade idade = new Idade();

        FecharJanela janela = new FecharJanela();

        DateTime data_hora;

        Pessoa pessoa = new Pessoa();

        PessoaDAO pessoaDAO = new PessoaDAO();
        FuncionarioDAO funcionarioDAO = new FuncionarioDAO();

        ImagemBanco imagemFunc = new ImagemBanco();
        byte[] imagemFunc_byte = null;

        public AreaSecretaria()
        {
            InitializeComponent();
        }

        public AreaSecretaria(string n, byte[] i, string cpf_func, int tipo)
        {
            InitializeComponent();
            nome = n;

            txtUsuario.Text = nome;

            imagem = i;

            funcionario_cpf = cpf_func;

            tipo_user = tipo;
        }

        private void AreaSecretaria_Load(object sender, EventArgs e)
        {
            ActiveControl = maskValorCpf;

            data_hora = DateTime.Now;
            maskDataCadastro.Text = data_hora.ToShortDateString();

            if (imagem != null)
            {
                //joga a imagem recosntruida dentro do pictureBox1
                MemoryStream mstream = new MemoryStream(imagem);

                pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
            }
            else
            {
                pictureBox1 = null;
            }
        }

        public void validarCPF()
        {
            //Validar CPF 
            string valor = maskValorCpf.Text;

            if (ValidaCPF.IsCpf(valor))
            {
                alunoValidarCPF(maskValorCpf.Text);

                maskVencimento.Enabled = true;
                btnMatricula.Enabled = true;

                maskVencimento.Focus();
            }
            else
            {
                MessageBox.Show("O número é um CPF Inválido !");
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
        public void alunoValidarCPF(string c)
        {
            aluno_cpf = maskValorCpf.Text; 
     
            Pessoa pessoa = new Pessoa();

            pessoa = pessoaDAO.alunoValidarCPF(aluno_cpf);

            if (pessoa.cpf == aluno_cpf)
            {
                id_aluno = pessoa.id;
                txt_Id.Text = id_aluno.ToString();

                nome_aluno = pessoa.nome;
                txtNome.Text = nome_aluno;

                data_matric = pessoa.vencimento_matr;
                maskVencimento.Text = data_matric;

                maskVencimento.Focus();
            }
            else
            {
                MessageBox.Show("Não Existe usuario cadastrado" +
                    " com este CPF!");
                maskValorCpf.Focus();
                mascaraCPF();
            }

        }

        //metodo para alterar no banco de dados
        private void alterarMatricula(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            if (maskVencimento.Text.Trim() == string.Empty )
            {
                MessageBox.Show("Existem campos obrigatorios sem preenchimento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskVencimento.BackColor = Color.Beige;
            }
            else
            {
                pessoa.id = Convert.ToInt32(txt_Id.Text);
                pessoa.vencimento_matr = maskVencimento.Text;

                pessoaBLL.alterarMatricula(pessoa);

                MessageBox.Show("Matricula Alterada com Sucesso!");

                maskVencimento.BackColor = Color.White;

                maskVencimento.Enabled = false;
                btnMatricula.Enabled = false;

                maskValorCpf.Clear();
                txt_Id.Clear();
                txtNome.Clear();
                maskVencimento.Clear();

                maskValorCpf.Focus();
            }

        }

        private void btnMatricula_Click(object sender, EventArgs e)
        {
            string pergunta = "Tem certeza que deseja alterar este cadastro?";
            string titulo = "ALTERAR CADASTRO";

            if (MessageBox.Show(pergunta, titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Pessoa pessoa = new Pessoa();
                alterarMatricula(pessoa);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            data_hora = DateTime.Now;
            txtHoracadastro.Text = data_hora.ToLongTimeString();
        }

        private void maskValorCpf_Enter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.OrangeRed;
            maskValorCpf.ForeColor = Color.OrangeRed;
        }

        private void maskValorCpf_Leave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
            maskValorCpf.ForeColor = Color.Black;
        }

        private void maskVencimento_Leave(object sender, EventArgs e)
        {
            maskVencimento.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;

            //verifica se a data esta completa
            if (maskVencimento.Text.Length < 10)
            {
                MessageBox.Show("Digite a data da mensalidade completa");
                maskVencimento.Focus();
            }

            idade.setDataAtual(Convert.ToDateTime(maskDataCadastro.Text));
            idade.setDataVal(Convert.ToDateTime(maskVencimento.Text));

            int data = Convert.ToInt32(idade.VerificarAnoValidoMensalidade());

            //verifica se a data é valida
            if (data < 0)
            {
                MessageBox.Show("Data de matricula invalida! \n\n" +
                    "A data precisa ser superior a data atual!");

                maskVencimento.Focus();
            }
        }

        private void maskVencimento_Enter(object sender, EventArgs e)
        {
            maskVencimento.ForeColor = Color.OrangeRed;
            label2.ForeColor = Color.OrangeRed;
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

        private void maskVencimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void ptbAlterarImagem_Click(object sender, EventArgs e)
        {
            string pergunta = "Tem certeza que deseja alterar a imagem de  cadastro?";
            string titulo = "ALTERAR IMAGEM CADASTRO";

            if (MessageBox.Show(pergunta, titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AlterarImagemSecretariaPC();

                Pessoa pessoa = new Pessoa();
                AlterarImagemFuncionario(pessoa);
            }
        }

        //procurar a imagem no computador e converter para arrayde bytes[]
        public void AlterarImagemSecretariaPC()
        {
            imagemFunc.setSelecionaImagem();

            string foto;

            foto = imagemFunc.getSelecionaImagem();
            pictureBox1.ImageLocation = foto;

            //envia endereço da foto para converter para array de bytes[]
            imagemFunc.ImagemPC(foto);

            //byte[] imagem_byte;
            imagemFunc_byte = imagemFunc.getImagemPC();
        }

        //metodo para alterar no banco de dados
        private void AlterarImagemFuncionario(Pessoa pessoa)
        {
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

            //dados da imagem convertidos em bytes
            pessoa.img = imagemFunc_byte;
            pessoa.cpf = funcionario_cpf;

            funcionarioBLL.AlterarImagemFuncionario(pessoa);

            MessageBox.Show("Imagem Alterada com Sucesso!");

        }

        private void ptbMenu_Click(object sender, EventArgs e)
        {
            panel25.Visible = true;
        }

        private void lbl_FecharMenu_Click(object sender, EventArgs e)
        {
            panel25.Visible = false;
        }

        private void lbl_SairProg_Click(object sender, EventArgs e)
        {
            this.Dispose();
            janela.fecharJanela();
            panel25.Visible = false;
        }

        private void lbl_AlterarCad_Click(object sender, EventArgs e)
        {
            RecuperarSenha recuperar = new RecuperarSenha(funcionario_cpf, tipo_user);
            recuperar.Show();
            panel25.Visible = false;
        }

        private void lbl_FecharMenu_MouseEnter(object sender, EventArgs e)
        {
            lbl_FecharMenu.ForeColor = Color.Black;
        }

        private void lbl_AlterarCad_MouseEnter(object sender, EventArgs e)
        {
            lbl_AlterarCad.ForeColor = Color.Black;
        }

        private void lbl_SairProg_MouseEnter(object sender, EventArgs e)
        {
            lbl_SairProg.ForeColor = Color.Black;
        }

        private void lbl_FecharMenu_MouseLeave(object sender, EventArgs e)
        {
            lbl_FecharMenu.ForeColor = Color.White;
        }

        private void lbl_AlterarCad_MouseLeave(object sender, EventArgs e)
        {
            lbl_AlterarCad.ForeColor = Color.White;
        }

        private void lbl_SairProg_MouseLeave(object sender, EventArgs e)
        {
            lbl_SairProg.ForeColor = Color.White;
        }
    }
}
