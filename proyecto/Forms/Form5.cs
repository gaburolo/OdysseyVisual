using proyecto.Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto.Forms
{
    public partial class Letra : Form
    {

        //Variables de la clase
        String letra;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="client"></param>
        public Letra(Client client, String letra)
        {
            this.letra = letra;
            InitializeComponent();
        }
        /// <summary>
        /// Muestra la letra de la cancion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Letra_Load(object sender, EventArgs e)
        {
            textBox1.Text = (letra);
        }
    }
}
