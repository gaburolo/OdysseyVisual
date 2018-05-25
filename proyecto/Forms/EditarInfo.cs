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
namespace proyecto
{
    public partial class EditarInfo : Form
    {
        Client client;
        String cancion, artista;
        
        public EditarInfo(Client client, String cancion, String artista)
        {
            this.client = client;
            this.cancion = cancion;
            this.artista = artista;
            InitializeComponent();
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (ComBoxEditar.Text == "")
            {
                MessageBox.Show("Debe ingresar un tipo para poder editar", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (BoxEditar.Text == "")
            {
                MessageBox.Show("Debe ingresar texto para poder editar", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String Search = ComBoxEditar.Text;
                String TextEdi = BoxEditar.Text;
                
                client.SetMetadataMessage(Search, cancion, artista, TextEdi);
                MessageBox.Show("Editando: " + "Tipo: " + Search + " Nuevo Valor: " + TextEdi);

                this.Close();
            }
        }
    }
}
