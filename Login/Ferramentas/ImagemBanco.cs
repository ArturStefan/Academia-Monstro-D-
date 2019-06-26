using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.Ferramentas
{
    public class ImagemBanco
    {
        private string imagem;

        //guarda o endereço da imagem
        private string endImagem;
        private string modelo_imagem;

        //transformar a imagem em um array de bytes
        private byte[] imagem_byte = null;

        public void setSelecionaImagem()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files(*.jpg)|*.jpg | PNG Files(*.png)*|.png | AllFiles(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foto = dialog.FileName.ToString();
                endImagem = foto;
            }
        }

        public string getSelecionaImagem()
        {
            return endImagem;
        }

        public void ImagemPC(string img)
        {
            imagem = endImagem;

            modelo_imagem = img;

            if (imagem != null)
            {
                //tranforma em binario da imagem
                FileStream filestream = new FileStream(this.imagem, FileMode.Open, FileAccess.Read);


                //ler os dados binarios da imagem
                BinaryReader binaryreader = new BinaryReader(filestream);

                //pega os tamanho dos dados binarios da imagem em tipo inteiro e guarda na variavel imagem_byte
                imagem_byte = binaryreader.ReadBytes((int)filestream.Length);
            }
            else
            {
                //tranforma em binario da imagem
                FileStream filestream = new FileStream(this.modelo_imagem, FileMode.Open, FileAccess.Read);


                //ler os dados binarios da imagem
                BinaryReader binaryreader = new BinaryReader(filestream);

                //pega os tamanho dos dados binarios da imagem em tipo inteiro e guarda na variavel imagem_byte
                imagem_byte = binaryreader.ReadBytes((int)filestream.Length);
            }

        }

        public byte[] getImagemPC()
        {
            return imagem_byte;
        }
    }
}
