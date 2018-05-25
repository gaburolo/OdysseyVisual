using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{
    public partial class EditarInfo : Form
    {
        public EditarInfo()
        {
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
                MessageBox.Show("Editando: " + "Tipo: "+ Search+" Nuevo Valor: "+TextEdi);



                this.Close();
            }
        }
    }
}
