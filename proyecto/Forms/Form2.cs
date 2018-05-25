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
        private Client client;

        public Form2(Client client)
        {
            this.client = client;
            InitializeComponent();
        }

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



            //if (Usuario.Equals(usuario))
            //{
            //    if (Contra.Equals(contraseña))
            //    {
            //        this.Close();
            //        Form1 frm = new Form1(client);
            //        frm.Show();
                    
                    
            //    }
            //    else
            //    {
            //        MessageBox.Show("Contraseña Incorrecta");
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Usuario o Contraseña Incorrecta");
            //}
            
            
        }

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3(client);
            frm.Show();
            this.Close();
        }
    }
}
