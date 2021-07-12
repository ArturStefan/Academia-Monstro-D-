using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
//teste de fork
namespace Academia
{
    public class Conexao
    {
        string conectar = "" +
            "server = localhost;" +
            "port = 3306;" +
            "database = AcademiaMostro;" +
            "user = root;" +
            "password = ''";

        protected MySqlConnection conexao = null;

        public Conexao()
        {

        }

        public void AbrirConexao()
        {
            try
            {
                conexao = new MySqlConnection(conectar);
                conexao.Open();
            }
            catch (Exception erro)
            {
                //throw erro;
                MessageBox.Show("Erro ao conectar com o banco de dados");
            }
            
        }

        public void FecharConexao()
        {
            try
            {
                conexao = new MySqlConnection(conectar);
                conexao.Close();
            }
            catch (Exception erro)
            {
                //throw erro;
                MessageBox.Show("Erro ao fechar a conexão com o banco de dados");
            }
           
        }

    }
}
