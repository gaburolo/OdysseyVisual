using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyecto.Cliente;
using System.Xml;

namespace proyecto
{
    public partial class Form3 : Form
    {
        //Variables clase Form3-Registro
        private Client client;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="client"></param>Client
        public Form3(Client client)
        {
            this.client = client;
            InitializeComponent();
        }

        /// <summary>
        /// Evento de la clase Registrar
        /// Envia todos los datos de los boxtex al servidor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            String NomUsuario = BoxNomUsuario.Text;
            String Nombre = BoxNombre.Text;
            String Apellido = BoxApellidos.Text;
            String Edad = BoxEdad.Text;
            String Generos = BoxGenero.Text;
            String password = BoxContrase.Text;

            client.SignInMessage(NomUsuario, Nombre, Apellido, Edad, password);

            XmlDocument response = client.GetMessage();

            String opcode = response.SelectSingleNode("Message/opcode").InnerText;

            if (opcode.Equals("003"))
            {
                String data = response.SelectSingleNode("Message/Data/info").InnerText;
                MessageBox.Show(data, "Resgistro");

                Form2 frm = new Form2(client);
                frm.Show();
                this.Close();
            } 
            else if (opcode.Equals("002"))
            {
                String data = response.SelectSingleNode("Message/Data/info").InnerText;
                MessageBox.Show(data, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento al cerrar la ventana
        /// Abre una nueva ventana login al cerrar la actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseRegis(object sender, FormClosingEventArgs e)
        {
            Form2 frm = new Form2(client);
            frm.Show();
        }
    }
}
