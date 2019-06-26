using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.Ferramentas
{
    public class FecharJanela
    {
        public void fecharJanela()
        {
            //se não tiver outro formulario abre fecha o sistema.
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
            else
            {
                //se tiver algum formulario aberto, ver qual é este formulario
                foreach (Form FormularioAberto in Application.OpenForms)
                {
                    //se o formulario aberto for o form1, ao apertar o X,ele fecha a tela atual e abre o form1
                    if (FormularioAberto is Login)
                    {

                        FormularioAberto.Show();
                        break;
                    }
                }
            }
        }

        public void fecharJanelaAluno()
        {
            //se não tiver outro formulario abre fecha o sistema.
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
            else
            {
                //se não tiver outro formulario abre fecha o sistema.
                if (Application.OpenForms.Count == 2)
                {
                    //se tiver algum formulario aberto, ver qual é este formulario
                    foreach (Form FormularioAberto in Application.OpenForms)
                    {
                        //se o formulario aberto for o form1, ao apertar o X,ele fecha a tela atual e abre o form1
                        if (FormularioAberto is PaginaInicial)
                        {

                            FormularioAberto.Show();
                            break;
                        }
                    }
                }

            }
        }
    }
}
