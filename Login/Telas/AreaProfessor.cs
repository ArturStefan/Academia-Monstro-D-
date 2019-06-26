using Academia.Bll;
using Academia.Dao;
using Academia.model;
using Login.Ferramentas;
using Login.Model;
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
    public partial class AreaProfessor : Form
    {

        PessoaDAO pessoaDAO = new PessoaDAO();

        Exercicios exercicio = new Exercicios();

        FecharJanela janela = new FecharJanela();

        ImagemBanco imagemFunc = new ImagemBanco();
        byte[] imagemFunc_byte = null;

        int tipo_user;

        int id_aluno;
        string aluno_cpf;

        string nome_aluno;

        string nome = "";
        int confef;
        byte[] imagem = null;

        string funcionario_cpf;

        DateTime data_hora;

        public AreaProfessor()
        {
            InitializeComponent();
        }

        public AreaProfessor(string n, int cod, byte[] i, string cpf_func, int tipo)
        {
            InitializeComponent();
            nome = n;
            confef = cod;

            txtUsuario.Text = nome;
            txtNumConfef.Text = confef.ToString();

            imagem = i;

            funcionario_cpf = cpf_func;

            tipo_user = tipo;
        }

        public void validarCPF()
        {
            //Validar CPF 
            string valor = maskValorCpf.Text;

            if (ValidaCPF.IsCpf(valor))
            {

                alunoValidarCPF(maskValorCpf.Text);
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

        private void AreaProfessor_Load(object sender, EventArgs e)
        {
            data_hora = DateTime.Now;
            maskDataCadastro.Text = data_hora.ToShortDateString();
            listarExercicio();
            listarDicaseReceitas();
            ActiveControl = txtSerie;
            alterarCabecalho();
            alterarCabecalhoDicas();

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

        //Iniciar Relogio
        private void timer1_Tick(object sender, EventArgs e)
        {
            data_hora = DateTime.Now;
            txtHoracadastro.Text = data_hora.ToLongTimeString();
        }

        private void btnCadExercicio_Click(object sender, EventArgs e)
        {
            //salvar no banco de dados
            Exercicios exercicios = new Exercicios();
            salvarExercicio(exercicios);
        }

        //metodo para salvar no banco de dados
        private void salvarExercicio(Exercicios exercicios)
        {
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

            // faz verificação de erros e campos sem preenchimento antes de salvar no banco
            if (txtExercicio.Text == "" || txtSerie.Text == "")
            {
                MessageBox.Show("Existem campos obrigatorios sem preenchimento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExercicio.BackColor = Color.Beige;
                txtSerie.BackColor = Color.Beige;                
            }
            else
            {

                try
                {
                    // pega os valores dos textBox e envia para o banco de dados
                    exercicio.nomeExercicio = txtExercicio.Text;
                    exercicio.numRepeticoes = Convert.ToInt32(txtSerie.Text);

                    funcionarioBLL.salvarExercicio(exercicio);

                    txtSerie.Clear();
                    txtExercicio.Clear();
                    txtSerie.Focus();

                    listarExercicio();

                }
                catch (Exception)
                {

                    MessageBox.Show("Preencha todos os campos obrigatorios");
                }
            }
        }

        //Listar Exercicios na Tabela
        private void listarExercicio()
        {
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

            dataGridView1.DataSource = funcionarioBLL.listarExercicio();
        }

        //Selecionar usuarios na tabela
        public void selecionarUsuarioTabela()
        {   //1º exercicio da segunda - feira
            if(txtSegundaExerc.Text == "")
            {
                    txtSegundaExerc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtSegundaSerie.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    txtTercaExerc.Text = "";
                    txtTercaSerie.Text = "";
                    txtSegundaExerc2.Text = "";
                    txtSegundaSerie2.Text = "";

            }
            else
            {   //2º exercicio da segunda - feira
                if (txtSegundaExerc.Text != "" && txtSegundaExerc2.Text == "")
                {
                    txtSegundaExerc2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtSegundaSerie2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    txtSegundaExerc3.Text = "";
                    txtSegundaSerie3.Text = "";
                }
                else
                {   //3º exercicio da segunda - feira
                    if (txtSegundaExerc3.Text == "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "")
                    {
                        txtSegundaExerc3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        txtSegundaSerie3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                    }
                    else
                    {   //1º exercicio da terça - feira
                        if (txtTercaExerc.Text == "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                        {
                            txtTercaExerc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                            txtTercaSerie.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                            txtTercaExerc2.Text = "";
                            txtTercaSerie2.Text = "";

                        }
                        else
                        {   //2º exercicio da terça - feira
                            if (txtTercaExerc2.Text == "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                            {
                                txtTercaExerc2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                txtTercaSerie2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                            }
                            else
                            {   //3º exercicio da terça - feira
                                if (txtTercaExerc3.Text == "" && txtTercaExerc2.Text != "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                                {
                                    txtTercaExerc3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                    txtTercaSerie3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                    txtQuartaExerc.Text = "";
                                    txtQuartaSerie.Text = "";
                                }
                                else
                                {   //1º exercicio da quarta - feira
                                    if (txtQuartaExerc.Text == "" && txtTercaExerc3.Text != "" && txtTercaExerc2.Text != "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                                    {
                                        txtQuartaExerc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                        txtQuartaSerie.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                        txtQuartaExerc2.Text = "";
                                        txtQuartaSerie2.Text = "";
                                    }
                                    else
                                    {
                                        //2º exercicio da quarta - feira
                                        if (txtQuartaExerc2.Text == "" && txtQuartaExerc.Text != "" && txtTercaExerc3.Text != "" && txtTercaExerc2.Text != "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                                        {
                                            txtQuartaExerc2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                            txtQuartaSerie2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                            txtQuartaExerc3.Text = "";
                                            txtQuartaSerie3.Text = "";
                                        }
                                        else
                                        {
                                            //3º exercicio da quarta - feira
                                            if (txtQuartaExerc3.Text == "" && txtQuartaExerc2.Text != "" && txtQuartaExerc.Text != "" && txtTercaExerc3.Text != "" && txtTercaExerc2.Text != "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                                            {
                                                txtQuartaExerc3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                                txtQuartaSerie3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                                txtQuintaExerc.Text = "";
                                                txtQuintaSerie.Text = "";
                                            }
                                            else
                                            {
                                                //1º exercicio da quinta - feira
                                                if (txtQuintaExerc.Text == "" && txtQuartaExerc3.Text != "" && txtQuartaExerc2.Text != "" && txtQuartaExerc.Text != "" && txtTercaExerc3.Text != "" && txtTercaExerc2.Text != "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                                                {
                                                    txtQuintaExerc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                                    txtQuintaSerie.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                                    txtQuintaExerc2.Text = "";
                                                    txtQuintaSerie2.Text = "";
                                                }
                                                else
                                                {
                                                    //2º exercicio da quinta - feira
                                                    if (txtQuintaExerc2.Text == "" && txtQuintaExerc.Text != "" && txtQuartaExerc3.Text != "" && txtQuartaExerc2.Text != "" && txtQuartaExerc.Text != "" && txtTercaExerc3.Text != "" && txtTercaExerc2.Text != "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                                                    {
                                                        txtQuintaExerc2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                                        txtQuintaSerie2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                                        txtQuintaExerc3.Text = "";
                                                        txtQuintaSerie3.Text = "";
                                                    }
                                                    else
                                                    {
                                                        //3º exercicio da quinta - feira
                                                        if (txtQuintaExerc3.Text == "" && txtQuintaExerc2.Text != "" && txtQuintaExerc.Text != "" && txtQuartaExerc3.Text != "" && txtQuartaExerc2.Text != "" && txtQuartaExerc.Text != "" && txtTercaExerc3.Text != "" && txtTercaExerc2.Text != "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                                                        {
                                                            txtQuintaExerc3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                                            txtQuintaSerie3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                                            txtSextaExerc.Text = "";
                                                            txtSextaSerie3.Text = "";
                                                        }
                                                        else
                                                        {
                                                            //1º exercicio da sexta - feira
                                                            if (txtSextaExerc.Text == "" && txtQuintaExerc3.Text != "" && txtQuintaExerc2.Text != "" && txtQuintaExerc.Text != "" && txtQuartaExerc3.Text != "" && txtQuartaExerc2.Text != "" && txtQuartaExerc.Text != "" && txtTercaExerc3.Text != "" && txtTercaExerc2.Text != "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                                                            {
                                                                txtSextaExerc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                                                txtSextaSerie.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                                                txtSextaExerc2.Text = "";
                                                                txtSextaSerie2.Text = "";
                                                            }
                                                            else
                                                            {
                                                                //2º exercicio da sexta - feira
                                                                if (txtSextaExerc2.Text == "" && txtSextaExerc.Text != "" && txtQuintaExerc3.Text != "" && txtQuintaExerc2.Text != "" && txtQuintaExerc.Text != "" && txtQuartaExerc3.Text != "" && txtQuartaExerc2.Text != "" && txtQuartaExerc.Text != "" && txtTercaExerc3.Text != "" && txtTercaExerc2.Text != "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                                                                {
                                                                    txtSextaExerc2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                                                    txtSextaSerie2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                                                    txtSextaExerc3.Text = "";
                                                                    txtSextaSerie3.Text = "";
                                                                }
                                                                else
                                                                {
                                                                    //3º exercicio da sexta - feira
                                                                    if (txtSextaExerc3.Text == "" && txtSextaExerc2.Text != "" && txtSextaExerc.Text != "" && txtQuintaExerc3.Text != "" && txtQuintaExerc2.Text != "" && txtQuintaExerc.Text != "" && txtQuartaExerc3.Text != "" && txtQuartaExerc2.Text != "" && txtQuartaExerc.Text != "" && txtTercaExerc3.Text != "" && txtTercaExerc2.Text != "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                                                                    {
                                                                        txtSextaExerc3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                                                        txtSextaSerie3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                                                        txtSabadoExerc.Text = "";
                                                                        txtSabadoSerie.Text = "";
                                                                    }
                                                                    else
                                                                    {
                                                                        //1º exercicio da sabado 
                                                                        if (txtSabadoExerc.Text == "" && txtSextaExerc3.Text != "" && txtSextaExerc2.Text != "" && txtSextaExerc.Text != "" && txtQuintaExerc3.Text != "" && txtQuintaExerc2.Text != "" && txtQuintaExerc.Text != "" && txtQuartaExerc3.Text != "" && txtQuartaExerc2.Text != "" && txtQuartaExerc.Text != "" && txtTercaExerc3.Text != "" && txtTercaExerc2.Text != "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                                                                        {
                                                                            txtSabadoExerc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                                                            txtSabadoSerie.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                                                            txtSabadoExerc2.Text = "";
                                                                            txtSabadoSerie2.Text = "";
                                                                        }
                                                                        else
                                                                        {
                                                                            //2º exercicio da sabado 
                                                                            if (txtSabadoExerc2.Text == "" && txtSabadoExerc.Text != "" && txtSextaExerc3.Text != "" && txtSextaExerc2.Text != "" && txtSextaExerc.Text != "" && txtQuintaExerc3.Text != "" && txtQuintaExerc2.Text != "" && txtQuintaExerc.Text != "" && txtQuartaExerc3.Text != "" && txtQuartaExerc2.Text != "" && txtQuartaExerc.Text != "" && txtTercaExerc3.Text != "" && txtTercaExerc2.Text != "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                                                                            {
                                                                                txtSabadoExerc2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                                                                txtSabadoSerie2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                                                                txtSabadoExerc3.Text = "";
                                                                                txtSabadoSerie3.Text = "";
                                                                            }
                                                                            else
                                                                            {
                                                                                //3º exercicio da sabado 
                                                                                if (txtSabadoExerc3.Text == "" && txtSabadoExerc2.Text != "" && txtSabadoExerc.Text != "" && txtSextaExerc3.Text != "" && txtSextaExerc2.Text != "" && txtSextaExerc.Text != "" && txtQuintaExerc3.Text != "" && txtQuintaExerc2.Text != "" && txtQuintaExerc.Text != "" && txtQuartaExerc3.Text != "" && txtQuartaExerc2.Text != "" && txtQuartaExerc.Text != "" && txtTercaExerc3.Text != "" && txtTercaExerc2.Text != "" && txtTercaExerc.Text != "" && txtSegundaExerc.Text != "" && txtSegundaExerc2.Text != "" && txtSegundaExerc3.Text != "")
                                                                                {
                                                                                    txtSabadoExerc3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                                                                    txtSabadoSerie3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    
                }

            }
        }

        public void limparExerciciosAluno()
        {
            txtSegundaExerc.Text = "";
            txtSegundaSerie.Text = "";
            txtSegundaPeso.Text = "";
            txtSegundaExerc2.Text = "";
            txtSegundaSerie2.Text = "";
            txtSegundaPeso2.Text = "";
            txtSegundaExerc3.Text = "";
            txtSegundaSerie3.Text = "";
            txtSegundaPeso3.Text = "";
            txtTercaExerc.Text = "";
            txtTercaSerie.Text = "";
            txtTercaPeso.Text = "";
            txtTercaExerc2.Text = "";
            txtTercaSerie2.Text = "";
            txtTercaPeso2.Text = "";
            txtTercaExerc3.Text = "";
            txtTercaSerie3.Text = "";
            txtTercaPeso3.Text = "";
            txtQuartaExerc.Text = "";
            txtQuartaSerie.Text = "";
            txtQuartaPeso.Text = "";
            txtQuartaExerc2.Text = "";
            txtQuartaSerie2.Text = "";
            txtQuartaPeso2.Text = "";
            txtQuartaExerc3.Text = "";
            txtQuartaSerie3.Text = "";
            txtQuartaPeso3.Text = "";
            txtQuintaExerc.Text = "";
            txtQuintaSerie.Text = "";
            txtQuintaPeso.Text = "";
            txtQuintaExerc2.Text = "";
            txtQuintaSerie2.Text = "";
            txtQuintaPeso2.Text = "";
            txtQuintaExerc3.Text = "";
            txtQuintaSerie3.Text = "";
            txtQuintaPeso3.Text = "";
            txtSextaExerc.Text = "";
            txtSextaSerie.Text = "";
            txtSextaPeso.Text = "";
            txtSextaExerc2.Text = "";
            txtSextaSerie2.Text = "";
            txtSextaPeso2.Text = "";
            txtSextaExerc3.Text = "";
            txtSextaSerie3.Text = "";
            txtSextaPeso3.Text = "";
            txtSabadoExerc.Text = "";
            txtSabadoSerie.Text = "";
            txtSabadoPeso.Text = "";
            txtSabadoExerc2.Text = "";
            txtSabadoSerie2.Text = "";
            txtSabadoPeso2.Text = "";
            txtSabadoExerc3.Text = "";
            txtSabadoSerie3.Text = "";
            txtSabadoPeso3.Text = "";
        }

        //seleciona exercicio do aluno por dia da semana
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selecionarUsuarioTabela();
        }

        private void btnExerAluno_Click(object sender, EventArgs e)
        {
            Exercicios exercicio = new Exercicios();
            salvarExerciciosAluno(exercicio);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparExerciciosAluno();

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

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void txtSegundaPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void txtTercaPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void txtQuartaPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void txtQuintaPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void txtSextaPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void txtSabadoPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void maskValorCpf_Leave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Black;
            maskValorCpf.ForeColor = Color.Black;

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
  
            }
            else
            {
                MessageBox.Show("Não Existe usuario cadastrado" +
                    " com este CPF!");
                maskValorCpf.Focus();
                mascaraCPF();
            }

        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            validarCPF();
        }

        private void salvarExerciciosAluno(Exercicios exercicio)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            // faz verificação de erros e campos sem preenchimento antes de salvar no banco
            if (txtNome.Text == "Nome" || maskValorCpf.Text.Trim() == "000,000,000-00"  || txt_Id.Text == "")
            {
                MessageBox.Show("Existem campos obrigatorios sem preenchimento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.BackColor = Color.Beige;
                txt_Id.BackColor = Color.Beige;
                maskValorCpf.BackColor = Color.Beige;

            }
            else
            {

                try
                {
                    // pega os valores dos textBox e envia para o banco de dados
                    exercicio.idAluno = Convert.ToInt32(txt_Id.Text);
                    exercicio.nomeAluno = txtNome.Text;
                    exercicio.cpfAluno = maskValorCpf.Text;

                    exercicio.seg01_exerc = txtSegundaExerc.Text;
                    exercicio.seg01_serie = Convert.ToInt32(txtSegundaSerie.Text);
                    exercicio.seg01_peso = Convert.ToDouble(txtSegundaPeso.Text);
                    exercicio.seg02_exerc = txtSegundaExerc2.Text;
                    exercicio.seg02_serie = Convert.ToInt32(txtSegundaSerie2.Text);
                    exercicio.seg02_peso = Convert.ToDouble(txtSegundaPeso2.Text);
                    exercicio.seg03_exerc = txtSegundaExerc3.Text;
                    exercicio.seg03_serie = Convert.ToInt32(txtSegundaSerie3.Text);
                    exercicio.seg03_peso = Convert.ToDouble(txtSegundaPeso3.Text);

                    exercicio.ter01_exerc = txtTercaExerc.Text;
                    exercicio.ter01_serie = Convert.ToInt32(txtTercaSerie.Text);
                    exercicio.ter01_peso = Convert.ToDouble(txtTercaPeso.Text);
                    exercicio.ter02_exerc = txtTercaExerc2.Text;
                    exercicio.ter02_serie = Convert.ToInt32(txtTercaSerie2.Text);
                    exercicio.ter02_peso = Convert.ToDouble(txtTercaPeso2.Text);
                    exercicio.ter03_exerc = txtTercaExerc3.Text;
                    exercicio.ter03_serie = Convert.ToInt32(txtTercaSerie3.Text);
                    exercicio.ter03_peso = Convert.ToDouble(txtTercaPeso3.Text);

                    exercicio.qua01_exerc = txtQuartaExerc.Text;
                    exercicio.qua01_serie = Convert.ToInt32(txtQuartaSerie.Text);
                    exercicio.qua01_peso = Convert.ToDouble(txtQuartaPeso.Text);
                    exercicio.qua02_exerc = txtQuartaExerc2.Text;
                    exercicio.qua02_serie = Convert.ToInt32(txtQuartaSerie2.Text);
                    exercicio.qua02_peso = Convert.ToDouble(txtQuartaPeso2.Text);
                    exercicio.qua03_exerc = txtQuartaExerc3.Text;
                    exercicio.qua03_serie = Convert.ToInt32(txtQuartaSerie3.Text);
                    exercicio.qua03_peso = Convert.ToDouble(txtQuartaPeso3.Text);

                    exercicio.qui01_exerc = txtQuintaExerc.Text;
                    exercicio.qui01_serie = Convert.ToInt32(txtQuintaSerie.Text);
                    exercicio.qui01_peso = Convert.ToDouble(txtQuintaPeso.Text);
                    exercicio.qui02_exerc = txtQuintaExerc2.Text;
                    exercicio.qui02_serie = Convert.ToInt32(txtQuintaSerie2.Text);
                    exercicio.qui02_peso = Convert.ToDouble(txtQuintaPeso2.Text);
                    exercicio.qui03_exerc = txtQuintaExerc3.Text;
                    exercicio.qui03_serie = Convert.ToInt32(txtQuintaSerie3.Text);
                    exercicio.qui03_peso = Convert.ToDouble(txtQuintaPeso3.Text);

                    exercicio.sex01_exerc = txtSextaExerc.Text;
                    exercicio.sex01_serie = Convert.ToInt32(txtSextaSerie.Text);
                    exercicio.sex01_peso = Convert.ToDouble(txtSextaPeso.Text);
                    exercicio.sex02_exerc = txtSextaExerc2.Text;
                    exercicio.sex02_serie = Convert.ToInt32(txtSextaSerie2.Text);
                    exercicio.sex02_peso = Convert.ToDouble(txtSextaPeso2.Text);
                    exercicio.sex03_exerc = txtSextaExerc3.Text;
                    exercicio.sex03_serie = Convert.ToInt32(txtSextaSerie3.Text);
                    exercicio.sex03_peso = Convert.ToDouble(txtSextaPeso3.Text);

                    exercicio.sab01_exerc = txtSabadoExerc.Text;
                    exercicio.sab01_serie = Convert.ToInt32(txtSabadoSerie.Text);
                    exercicio.sab01_peso = Convert.ToDouble(txtSabadoPeso.Text);
                    exercicio.sab02_exerc = txtSabadoExerc2.Text;
                    exercicio.sab02_serie = Convert.ToInt32(txtSabadoSerie2.Text);
                    exercicio.sab02_peso = Convert.ToDouble(txtSabadoPeso2.Text);
                    exercicio.sab03_exerc = txtSabadoExerc3.Text;
                    exercicio.sab03_serie = Convert.ToInt32(txtSabadoSerie3.Text);
                    exercicio.sab03_peso = Convert.ToDouble(txtSabadoPeso3.Text);

                    pessoaBLL.salvarExerciciosAluno(exercicio);

                    txtNome.BackColor = Color.White;
                    txt_Id.BackColor = Color.White;
                    maskValorCpf.BackColor = Color.White;

                    limparExerciciosAluno();

                }
                catch (Exception)
                {

                    MessageBox.Show("Preencha todos os campos obrigatorios");
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string pergunta = "Tem certeza que deseja alterar este exercicio?";
            string titulo = "ALTERAR EXERCICIO";

            if (MessageBox.Show(pergunta, titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Exercicios exercicios = new Exercicios();
                alterarExerciciosAcad(exercicios);
            }
            else
            {
                txt_Id_Exercicio.Text = "";
                txt_NºSeries.Text = "";
                txt_Tipo_Exercicio.Text = "";
            }
        }

        //metodo para alterar no banco de dados
        private void alterarExerciciosAcad(Exercicios exercicios)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            if (txt_Id_Exercicio.Text.Trim() == string.Empty || txt_NºSeries.Text.Trim() == string.Empty || txt_Tipo_Exercicio.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Existem campos obrigatorios sem preenchimento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Id_Exercicio.BackColor = Color.Beige;
                txt_NºSeries.BackColor = Color.Beige;
                txt_Tipo_Exercicio.BackColor = Color.Beige;
            }
            else
            {
                exercicios.idExercicio = Convert.ToInt32(txt_Id_Exercicio.Text);
                exercicios.nomeExercicio = txt_Tipo_Exercicio.Text;
                exercicios.numRepeticoes = Convert.ToInt32(txt_NºSeries.Text);

                pessoaBLL.alterarExerciciosAcad(exercicios);

                MessageBox.Show("Dados Alterados com Sucesso!");

                txt_Id_Exercicio.Text = "";
                txt_NºSeries.Text = "";
                txt_Tipo_Exercicio.Text = "";
                txt_Id_Exercicio.BackColor = Color.White;
                txt_NºSeries.BackColor = Color.White;
                txt_Tipo_Exercicio.BackColor = Color.White;

                listarExercicio();
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string pergunta = "Tem certeza que deseja excluir este exercicio?";
            string titulo = "EXCLUIR EXERCICIO";

            if (MessageBox.Show(pergunta, titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Exercicios exercicios = new Exercicios();
                deletarExerciciosAcad(exercicios);
            }
            else
            {
                txt_Id_Exercicio.Text = "";
                txt_NºSeries.Text = "";
                txt_Tipo_Exercicio.Text = "";
            }
        }

        //metodo para Deletar no banco de dados
        private void deletarExerciciosAcad(Exercicios exercicios)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            if (txt_Id_Exercicio.Text.Trim() == string.Empty )
            {
                MessageBox.Show("Existem campos obrigatorios sem preenchimento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Id_Exercicio.BackColor = Color.Beige;
                txt_NºSeries.BackColor = Color.Beige;
                txt_Tipo_Exercicio.BackColor = Color.Beige;
            }
            else
            {
                exercicios.idExercicio = Convert.ToInt32(txt_Id_Exercicio.Text);

                pessoaBLL.deletarExerciciosAcad(exercicios);

                MessageBox.Show("Dados Exluidos com Sucesso!");

                txt_Id_Exercicio.Text = "";
                txt_NºSeries.Text = "";
                txt_Tipo_Exercicio.Text = "";
                txt_Id_Exercicio.BackColor = Color.White;
                txt_NºSeries.BackColor = Color.White;
                txt_Tipo_Exercicio.BackColor = Color.White;

                listarExercicio();

            }

        }

        public void alterarCabecalho()
        {
            //renomeia as colunas do datagridview
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Exercício";
            dataGridView1.Columns[2].HeaderText = "Repetições";

            //redimensiona o tamanho das colunas do datagridview

            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 190;
            dataGridView1.Columns[2].Width = 80;

            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightYellow;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.OrangeRed;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.OrangeRed;
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

        private void salvarDicaseReceitas(Exercicios exercicio)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            // faz verificação de erros e campos sem preenchimento antes de salvar no banco
            if (txtDicas.Text.Trim() == string.Empty )
            {
                MessageBox.Show("Existem campos obrigatorios sem preenchimento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDicas.BackColor = Color.Beige;
            }
            else
            {

                try
                {
                    // pega os valores dos textBox e envia para o banco de dados
                    exercicio.dicas_exerc_acad = txtDicas.Text;

                    pessoaBLL.salvarDicaseReceitas(exercicio);

                    listarDicaseReceitas();

                    txtDicas.BackColor = Color.White;
                    txtDicas.Clear();

                }
                catch (Exception)
                {

                    MessageBox.Show("Preencha todos os campos obrigatorios");
                }
            }
        }

        private void txtDicas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDicas.Text.Length > 300)
            {
                txtDicas.Enabled = false;
            }
        }

        private void btnSalvarDicas_Click(object sender, EventArgs e)
        {
            salvarDicaseReceitas(exercicio);
        }

        //Listar Exercicios na Tabela
        private void listarDicaseReceitas()
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            dataGridView2.DataSource = pessoaBLL.listarDicaseReceitas();
        }

        public void alterarCabecalhoDicas()
        {
            //renomeia as colunas do datagridview
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Exercicios e Receitas";


            //redimensiona o tamanho das colunas do datagridview

            dataGridView2.Columns[0].Width = 30;
            dataGridView2.Columns[1].Width = 250;


            dataGridView2.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.RowsDefaultCellStyle.BackColor = Color.LightYellow;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.OrangeRed;
            dataGridView2.RowHeadersDefaultCellStyle.BackColor = Color.OrangeRed;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel25.Visible = true;
        }

        private void lbl_FecharMenu_Click(object sender, EventArgs e)
        {
            panel25.Visible = false;
        }

        private void lbl_AlterarCad_Click(object sender, EventArgs e)
        {
            RecuperarSenha recuperar = new RecuperarSenha(funcionario_cpf, tipo_user);
            recuperar.Show();
            panel25.Visible = false;
        }

        private void lbl_SairProg_Click(object sender, EventArgs e)
        {
            this.Dispose();
            janela.fecharJanela();
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
