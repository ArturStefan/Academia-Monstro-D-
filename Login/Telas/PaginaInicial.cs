using Academia.Bll;
using Academia.Dao;
using Academia.model;
using Login.Calendario;
using Login.Ferramentas;
using Login.Model;
using Login.Telas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class PaginaInicial : Form
    {       
        int contador ;
        Pessoa pessoa = new Pessoa();
        PessoaDAO pessoaDAO = new PessoaDAO();

        Idade idade = new Idade();

        FecharJanela janela = new FecharJanela();

        IndiceGordura indice = new IndiceGordura();

        ImagemBanco imagemAluno = new ImagemBanco();
        byte[] imagemAluno_byte = null;

        DateTime data_hora;
        string nome = "";
        string cpfAluno;
        string vencimento = "";
        double imc;
        double peso;
        double ind_gordura;
        double bicepis;
        double anti_braco;
        double coxa;
        double panturilha;
        double peitoral;
        double cintura;
        int sexo;
        string nascimento;
        int idade_aluno;
        double altura_atual;
        double peso_atual;
        string situacao_atual;
        int tipo_user;
        int contador_med = 0;
        int contador_exer = 0;

        byte[] imagem = null;

        int contPresenca = 0;

        /*Calendario
       -----------------------------------------------------------------------------*/

        //Instancia de classes
        private Controle controle;
        private DAO dao;

        //Variaveis de controle
        private int[] VcontroleBotoes;
        private int[] dias;
        private Button[] botos;
        private int tamanhoMes;
        /*-----------------------------------------------------------------------------*/

        public PaginaInicial()
        {
            InitializeComponent();           
        }

        //recebendo valores do banco de dados ao carregar a tela.
        public PaginaInicial(string no, string cpf, string venc, double pes, double gord, double im, double bic, double ant,
        double cox, double pan, double peit, double cint, int tipo, int sex, byte[] i, string nasc)
        {
            InitializeComponent();
            nome = no;
            cpfAluno = cpf;
            vencimento = venc;
            peso = pes;
            imc = im;
            ind_gordura = gord;
            bicepis = bic;
            anti_braco = ant;
            coxa = cox;
            panturilha = pan;
            peitoral = peit;
            cintura = cint;
            sexo = sex;
            tipo_user = tipo;
            imagem = i;
            nascimento = nasc;

            /*Calendario
           -----------------------------------------------------------------------------*/

            //Inicializa as classes
            dao = new DAO();
            controle = new Controle();

            //seta o tamanho dos arrays
            dias = new int[37];
            VcontroleBotoes = new int[37];

            //Função que carrega os botões
            CarregarBotoes();

            //pega o tamanho do mes
            tamanhoMes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            /*-----------------------------------------------------------------------------*/

        }

        public void contadorPresenca()
        {

            if (contador >= 21)
            {
                MessageBox.Show("Parabens");
            }
            else
            {
                for(int i = 1; i <= contador; i++)
                {
                    Thread.Sleep(1);
                    progressBar1.Value = i;
                    progressBar1.Update();
                }
                
            }

            if (contador == 8)
            {
                label24.Text = "Muito bem.";
            }
            if (contador == 14)
            {
                label24.Text = "Continue assim.";
            }
            if (contador == 17)
            {
                label24.Text = "Agora falta pouco.";
            }
            if (contador == 20)
            {
                label24.Text = "Parabens.";
                label24.ForeColor = Color.OrangeRed;
                label24.Font = new Font(label24.Font, FontStyle.Bold);
            }

            if (lbl_Porcentagem.Text == "100")
            {

            }
            else
            {
                double porc;
                porc = contador * 100 / 20;
                lbl_Porcentagem.Text = porc.ToString();
            }

        }

        public void habilitarBotoes()
        {
            //habilitar botões de salvar e atualizar
            if (contador_med == 0)
            {
                btnSalvarMedidas.Enabled = true;
                btnAtualizarMedidas.Enabled = false;
            }
            if (contador_med == 1)
            {
                btnSalvarMedidas.Enabled = false;
                btnAtualizarMedidas.Enabled = true;
            }
        }

        private void PaginaInicial_Load(object sender, EventArgs e)
        {
 
            ActiveControl = maskAlturaAtual;
            textBox1.Text = nome;
            maskVencimento.Text = vencimento;
            maskPerc_GorduraInicial.Text = ind_gordura.ToString();
            maskPesoInicial.Text = peso.ToString();
            mask_Imc_Inicial.Text = imc.ToString();
            maskBicepis.Text = bicepis.ToString();
            maskAnte_braco.Text = anti_braco.ToString();
            maskCoxa.Text = coxa.ToString();
            maskPanturilha.Text = panturilha.ToString();
            maskPeitoral.Text = peitoral.ToString();
            maskCintura.Text = cintura.ToString();
            maskNascimento.Text = nascimento;

            data_hora = DateTime.Now;
            maskDataCadastro.Text = data_hora.ToShortDateString();

            calcularIdade();

            //ver qual dia estamos do mês
            //string dia = maskDataCadastro.Text.Substring(0, 2);
            //MessageBox.Show(dia);

            mensalidadeVenver();

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

            //verifica se ja exixste novas medidas cadastradas
            existeNovasMedidasAluno(cpfAluno);

            //Habilita e desabilita botões de salvar e alterar
            habilitarBotoes();

            //verifica se ja existe exercicios cadastrados para o aluno
            existeExercicioAluno(cpfAluno);

            /*Calendario
           -----------------------------------------------------------------------------*/
           
            //inicia as funçoes
            PainelPrimeiroDia();
            setValor();

            //recebe os valores do banco de dados
            Valores valor = dao.Valor(cpfAluno);
            
            //Executa 3 funções ao mesmo tempo
            int i = 0;
            foreach (var item in valor.Vetor)
            {
                try
                {
                    //Traz os valores das variaveis do banco para o array de controle
                    VcontroleBotoes[i] = item;

                    //Atualiza os valores das variaveis de controle
                    VcontroleBotoes[i] = controle.setControle(VcontroleBotoes[i], dias[i]);

                    //Define a cor dos botões
                    controle.CoresBotoes(VcontroleBotoes[i], dias[i], botos[i]);
                }
                catch (Exception) { MessageBox.Show("Nulo"); }
                finally { i++; }
            }

            //Atualiza as variaveis de controle no banco de dados
            dao.atualizaBd(valor.CPF, valor.Vetor);

            /*-----------------------------------------------------------------------------*/

            verificarPresenca(cpfAluno);

            //Barra de progresso do aluno por presenças

            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 20;

            progressBar1.Value = contador;

            if(txtSituacaoAtual.Text != "")
            {
                //indicação de melhora ou piora nas medidas do aluno
                progressoAluno();

                maskBicepisAtual.Enabled = true;
                maskAnte_bracoAtual.Enabled = true;
                maskCoxaAtual.Enabled = true;
                maskPanturilhaAtual.Enabled = true;
                maskPeitoralAtual.Enabled = true;
                maskCinturaAtual.Enabled = true;
            }
            
        }
       

        //Mostra hora e data atual
        private void timer1_Tick(object sender, EventArgs e)
        {
            data_hora = DateTime.Now;
            txtHoracadastro.Text = data_hora.ToLongTimeString();
        }

        public void mensalidadeVenver()
        {
            try
            {
                idade.setDataAtual(Convert.ToDateTime(maskDataCadastro.Text));
                idade.setDataMens(Convert.ToDateTime(maskVencimento.Text));

                string DiasMensalidade;
                DiasMensalidade = idade.Mensalidade();

                if (Convert.ToInt16(DiasMensalidade) >= 6)
                {
                    panel1.Enabled = true;
                }
                else if (Convert.ToInt16(DiasMensalidade) >= 1 && Convert.ToInt16(DiasMensalidade) <= 5)
                {

                    MessageBox.Show("Faltam " + DiasMensalidade + " dias encerrar sua matricula", "PRAZO DA MENSALIDADE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    panel1.Enabled = true;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                string pergunta = "Sua Mensalidade expirou! \n\n" +
                    "Renove sua mensalidade para continuar" +
                    " usando todos os recursos do programa!";
                string titulo = "VENCIMENTO MENSALIDADE";

                MessageBox.Show(pergunta, titulo,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                panel1.Enabled = false;

            }
        }

        public void calcularIdade()
        {
            try
            {
                idade.setDataAtual(Convert.ToDateTime(maskDataCadastro.Text));
                idade.setDataNasc(Convert.ToDateTime(maskNascimento.Text));

                string idadeAluno;
                idadeAluno = idade.IdadeAluno();
                txtIdade.Text = idadeAluno;
                maskAlturaAtual.Focus();
            }
            catch
            {
                maskAlturaAtual.Focus();
            }
        }

        //retorna o resultado do calculo do indice de gordura da Classe
        public void indiceGordura()
        {
            try
            {
                if (maskPesoAtual.Mask != "00,00" || maskAlturaAtual.Text != "0,00" || maskNascimento.Text != "00/00/0000")
                {
                    indice.setPeso((Convert.ToDouble(maskPesoAtual.Text)) / 100);
                    indice.setAltura((Convert.ToDouble(maskAlturaAtual.Text)) / 100);
                    indice.setIdade(Convert.ToInt32(txtIdade.Text));

                    if (sexo == 1)
                    {
                        indice.setSexo(sexo);
                    }
                    if (sexo == 0)
                    {
                        indice.setSexo(sexo);
                    }

                    double percent;
                    percent = indice.Indice();
                    maskPerc_GorduraAtual.Text = Convert.ToString(Math.Round(percent, 2));

                    string situacao;
                    situacao = indice.SituacaoAluno();
                    txtSituacaoAtual.Text = situacao;

                    double imc;
                    imc = indice.IMC();
                    mask_Imc_Atual.Text = Convert.ToString(Math.Round(imc, 2));

                    maskPesoAtual.BackColor = Color.White;
                    maskAlturaAtual.BackColor = Color.White;
                    maskNascimento.BackColor = Color.White;

                    maskBicepisAtual.Enabled = true;
                    maskAnte_bracoAtual.Enabled = true;
                    maskCoxaAtual.Enabled = true;
                    maskPanturilhaAtual.Enabled = true;
                    maskPeitoralAtual.Enabled = true;
                    maskCinturaAtual.Enabled = true;

                    maskBicepisAtual.Focus();

                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Existem campos obrigatorios sem preenchimento");
                maskPesoAtual.BackColor = Color.Beige;
                maskAlturaAtual.BackColor = Color.Beige;
                maskNascimento.BackColor = Color.Beige;
            }

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

        private void maskPesoAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void maskPerc_GorduraAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void mask_Imc_Atual_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void maskBraçoAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void maskPernaAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void maskAbdomenAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void maskNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void maskAlturaAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            bloquearLetras(sender, e);
        }

        private void btnExercicio_Click(object sender, EventArgs e)
        {
            ExerciciosAluno jExercicio = new ExerciciosAluno(cpfAluno);
            jExercicio.Show();
        }

        private void btnNovoIndice_Click(object sender, EventArgs e)
        {
            indiceGordura();
        }

        private void maskAlturaAtual_Enter_1(object sender, EventArgs e)
        {
            maskAlturaAtual.ForeColor = Color.OrangeRed;
            label15.ForeColor = Color.OrangeRed;
            panel16.ForeColor = Color.OrangeRed;
        }

        private void maskAlturaAtual_Leave_1(object sender, EventArgs e)
        {
            maskAlturaAtual.ForeColor = Color.Black;
            label15.ForeColor = Color.Black;
            panel16.ForeColor = Color.Black;

            if (maskAlturaAtual.Text.Length < 4)
            {
                MessageBox.Show("Digite a altura com 3 digitos");
                maskAlturaAtual.Mask = "0,00";
            }
        }

        private void maskPesoAtual_Enter_1(object sender, EventArgs e)
        {
            maskPesoAtual.ForeColor = Color.OrangeRed;
            label4.ForeColor = Color.OrangeRed;
            panel4.ForeColor = Color.OrangeRed;
        }

        private void maskPesoAtual_Leave_1(object sender, EventArgs e)
        {
            maskPesoAtual.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            panel4.ForeColor = Color.Black;

            if (maskPesoAtual.Text.Length < 4)
            {
                MessageBox.Show("Digite o peso com 4 digitos");
                maskPesoAtual.Mask = "00,00";
            }
        }

        private void maskBicepisAtual_Enter(object sender, EventArgs e)
        {
            maskBicepisAtual.ForeColor = Color.OrangeRed;
            label12.ForeColor = Color.OrangeRed;
            panel12.ForeColor = Color.OrangeRed;
        }

        private void maskBicepisAtual_Leave(object sender, EventArgs e)
        {
            maskBicepisAtual.ForeColor = Color.Black;
            label12.ForeColor = Color.Black;
            panel12.ForeColor = Color.Black;

            if (maskBicepisAtual.Text.Length < 3)
            {
                MessageBox.Show("Digite a medida com 3 digitos");
                maskBicepisAtual.Mask = "0,00"; 
            }
        }

        private void maskAnti_bracoAtual_Enter(object sender, EventArgs e)
        {
            maskAnte_bracoAtual.ForeColor = Color.OrangeRed;
            label11.ForeColor = Color.OrangeRed;
            panel11.ForeColor = Color.OrangeRed;
        }

        private void maskAnti_bracoAtual_Leave(object sender, EventArgs e)
        {
            maskAnte_bracoAtual.ForeColor = Color.Black;
            label11.ForeColor = Color.Black;
            panel11.ForeColor = Color.Black;

            if (maskAnte_bracoAtual.Text.Length < 3)
            {
                MessageBox.Show("Digite a medida com 3 digitos");
                maskAnte_bracoAtual.Mask = "0,00";
            }
        }

        private void maskCoxaAtual_Enter(object sender, EventArgs e)
        {
            maskCoxaAtual.ForeColor = Color.OrangeRed;
            label10.ForeColor = Color.OrangeRed;
            panel7.ForeColor = Color.OrangeRed;
        }

        private void maskCoxaAtual_Leave(object sender, EventArgs e)
        {
            maskCoxaAtual.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
            panel7.ForeColor = Color.Black;

            if (maskCoxaAtual.Text.Length < 3)
            {
                MessageBox.Show("Digite a medida com 3 digitos");
                maskCoxaAtual.Mask = "0,00";
            }
        }

        private void maskPanturilhaAtual_Enter(object sender, EventArgs e)
        {
            maskPanturilhaAtual.ForeColor = Color.OrangeRed;
            label17.ForeColor = Color.OrangeRed;
            panel18.ForeColor = Color.OrangeRed;
        }

        private void maskPanturilhaAtual_Leave(object sender, EventArgs e)
        {
            maskPanturilhaAtual.ForeColor = Color.Black;
            label17.ForeColor = Color.Black;
            panel18.ForeColor = Color.Black;

            if (maskPanturilhaAtual.Text.Length < 3)
            {
                MessageBox.Show("Digite a medida com 3 digitos");
                maskPanturilhaAtual.Mask = "0,00";
            }
        }

        private void maskPeitoralAtual_Enter(object sender, EventArgs e)
        {
            maskPeitoralAtual.ForeColor = Color.OrangeRed;
            label19.ForeColor = Color.OrangeRed;
            panel20.ForeColor = Color.OrangeRed;
        }

        private void maskPeitoralAtual_Leave(object sender, EventArgs e)
        {
            maskPeitoralAtual.ForeColor = Color.Black;
            label19.ForeColor = Color.Black;
            panel20.ForeColor = Color.Black;

            if (maskPeitoralAtual.Text.Length < 3)
            {
                MessageBox.Show("Digite a medida com 3 digitos");
                maskPeitoralAtual.Mask = "0,00";
            }
        }

        private void maskCinturaAtual_Enter(object sender, EventArgs e)
        {
            maskCinturaAtual.ForeColor = Color.OrangeRed;
            label21.ForeColor = Color.OrangeRed;
            panel22.ForeColor = Color.OrangeRed;
        }

        private void maskCinturaAtual_Leave(object sender, EventArgs e)
        {
            maskCinturaAtual.ForeColor = Color.Black;
            label21.ForeColor = Color.Black;
            panel22.ForeColor = Color.Black;

            if (maskCinturaAtual.Text.Length < 3)
            {
                MessageBox.Show("Digite a medida com 3 digitos");
                maskCinturaAtual.Mask = "0,00";
            }
        }

        private void btnSalvarMedidas_Click(object sender, EventArgs e)
        {
            MedidasAluno medidas = new MedidasAluno();
            salvarMedidasAluno(medidas);
        }

        private void salvarMedidasAluno(MedidasAluno medidas)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            // faz verificação de erros e campos sem preenchimento antes de salvar no banco
            if (txtIdade.Text == "" || txtSituacaoAtual.Text.Trim() == "")
            {
                MessageBox.Show("Existem campos obrigatorios sem preenchimento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskNascimento.BackColor = Color.Beige;
                maskPesoAtual.BackColor = Color.Beige;
                maskAlturaAtual.BackColor = Color.Beige;
                txtSituacaoAtual.BackColor = Color.Beige;
                txtIdade.BackColor = Color.Beige;
                maskBicepisAtual.BackColor = Color.Beige;
                maskAnte_bracoAtual.BackColor = Color.Beige;
                maskCoxaAtual.BackColor = Color.Beige;
                maskPanturilhaAtual.BackColor = Color.Beige;
                maskPeitoralAtual.BackColor = Color.Beige;
                maskCinturaAtual.BackColor = Color.Beige;
            }
            else
            {
                try
                {
                    // pega os valores dos textBox e envia para o banco de dados
                    medidas.cpf_aluno = cpfAluno;
                    medidas.nascimento = maskNascimento.Text;
                    medidas.idade_atual = Convert.ToInt32(txtIdade.Text);
                    medidas.altura_atual = (Convert.ToDouble(maskAlturaAtual.Text) / 100 );
                    medidas.peso_atual = (Convert.ToDouble(maskPesoAtual.Text) / 100);
                    medidas.gordura_atual = (Convert.ToDouble(maskPerc_GorduraAtual.Text) / 100);
                    medidas.imc_atual = (Convert.ToDouble(mask_Imc_Atual.Text) / 100);
                    medidas.situacao_atual = txtSituacaoAtual.Text;
                    medidas.bicepis_atual = (Convert.ToDouble(maskBicepisAtual.Text) / 100);
                    medidas.anti_braco_atual = (Convert.ToDouble(maskAnte_bracoAtual.Text) / 100);
                    medidas.coxa_atual = (Convert.ToDouble(maskCoxaAtual.Text) / 100);
                    medidas.panturilha_atual = (Convert.ToDouble(maskPanturilhaAtual.Text) / 100);
                    medidas.peitoral_atual = (Convert.ToDouble(maskPeitoralAtual.Text) / 100);
                    medidas.cintura_atual = (Convert.ToDouble(maskCinturaAtual.Text) / 100);
                    medidas.contador = 1;
                    medidas.sexo = sexo;


                    pessoaBLL.salvarMedidasAluno(medidas);

                    //Bloqueia botão de salvar e habilita botão alterar
                    btnSalvarMedidas.Enabled = false;
                    btnAtualizarMedidas.Enabled = true;

                    maskNascimento.BackColor = Color.White;
                    maskPesoAtual.BackColor = Color.White;
                    maskAlturaAtual.BackColor = Color.White;
                    txtSituacaoAtual.BackColor = Color.White;
                    txtIdade.BackColor = Color.White;
                    maskBicepis.BackColor = Color.White;
                    maskAnte_bracoAtual.BackColor = Color.White;
                    maskCoxaAtual.BackColor = Color.White;
                    maskPanturilhaAtual.BackColor = Color.White;
                    maskPeitoralAtual.BackColor = Color.White;
                    maskCinturaAtual.BackColor = Color.White;

                    //indicação de melhora ou piora nas medidas do aluno
                    progressoAluno();

                }
                catch (Exception)
                {

                    MessageBox.Show("Preencha todos os campos obrigatorios");
                }
            }
        }

        //metodo para Pesquisar no banco de dados as novas medidas
        public void pesquisarMedidasAluno(string cpf)
        {
            PessoaDAO pessoaDAO = new PessoaDAO();
            MedidasAluno medidas = new MedidasAluno();

            medidas = pessoaDAO.pesquisarMedidasAluno(cpf);

            if (medidas.cpf_aluno == cpf)
            {
                nascimento = medidas.nascimento;
                maskNascimento.Text = nascimento;

                idade_aluno = medidas.idade_atual;
                txtIdade.Text = idade_aluno.ToString();

                altura_atual = medidas.altura_atual;
                maskAlturaAtual.Text = altura_atual.ToString();

                peso_atual = medidas.peso_atual;
                maskPesoAtual.Text = peso_atual.ToString();

                ind_gordura = medidas.gordura_atual;
                maskPerc_GorduraAtual.Text = ind_gordura.ToString();

                imc = medidas.imc_atual;
                mask_Imc_Atual.Text = imc.ToString();

                situacao_atual = medidas.situacao_atual;
                txtSituacaoAtual.Text = situacao_atual;

                bicepis = medidas.bicepis_atual;
                maskBicepisAtual.Text = bicepis.ToString();

                anti_braco = medidas.anti_braco_atual;
                maskAnte_bracoAtual.Text = anti_braco.ToString();

                coxa = medidas.coxa_atual;
                maskCoxaAtual.Text = coxa.ToString();

                panturilha = medidas.panturilha_atual;
                maskPanturilhaAtual.Text = panturilha.ToString();

                peitoral = medidas.peitoral_atual;
                maskPeitoralAtual.Text = peitoral.ToString();

                cintura = medidas.cintura_atual;
                maskCinturaAtual.Text = cintura.ToString();

                contador = medidas.contador;
                sexo = medidas.sexo;

            }
        }

        private void btnAtualizarMedidas_Click(object sender, EventArgs e)
        {
            string pergunta1 = "Você calculou novamente o novo indice?";
            string pergunta2 = "Tem certeza que deseja alterar este cadastro?";
            string titulo = "ALTERAR CADASTRO";

            if (MessageBox.Show(pergunta1, titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show(pergunta2, titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MedidasAluno medidas = new MedidasAluno();
                    alterarMedidasAluno(medidas);
                }
                else
                {

                }
            }
            else
            {
            }
            
        }

        //metodo para alterar no banco de dados
        private void alterarMedidasAluno(MedidasAluno medidas)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            if (txtIdade.Text == "" || txtSituacaoAtual.Text.Trim() == "" || maskCinturaAtual.Mask == "0,00" || maskPeitoralAtual.Mask == "0,00" || maskPanturilhaAtual.Mask == "0,00"
                || maskCoxaAtual.Mask == "0,00" || maskAnte_bracoAtual.Mask == "0,00" || maskBicepisAtual.Mask == "0,00" || maskPesoAtual.Mask == "0,00" || maskNascimento.Mask == "00/00/0000")
            {
                MessageBox.Show("Existem campos obrigatorios sem preenchimento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskNascimento.BackColor = Color.Beige;
                maskPesoAtual.BackColor = Color.Beige;
                maskAlturaAtual.BackColor = Color.Beige;
                txtSituacaoAtual.BackColor = Color.Beige;
                txtIdade.BackColor = Color.Beige;
                maskBicepisAtual.BackColor = Color.Beige;
                maskAnte_bracoAtual.BackColor = Color.Beige;
                maskCoxaAtual.BackColor = Color.Beige;
                maskPanturilhaAtual.BackColor = Color.Beige;
                maskPeitoralAtual.BackColor = Color.Beige;
                maskCinturaAtual.BackColor = Color.Beige;
            }
            else
            {
                medidas.cpf_aluno = cpfAluno;
                medidas.nascimento = maskNascimento.Text;
                medidas.idade_atual = Convert.ToInt32(txtIdade.Text);
                medidas.altura_atual = (Convert.ToDouble(maskAlturaAtual.Text) / 100);
                medidas.peso_atual = (Convert.ToDouble(maskPesoAtual.Text) / 100);
                medidas.gordura_atual = (Convert.ToDouble(maskPerc_GorduraAtual.Text) / 100);
                medidas.imc_atual = (Convert.ToDouble(mask_Imc_Atual.Text) / 100);
                medidas.situacao_atual = txtSituacaoAtual.Text;
                medidas.bicepis_atual = (Convert.ToDouble(maskBicepisAtual.Text) / 100);
                medidas.anti_braco_atual = (Convert.ToDouble(maskAnte_bracoAtual.Text) / 100);
                medidas.coxa_atual = (Convert.ToDouble(maskCoxaAtual.Text) / 100);
                medidas.panturilha_atual = (Convert.ToDouble(maskPanturilhaAtual.Text) / 100);
                medidas.peitoral_atual = (Convert.ToDouble(maskPeitoralAtual.Text) / 100);
                medidas.cintura_atual = (Convert.ToDouble(maskCinturaAtual.Text) / 100);

                pessoaBLL.alterarMedidasAluno(medidas);

                MessageBox.Show("Medidas Alterada com Sucesso!");

                maskNascimento.BackColor = Color.White;
                maskPesoAtual.BackColor = Color.White;
                maskAlturaAtual.BackColor = Color.White;
                txtSituacaoAtual.BackColor = Color.White;
                txtIdade.BackColor = Color.White;
                maskBicepis.BackColor = Color.White;
                maskAnte_bracoAtual.BackColor = Color.White;
                maskCoxaAtual.BackColor = Color.White;
                maskPanturilhaAtual.BackColor = Color.White;
                maskPeitoralAtual.BackColor = Color.White;
                maskCinturaAtual.BackColor = Color.White;

                //indicação de melhora ou piora nas medidas do aluno
                progressoAluno();

            }

        }

        //metodo para Pesquisar se existe novas medidas no banco de dados
        public void existeNovasMedidasAluno(string cpf)
        {
            PessoaDAO pessoaDAO = new PessoaDAO();
            MedidasAluno medidas = new MedidasAluno();

            medidas = pessoaDAO.existeNovasMedidasAluno(cpf);

            contador_med = medidas.novas_med;

            if (contador_med == 1)
            {
                pesquisarMedidasAluno(cpfAluno);
            }
        }

        //metodo para Pesquisar se existe exercicio cadastrado no banco de dados
        public void existeExercicioAluno(string cpf)
        {
            PessoaDAO pessoaDAO = new PessoaDAO();
            Exercicios exercicios = new Exercicios();

            exercicios = pessoaDAO.existeExercicioAluno(cpf);

            contador_exer = exercicios.cad_exerc;

            if (contador_exer == 1)
            {
                btnExercicio.Enabled = true;
            }
        }

        private void ptbAlterarImagem_Click(object sender, EventArgs e)
        {
            string pergunta = "Tem certeza que deseja alterar a imagem de  cadastro?";
            string titulo = "ALTERAR IMAGEM CADASTRO";

            if (MessageBox.Show(pergunta, titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AlterarImagemAlunoPC();

                Pessoa pessoa = new Pessoa();
                AlterarImagemAluno(pessoa);
            }
        }

        //procurar a imagem no computador e converter para arrayde bytes[]
        public void AlterarImagemAlunoPC()
        {
            imagemAluno.setSelecionaImagem();

            string foto;

            foto = imagemAluno.getSelecionaImagem();
            pictureBox1.ImageLocation = foto;

            //envia endereço da foto para converter para array de bytes[]
            imagemAluno.ImagemPC(foto);

            //byte[] imagem_byte;
            imagemAluno_byte = imagemAluno.getImagemPC();
        }

        //metodo para alterar no banco de dados
        private void AlterarImagemAluno(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            
            //dados da imagem convertidos em bytes
            pessoa.img = imagemAluno_byte;
            pessoa.cpf = cpfAluno;

            pessoaBLL.AlterarImagemFuncionario(pessoa);

            MessageBox.Show("Imagem Alterada com Sucesso!");

        }
        /*Calendario
        ----------------------------------------------------------------------------------------------------------------------------------*/
        //Carrega o array com os botões da tela
        private void CarregarBotoes()
        {
            botos = new Button[]
            {
                buttonA1, buttonB1, buttonC1, buttonD1, buttonE1, buttonF1, buttonG1, buttonA2, buttonB2, buttonC2, buttonD2, buttonE2,
                buttonF2, buttonG2, buttonA3, buttonB3, buttonC3, buttonD3, buttonE3, buttonF3, buttonG3, buttonA4, buttonB4, buttonC4,
                buttonD4, buttonE4, buttonF4, buttonG4, buttonA5, buttonB5, buttonC5, buttonD5, buttonE5, buttonF5, buttonG5, buttonA6,
                buttonB6
            };
        }
        //Seta o primeiro dia na interface e na lista
        public void PainelPrimeiroDia()
        {
            switch (controle.primeiroDia())
            {
                case "Sunday":
                    this.dias[0] = 1;
                    break;
                case "Monday":
                    this.dias[1] = 1;
                    break;
                case "Tuesday":
                    this.dias[2] = 1;
                    break;
                case "Wednesday":
                    this.dias[3] = 1;
                    break;
                case "Thursday":
                    this.dias[4] = 1;
                    break;
                case "Friday":
                    this.dias[5] = 1;
                    break;
                case "Saturday":
                    this.dias[6] = 1;
                    break;
            }
        }
        //Seta o valor do segundo botão até o ultimo
        public void setValor()
        {
            if (dias[0] == 0)
            {
                botos[0].Visible = false;
            }

            for (int i = 1; i < 37; i++)
            {
                dias[i] = controle.botoes(dias[i - 1], dias[i], botos[i]);
            }
        }

        private void buttonA1_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[0] = controle.marcarPresenca(VcontroleBotoes[0], dias[0], botos[0]);
            dao.salvarBd("a1", VcontroleBotoes[0], cpfAluno);

            contadorPresenca();
        }

        private void buttonB1_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[1] = controle.marcarPresenca(VcontroleBotoes[1], dias[1], botos[1]);
            dao.salvarBd("b1", VcontroleBotoes[1], cpfAluno);

            contadorPresenca();
        }

        private void buttonC1_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[2] = controle.marcarPresenca(VcontroleBotoes[2], dias[2], botos[2]);
            dao.salvarBd("c1", VcontroleBotoes[2], cpfAluno);

            contadorPresenca();
        }

        private void buttonD1_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[3] = controle.marcarPresenca(VcontroleBotoes[3], dias[3], botos[3]);
            dao.salvarBd("d1", VcontroleBotoes[3], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonE1_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[4] = controle.marcarPresenca(VcontroleBotoes[4], dias[4], botos[4]);
            dao.salvarBd("e1", VcontroleBotoes[4], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonF1_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[5] = controle.marcarPresenca(VcontroleBotoes[5], dias[5], botos[5]);
            dao.salvarBd("f1", VcontroleBotoes[5], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonG1_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[6] = controle.marcarPresenca(VcontroleBotoes[6], dias[6], botos[6]);
            dao.salvarBd("g1", VcontroleBotoes[6], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonA2_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[7] = controle.marcarPresenca(VcontroleBotoes[7], dias[7], botos[7]);
            dao.salvarBd("a2", VcontroleBotoes[7], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonB2_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[8] = controle.marcarPresenca(VcontroleBotoes[8], dias[8], botos[8]);
            dao.salvarBd("b2", VcontroleBotoes[8], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonC2_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[9] = controle.marcarPresenca(VcontroleBotoes[9], dias[9], botos[9]);
            dao.salvarBd("c2", VcontroleBotoes[9], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonD2_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[10] = controle.marcarPresenca(VcontroleBotoes[10], dias[10], botos[10]);
            dao.salvarBd("d2", VcontroleBotoes[10], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonE2_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[11] = controle.marcarPresenca(VcontroleBotoes[11], dias[11], botos[11]);
            dao.salvarBd("e2", VcontroleBotoes[11], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonF2_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[12] = controle.marcarPresenca(VcontroleBotoes[12], dias[12], botos[12]);
            dao.salvarBd("f2", VcontroleBotoes[12], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonG2_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[13] = controle.marcarPresenca(VcontroleBotoes[13], dias[13], botos[13]);
            dao.salvarBd("g2", VcontroleBotoes[13], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonA3_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[14] = controle.marcarPresenca(VcontroleBotoes[14], dias[14], botos[14]);
            dao.salvarBd("a3", VcontroleBotoes[14], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonB3_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[15] = controle.marcarPresenca(VcontroleBotoes[15], dias[15], botos[15]);
            dao.salvarBd("b3", VcontroleBotoes[15], cpfAluno);

            verificarPresenca(cpfAluno);
        }  
        private void buttonC3_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[16] = controle.marcarPresenca(VcontroleBotoes[16], dias[16], botos[16]);
            dao.salvarBd("c3", VcontroleBotoes[16], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonD3_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[17] = controle.marcarPresenca(VcontroleBotoes[17], dias[17], botos[17]);
            dao.salvarBd("d3", VcontroleBotoes[17], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonE3_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[18] = controle.marcarPresenca(VcontroleBotoes[18], dias[18], botos[18]);
            dao.salvarBd("e3", VcontroleBotoes[18], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonF3_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[19] = controle.marcarPresenca(VcontroleBotoes[19], dias[19], botos[19]);
            dao.salvarBd("f3", VcontroleBotoes[19], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonG3_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[20] = controle.marcarPresenca(VcontroleBotoes[20], dias[20], botos[20]);
            dao.salvarBd("g3", VcontroleBotoes[20], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonA4_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[21] = controle.marcarPresenca(VcontroleBotoes[21], dias[21], botos[21]);
            dao.salvarBd("a4", VcontroleBotoes[21], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonB4_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[22] = controle.marcarPresenca(VcontroleBotoes[22], dias[22], botos[22]);
            dao.salvarBd("b4", VcontroleBotoes[22], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonC4_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[23] = controle.marcarPresenca(VcontroleBotoes[23], dias[23], botos[23]);
            dao.salvarBd("c4", VcontroleBotoes[23], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonD4_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[24] = controle.marcarPresenca(VcontroleBotoes[24], dias[24], botos[24]);
            dao.salvarBd("d4", VcontroleBotoes[24], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonE4_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[25] = controle.marcarPresenca(VcontroleBotoes[25], dias[25], botos[25]);
            dao.salvarBd("e4", VcontroleBotoes[25], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonF4_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[26] = controle.marcarPresenca(VcontroleBotoes[26], dias[26], botos[26]);
            dao.salvarBd("f4", VcontroleBotoes[26], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonG4_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[27] = controle.marcarPresenca(VcontroleBotoes[27], dias[27], botos[27]);
            dao.salvarBd("g4", VcontroleBotoes[27], cpfAluno);

            verificarPresenca(cpfAluno);
        }
    

        private void buttonA5_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[28] = controle.marcarPresenca(VcontroleBotoes[28], dias[28], botos[28]);
            dao.salvarBd("a5", VcontroleBotoes[28], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonB5_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[29] = controle.marcarPresenca(VcontroleBotoes[29], dias[29], botos[29]);
            dao.salvarBd("b5", VcontroleBotoes[29], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonC5_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[30] = controle.marcarPresenca(VcontroleBotoes[30], dias[30], botos[30]);
            dao.salvarBd("c5", VcontroleBotoes[30], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonD5_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[31] = controle.marcarPresenca(VcontroleBotoes[31], dias[31], botos[31]);
            dao.salvarBd("d5", VcontroleBotoes[31], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonE5_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[32] = controle.marcarPresenca(VcontroleBotoes[32], dias[32], botos[32]);
            dao.salvarBd("e5", VcontroleBotoes[32], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonF5_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[33] = controle.marcarPresenca(VcontroleBotoes[33], dias[33], botos[33]);
            dao.salvarBd("f5", VcontroleBotoes[33], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonG5_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[34] = controle.marcarPresenca(VcontroleBotoes[34], dias[34], botos[34]);
            dao.salvarBd("g5", VcontroleBotoes[34], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonA6_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[35] = controle.marcarPresenca(VcontroleBotoes[35], dias[35], botos[35]);
            dao.salvarBd("a6", VcontroleBotoes[35], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        private void buttonB6_Click(object sender, EventArgs e)
        {
            VcontroleBotoes[36] = controle.marcarPresenca(VcontroleBotoes[36], dias[36], botos[36]);
            dao.salvarBd("b6", VcontroleBotoes[36], cpfAluno);

            verificarPresenca(cpfAluno);
        }

        // ir para tela de alterar dados cadastrais
        private void ptbMenu_Click(object sender, EventArgs e)
        {
            panel25.Visible = true;
        }

        //Sair da area do aluno, volta tela login pelo Menu
        private void lbl_SairProg_Click(object sender, EventArgs e)
        {
            this.Dispose();
            janela.fecharJanela();
            panel25.Visible = false;
        }

        // ir para tela de alterar dados cadastrais pelo Menu
        private void lbl_AlterarCad_Click(object sender, EventArgs e)
        {
            RecuperarSenha recuperar = new RecuperarSenha(cpfAluno, tipo_user);
            recuperar.Show();
            panel25.Visible = false;
        }

        // fechar o painel de menu de opções
        private void lbl_FecharMenu_Click(object sender, EventArgs e)
        {
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

        /*------------------------------------------------------------------------------------------------*/

        public void progressoAluno()
        {
            if(maskPesoAtual.Text != null)
            {
                double sit = 0;
                double p1 = Convert.ToDouble(maskPesoInicial.Text);
                double p2 = Convert.ToDouble(maskPesoAtual.Text);

                sit = p1 - p2;

                double res = Math.Round(sit, 2) / 100;
                string resultado = res.ToString();

                if (p2 < p1)
                {
                    
                    lbl_sitPeso.Text = "Reduziu " + resultado.Replace(",", ".") + " Kg";
                    lbl_sitPeso.ForeColor = Color.Green;
                }
                if (p2 > p1)
                {
                    lbl_sitPeso.Text = "Aumentou " + resultado.Replace(",", ".").Replace("-"," ") + " Kg";
                    lbl_sitPeso.ForeColor = Color.OrangeRed;
                }
                if (p2 == p1)
                {
                    double r = Math.Round(p1, 2) / 100;
                    string resul = r.ToString();

                    lbl_sitPeso.Text = "Manteve " + resul.Replace(",", ".") + " Kg";
                    lbl_sitPeso.ForeColor = Color.Blue;
                }
            }

            if (maskPerc_GorduraAtual.Text != null)
            {
                double sit = 0;
                double p1 = Convert.ToDouble(maskPerc_GorduraInicial.Text);
                double p2 = Convert.ToDouble(maskPerc_GorduraAtual.Text);

                sit = p1 - p2;

                double res = Math.Round(sit, 2) / 100;
                string resultado = res.ToString();

                if (p2 < p1)
                {

                    lbl_sitGordura.Text = "Reduziu " + resultado.Replace(",", ".") + " %";
                    lbl_sitGordura.ForeColor = Color.Green;
                }
                if (p2 > p1)
                {
                    lbl_sitGordura.Text = "Aumentou " + resultado.Replace(",", ".").Replace("-", " ") + " %";
                    lbl_sitGordura.ForeColor = Color.OrangeRed;
                }
                if (p2 == p1)
                {
                    double r = Math.Round(p1, 2) / 100;
                    string resul = r.ToString();

                    lbl_sitGordura.Text = "Manteve " + resul.Replace(",", ".") + " %";
                    lbl_sitGordura.ForeColor = Color.Blue;
                }
            }

            if (mask_Imc_Atual.Text != null)
            {
                double sit = 0;
                double p1 = Convert.ToDouble(mask_Imc_Inicial.Text);
                double p2 = Convert.ToDouble(mask_Imc_Atual.Text);

                sit = p1 - p2;

                double res = Math.Round(sit, 2) / 100;
                string resultado = res.ToString();

                if (p2 < p1)
                {

                    lbl_sit_Imc.Text = "Reduziu " + resultado.Replace(",", ".") + " %";
                    lbl_sit_Imc.ForeColor = Color.Green;
                }
                if (p2 > p1)
                {
                    lbl_sit_Imc.Text = "Aumentou " + resultado.Replace(",", ".").Replace("-", " ") + " %";
                    lbl_sit_Imc.ForeColor = Color.OrangeRed;
                }
                if (p2 == p1)
                {
                    double r = Math.Round(p1, 2) / 100;
                    string resul = r.ToString();

                    lbl_sit_Imc.Text = "Manteve " + resul.Replace(",", ".") + " %";
                    lbl_sit_Imc.ForeColor = Color.Blue;
                }
            }

            if (maskBicepisAtual.Text != null)
            {
                double sit = 0;
                double p1 = Convert.ToDouble(maskBicepis.Text);
                double p2 = Convert.ToDouble(maskBicepisAtual.Text);

                sit = p1 - p2;

                double res = Math.Round(sit, 2) / 100;
                string resultado = res.ToString();

                if (p2 < p1)
                {

                    lbl_sitBicepis.Text = "Reduziu " + resultado.Replace(",", ".") + " cm";
                    lbl_sitBicepis.ForeColor = Color.Green;
                }
                if (p2 > p1)
                {
                    lbl_sitBicepis.Text = "Aumentou " + resultado.Replace(",", ".").Replace("-", " ") + " cm";
                    lbl_sitBicepis.ForeColor = Color.OrangeRed;
                }
                if (p2 == p1)
                {
                    double r = Math.Round(p1, 2) / 100;
                    string resul = r.ToString();

                    lbl_sitBicepis.Text = "Manteve " + resul.Replace(",", ".") + " cm";
                    lbl_sitBicepis.ForeColor = Color.Blue;
                }
            }

            if (maskAnte_bracoAtual.Text != null)
            {
                double sit = 0;
                double p1 = Convert.ToDouble(maskAnte_braco.Text);
                double p2 = Convert.ToDouble(maskAnte_bracoAtual.Text);

                sit = p1 - p2;

                double res = Math.Round(sit, 2) / 100;
                string resultado = res.ToString();

                if (p2 < p1)
                {

                    lbl_sitAnte_braco.Text = "Reduziu " + resultado.Replace(",", ".") + " cm";
                    lbl_sitAnte_braco.ForeColor = Color.Green;
                }
                if (p2 > p1)
                {
                    lbl_sitAnte_braco.Text = "Aumentou " + resultado.Replace(",", ".").Replace("-", " ") + " cm";
                    lbl_sitAnte_braco.ForeColor = Color.OrangeRed;
                }
                if (p2 == p1)
                {
                    double r = Math.Round(p1, 2) / 100;
                    string resul = r.ToString();

                    lbl_sitAnte_braco.Text = "Manteve " + resul.Replace(",", ".") + " cm";
                    lbl_sitAnte_braco.ForeColor = Color.Blue;
                }
            }

            if (maskCoxaAtual.Text != null)
            {
                double sit = 0;
                double p1 = Convert.ToDouble(maskCoxa.Text);
                double p2 = Convert.ToDouble(maskCoxaAtual.Text);

                sit = p1 - p2;

                double res = Math.Round(sit, 2) / 100;
                string resultado = res.ToString();

                if (p2 < p1)
                {

                    lbl_sitCoxa.Text = "Reduziu " + resultado.Replace(",", ".") + " cm";
                    lbl_sitCoxa.ForeColor = Color.Green;
                }
                if (p2 > p1)
                {
                    lbl_sitCoxa.Text = "Aumentou " + resultado.Replace(",", ".").Replace("-", " ") + " cm";
                    lbl_sitCoxa.ForeColor = Color.OrangeRed;
                }
                if (p2 == p1)
                {
                    double r = Math.Round(p1, 2) / 100;
                    string resul = r.ToString();

                    lbl_sitCoxa.Text = "Manteve " + resul.Replace(",", ".") + " cm";
                    lbl_sitCoxa.ForeColor = Color.Blue;
                }
            }

            if (maskPanturilhaAtual.Text != null)
            {
                double sit = 0;
                double p1 = Convert.ToDouble(maskPanturilha.Text);
                double p2 = Convert.ToDouble(maskPanturilhaAtual.Text);

                sit = p1 - p2;

                double res = Math.Round(sit, 2) / 100;
                string resultado = res.ToString();

                if (p2 < p1)
                {

                    lbl_sitPanturilha.Text = "Reduziu " + resultado.Replace(",", ".") + " cm";
                    lbl_sitPanturilha.ForeColor = Color.Green;
                }
                if (p2 > p1)
                {
                    lbl_sitPanturilha.Text = "Aumentou " + resultado.Replace(",", ".").Replace("-", " ") + " cm";
                    lbl_sitPanturilha.ForeColor = Color.OrangeRed;
                }
                if (p2 == p1)
                {
                    double r = Math.Round(p1, 2) / 100;
                    string resul = r.ToString();

                    lbl_sitPanturilha.Text = "Manteve " + resul.Replace(",", ".") + " cm";
                    lbl_sitPanturilha.ForeColor = Color.Blue;
                }
            }

            if (maskPeitoralAtual.Text != null)
            {
                double sit = 0;
                double p1 = Convert.ToDouble(maskPeitoral.Text);
                double p2 = Convert.ToDouble(maskPeitoralAtual.Text);

                sit = p1 - p2;

                double res = Math.Round(sit, 2) / 100;
                string resultado = res.ToString();

                if (p2 < p1)
                {

                    lbl_sitPeitoral.Text = "Reduziu " + resultado.Replace(",", ".") + " cm";
                    lbl_sitPeitoral.ForeColor = Color.Green;
                }
                if (p2 > p1)
                {
                    lbl_sitPeitoral.Text = "Aumentou " + resultado.Replace(",", ".").Replace("-", " ") + " cm";
                    lbl_sitPeitoral.ForeColor = Color.OrangeRed;
                }
                if (p2 == p1)
                {
                    double r = Math.Round(p1, 2) / 100;
                    string resul = r.ToString();

                    lbl_sitPeitoral.Text = "Manteve " + resul.Replace(",", ".") + " cm";
                    lbl_sitPeitoral.ForeColor = Color.Blue;
                }
            }

            if (maskCinturaAtual.Text != null)
            {
                double sit = 0;
                double p1 = Convert.ToDouble(maskCintura.Text);
                double p2 = Convert.ToDouble(maskCinturaAtual.Text);

                sit = p1 - p2;

                double res = Math.Round(sit, 2) / 100;
                string resultado = res.ToString();

                if (p2 < p1)
                {

                    lbl_sitCintura.Text = "Reduziu " + resultado.Replace(",", ".") + " cm";
                    lbl_sitCintura.ForeColor = Color.Green;
                }
                if (p2 > p1)
                {
                    lbl_sitCintura.Text = "Aumentou " + resultado.Replace(",", ".").Replace("-", " ") + " cm";
                    lbl_sitCintura.ForeColor = Color.OrangeRed;
                }
                if (p2 == p1)
                {
                    double r = Math.Round(p1, 2) / 100;
                    string resul = r.ToString();

                    lbl_sitCintura.Text = "Manteve " + resul.Replace(",", ".") + " cm";
                    lbl_sitCintura.ForeColor = Color.Blue;
                }
            }
        }

        //metodo para Pesquisar se o aluno marcou presença
        public void verificarPresenca(string c)
        {
            cpfAluno = c;

            Pessoa pessoa = new Pessoa();

            //ver se consegue melhorar o codigo de somar os valores no banco de dados
            pessoa = pessoaDAO.verificarPresenca(cpfAluno);

            contador = pessoa.presenca;

            //Barra de progresso do aluno por presenças
            contadorPresenca();

        }

    }
}
