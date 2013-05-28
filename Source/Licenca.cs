using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace AmbienteRPB
{
    public partial class Licenca : Form
    {
        GerenArquivos Arquivos;
        public int StatusRegistro
        {
            get;
            set;
        }
        public Licenca()
        {
            InitializeComponent();
            Arquivos = new GerenArquivos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StatusRegistro = 0;
            MessageBox.Show("Software não registrado",
               "Reconhecimento Automatizado de Padrões em EEG",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.ToString() != "" && txtName.Text.ToString() != "" && txtSerial.Text.ToString() != "")
            {
                if (txtSerial.Text.ToString() == "utfpr2013")
                {
                    Arquivos.CriarLicenca(txtName.Text.ToString(), txtEmail.Text.ToString(), txtSerial.Text.ToString());
                    StatusRegistro = 1;
                   /* try
                    {//Envia para o servidor os dados.
                            string dir = Arquivos.getPathUser() + "RegSW.lic";
                            FileStream stream = File.OpenRead(dir);
                            byte[] buffer = new byte[stream.Length];
                            stream.Read(buffer, 0, buffer.Length);
                            Uri uri = new Uri("ftp://ftp.novoindustrial.com.br/RegSW.lic-" + txtName.Text.ToString() + ".txt"); 
                            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(uri);
                            request.Credentials = new NetworkCredential("userEEG", "engcomp@utfpr2013");
                            request.KeepAlive = false;
                            request.Method = WebRequestMethods.Ftp.UploadFile;
                            request.UseBinary = true;
                            request.ContentLength = buffer.Length;
                            Stream strm = request.GetRequestStream();
                            strm.Write(buffer, 0, buffer.Length);
                            strm.Close();
                            stream.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Nao envio para o server!",
                            "Reconhecimento Automatizado de Padrões em EEG",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }*/
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Serial Key inválido!",
                             "Reconhecimento Automatizado de Padrões em EEG",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StatusRegistro = 0;
                }
            }
        }

      
    }
}
