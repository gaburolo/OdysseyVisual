using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using proyecto.Cliente;

namespace proyecto
{
    public partial class Form2 : Form
    {
        //Variables clase form2 -Login
        private Client client;
        /// <summary>
        /// Constructor de la clase Login 
        /// </summary>
        /// <param name="client"></param>Client
        public Form2(Client client)
        {
            this.client = client;
            InitializeComponent();
        }

        /// <summary>
        /// Evento del boton Ingresar
        /// Enviar los datos de las boxtext al server y comprueba si el usuario existe 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            String Usuario = BoxUsuario.Text;
            String Contra = BoxContra.Text;

            client.LogInMessage(Usuario, Contra);

            XmlDocument response = client.GetMessage();

            String opcode = response.SelectSingleNode("Message/opcode").InnerText;

            if (opcode.Equals("003"))
            {
                this.Close();
                Form1 frm = new Form1(client);
                frm.Show();            
            }
            else if (opcode.Equals("002"))
            {
                String data = response.SelectSingleNode("Message/Data/info").InnerText;
                MessageBox.Show(data, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Evento del boton registro
        /// Abre una nueva ventana de registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3(client);
            frm.Show();
            this.Close();
        }
    }
}
