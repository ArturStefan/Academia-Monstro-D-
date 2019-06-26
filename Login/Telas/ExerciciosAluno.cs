using Academia.Dao;
using Academia.model;
using Login.Model;
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
    public partial class ExerciciosAluno : Form
    {
        string aluno_cpf;
        
        public ExerciciosAluno(string cpf)
        {
            InitializeComponent();
            aluno_cpf = cpf;
            
        }

        public ExerciciosAluno()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ExerciciosAluno_Load(object sender, EventArgs e)
        {
            pesquisarExercicioAluno(aluno_cpf);

            buscarDicasExerciciosAluno();
        }

        //metodo para Pesquisar no banco de dados
        public void pesquisarExercicioAluno(string c)
        {
            PessoaDAO pessoaDAO = new PessoaDAO();
            Exercicios exercicios = new Exercicios();

            exercicios = pessoaDAO.pesquisarExercicioAluno(aluno_cpf);

            //exercicios = new PessoaDAO().pesquisarExercicioAluno(aluno_cpf);
            //Exercicios exercicios = new PessoaDAO().pesquisarExercicioAluno(aluno_cpf);

            if (exercicios.cpfAluno == aluno_cpf)
            {
                /*Segunda*/

                string seg01_exerc = "";
                seg01_exerc = exercicios.seg01_exerc;
                lblseg01_exerc.Text = seg01_exerc;

                int seg01_serie;
                seg01_serie = exercicios.seg01_serie;
                lblseg01_serie.Text = seg01_serie.ToString();

                double seg01_peso;
                seg01_peso = exercicios.seg01_peso;
                lblseg01_peso.Text = seg01_peso.ToString();

                string seg02_exerc = "";
                seg02_exerc = exercicios.seg02_exerc;
                lblseg02_exerc.Text = seg02_exerc;

                int seg02_serie;
                seg02_serie = exercicios.seg02_serie;
                lblseg02_serie.Text = seg02_serie.ToString();

                double seg02_peso;
                seg02_peso = exercicios.seg01_peso;
                lblseg02_peso.Text = seg02_peso.ToString();

                string seg03_exerc = "";
                seg03_exerc = exercicios.seg03_exerc;
                lblseg03_exerc.Text = seg03_exerc;

                int seg03_serie;
                seg03_serie = exercicios.seg03_serie;
                lblseg03_serie.Text = seg03_serie.ToString();

                double seg03_peso;
                seg03_peso = exercicios.seg03_peso;
                lblseg03_peso.Text = seg03_peso.ToString();

                /*Terça*/

                string ter01_exerc = "";
                ter01_exerc = exercicios.ter01_exerc;
                lblter01_exerc.Text = ter01_exerc;

                int ter01_serie;
                ter01_serie = exercicios.ter01_serie;
                lblter01_serie.Text = ter01_serie.ToString();

                double ter01_peso;
                ter01_peso = exercicios.ter01_peso;
                lblter01_peso.Text = ter01_peso.ToString();

                string ter02_exerc = "";
                ter02_exerc = exercicios.ter02_exerc;
                lblter02_exerc.Text = ter02_exerc;

                int ter02_serie;
                ter02_serie = exercicios.ter02_serie;
                lblter02_serie.Text = ter02_serie.ToString();

                double ter02_peso;
                ter02_peso = exercicios.ter01_peso;
                lblter02_peso.Text = ter02_peso.ToString();

                string ter03_exerc = "";
                ter03_exerc = exercicios.ter03_exerc;
                lblter03_exerc.Text = ter03_exerc;

                int ter03_serie;
                ter03_serie = exercicios.ter03_serie;
                lblter03_serie.Text = ter03_serie.ToString();

                double ter03_peso;
                ter03_peso = exercicios.ter03_peso;
                lblter03_peso.Text = ter03_peso.ToString();

                /*Quarta*/

                string qua01_exerc = "";
                qua01_exerc = exercicios.qua01_exerc;
                lblqua01_exerc.Text = qua01_exerc;

                int qua01_serie;
                qua01_serie = exercicios.qua01_serie;
                lblqua01_serie.Text = qua01_serie.ToString();

                double qua01_peso;
                qua01_peso = exercicios.qua01_peso;
                lblqua01_peso.Text = qua01_peso.ToString();

                string qua02_exerc = "";
                qua02_exerc = exercicios.qua02_exerc;
                lblqua02_exerc.Text = qua02_exerc;

                int qua02_serie;
                qua02_serie = exercicios.qua02_serie;
                lblqua02_serie.Text = qua02_serie.ToString();

                double qua02_peso;
                qua02_peso = exercicios.qua01_peso;
                lblqua02_peso.Text = qua02_peso.ToString();

                string qua03_exerc = "";
                qua03_exerc = exercicios.qua03_exerc;
                lblqua03_exerc.Text = qua03_exerc;

                int qua03_serie;
                qua03_serie = exercicios.qua03_serie;
                lblqua03_serie.Text = qua03_serie.ToString();

                double qua03_peso;
                qua03_peso = exercicios.qua03_peso;
                lblqua03_peso.Text = qua03_peso.ToString();

                /*Quinta*/

                string qui01_exerc = "";
                qui01_exerc = exercicios.qui01_exerc;
                lblqui01_exerc.Text = qui01_exerc;

                int qui01_serie;
                qui01_serie = exercicios.qui01_serie;
                lblqui01_serie.Text = qui01_serie.ToString();

                double qui01_peso;
                qui01_peso = exercicios.qui01_peso;
                lblqui01_peso.Text = qui01_peso.ToString();

                string qui02_exerc = "";
                qui02_exerc = exercicios.qui02_exerc;
                lblqui02_exerc.Text = qui02_exerc;

                int qui02_serie;
                qui02_serie = exercicios.qui02_serie;
                lblqui02_serie.Text = qui02_serie.ToString();

                double qui02_peso;
                qui02_peso = exercicios.qui01_peso;
                lblqui02_peso.Text = qui02_peso.ToString();

                string qui03_exerc = "";
                qui03_exerc = exercicios.qui03_exerc;
                lblqui03_exerc.Text = qui03_exerc;

                int qui03_serie;
                qui03_serie = exercicios.qui03_serie;
                lblqui03_serie.Text = qui03_serie.ToString();

                double qui03_peso;
                qui03_peso = exercicios.qui03_peso;
                lblqui03_peso.Text = qui03_peso.ToString();

                /*Sexta*/

                string sex01_exerc = "";
                sex01_exerc = exercicios.sex01_exerc;
                lblsex01_exerc.Text = sex01_exerc;

                int sex01_serie;
                sex01_serie = exercicios.sex01_serie;
                lblSex01_serie.Text = sex01_serie.ToString();

                double sex01_peso;
                sex01_peso = exercicios.sex01_peso;
                lblsex01_peso.Text = sex01_peso.ToString();

                string sex02_exerc = "";
                sex02_exerc = exercicios.sex02_exerc;
                lblsex02_exerc.Text = sex02_exerc;

                int sex02_serie;
                sex02_serie = exercicios.sex02_serie;
                lblsex02_serie.Text = sex02_serie.ToString();

                double sex02_peso;
                sex02_peso = exercicios.sex01_peso;
                lblsex02_peso.Text = sex02_peso.ToString();

                string sex03_exerc = "";
                sex03_exerc = exercicios.sex03_exerc;
                lblsex03_exerc.Text = sex03_exerc;

                int sex03_serie;
                sex03_serie = exercicios.sex03_serie;
                lblsex03_serie.Text = sex03_serie.ToString();

                double sex03_peso;
                sex03_peso = exercicios.sex03_peso;
                lblsex03_peso.Text = sex03_peso.ToString();

                /*Sabado*/

                string sab01_exerc = "";
                sab01_exerc = exercicios.sab01_exerc;
                lblsab01_exerc.Text = sab01_exerc;

                int sab01_serie;
                sab01_serie = exercicios.sab01_serie;
                lblsab01_serie.Text = sab01_serie.ToString();

                double sab01_peso;
                sab01_peso = exercicios.sab01_peso;
                lblsab01_peso.Text = sab01_peso.ToString();

                string sab02_exerc = "";
                sab02_exerc = exercicios.sab02_exerc;
                lblsab02_exerc.Text = sab02_exerc;

                int sab02_serie;
                sab02_serie = exercicios.sab02_serie;
                lblsab02_serie.Text = sab02_serie.ToString();

                double sab02_peso;
                sab02_peso = exercicios.sab01_peso;
                lblsab02_peso.Text = sab02_peso.ToString();

                string sab03_exerc = "";
                sab03_exerc = exercicios.sab03_exerc;
                lblsab03_exerc.Text = sab03_exerc;

                int sab03_serie;
                sab03_serie = exercicios.sab03_serie;
                lblsab03_serie.Text = sab03_serie.ToString();

                double sab03_peso;
                sab03_peso = exercicios.sab03_peso;
                lblsab03_peso.Text = sab03_peso.ToString();

            }
            else
            {
                MessageBox.Show("Não Existe exercicio cadastrado" +
                    " para este aluno!");
            }

        }

        public void buscarDicasExerciciosAluno()
        {
            PessoaDAO pessoaDAO = new PessoaDAO();
            Exercicios exercicios = new Exercicios();

            exercicios = pessoaDAO.buscarDicasExerciciosAluno();

            string dicas;
            dicas = exercicios.dicas_exerc_aluno;
            txtDicas.Text = dicas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscarDicasExerciciosAluno();
        }
    }

}
