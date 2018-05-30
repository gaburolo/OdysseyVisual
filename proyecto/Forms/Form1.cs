using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;
using proyecto.Cliente;
using System.Globalization;

namespace proyecto
{
    public partial class Form1 : Form
    {
        //Variables de la Clase Form1 - Pantalla Principal
        private int cont = 0;
        private Client client;
        private string path = "";
        ListViewItem itm;
        private int i = 0;
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="client"></param>Cliente
        public Form1(Client client)
        {
            this.client = client;
            InitializeComponent();
        }

        /// <summary>
        /// Evento del boton agregar
        /// Abre el explorador de archivos
        /// Seleccione y envia al servidor la cancion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "mp3 files (*.mp3)|*.mp3";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        path = openFileDialog1.FileName;//Se obtiene la direccion
                        client.SendSongMessage(path);
                        XmlDocument response = client.GetMessage();

                        String opcode = response.SelectSingleNode("Message/opcode").InnerText;

                        if (opcode.Equals("006"))
                        {
                            MessageBox.Show("Cancion guardada con exito", "Mensaje");
                        }
                        else if (opcode.Equals("002"))
                        {
                            MessageBox.Show("Cancion ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        byte[] fileBytes = new byte[myStream.Length];//tomar los bytes del archivo abierto "myStream"
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }


        }


        /// <summary>
        ///  Evento del boton salir
        ///  Cierra la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Evento del boton Buscar
        /// Enviar al servidor los datos de busqueda y esta devuelve las canciones con las caracteristicas deceadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            cont = 0;
            String BuscarTexto = BoxBuscar.Text;
            String BuscarCategoria = BoxCategorias.Text;// Usa el dato que se elija

            client.SearchSongMessage(BuscarCategoria, BuscarTexto);

            XmlDocument response = client.GetMessage();

            String opcode = response.SelectSingleNode("Message/opcode").InnerText;

            if (opcode.Equals("008"))
            {
                XmlNodeList nodeList = response.SelectNodes("Message/Data");
                listView1.Items.Clear();
                
                foreach (XmlNode nodes in nodeList)
                {
                    //                    

                    itm = new ListViewItem(nodes.SelectSingleNode("titulo").InnerText);//
                    itm.SubItems.Add(nodes.SelectSingleNode("artista").InnerText);/// Agregar datos a un la columna
                    itm.SubItems.Add(nodes.SelectSingleNode("album").InnerText);
                    itm.SubItems.Add(nodes.SelectSingleNode("year").InnerText);
                    itm.SubItems.Add(nodes.SelectSingleNode("duracion").InnerText);
                    listView1.Items.Add(itm);

                    
                    

                }
            }
            else if (opcode.Equals("002")){
                MessageBox.Show("Debe ingresar un tipo para la busqueda", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Evento del boton reproducir
        /// Envia al servidor la cancion desea y esta devuelve los bytes de la cancion
        /// Abre una nueva ventana de reproductor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReproducir_Click(object sender, EventArgs e)
        {
            if (cont == 0)
            {
                MessageBox.Show("Debe elegir una cancion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
            //obtiene cancion seleccionado
            String cancion = listView1.Items[i].SubItems[0].Text;
            //obtiene artista seleccionado
            String artista = listView1.Items[i].SubItems[1].Text;
            double duracion =double.Parse(listView1.Items[i].SubItems[4].Text, CultureInfo.InvariantCulture);
            Reproductor reproducir = new Reproductor(client, cancion, artista,duracion);
            reproducir.Show();

            }

        }

        /// <summary>
        /// Evento de la listview
        /// Nos da el indice de la cancion que selecionamos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListaCanciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listView1.SelectedItems.Count > 0)////DEvuelve el INDICE de la posicion que se selecciono 
            {
                ListViewItem lv = listView1.SelectedItems[0];
                i = lv.Index;
                cont = 1;
               

            }
        }

        /// <summary>
        ///  Evento de las columnas de la listview
        ///  Envia al server el dato con el cual desea ordenar las canciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Column_Click(object sender, ColumnClickEventArgs e)
        {
            int t = 0;
            int a = 0;
            String[,] datos = new String[listView1.Items.Count, 5];
            string dato;
            while (t != listView1.Items.Count)
            {
                while (a != 5)
                {
                    dato = listView1.Items[t].SubItems[a].Text;
                    datos[t,a] = dato;
                    a++;
                }
                a = 0;
                t++;
            }

            if (e.Column.ToString() == "0")//Nombre Cancion
            {
                client.SortListMessage(datos, "Titulo");
            }
            else if(e.Column.ToString() == "1")//Artista
            {
                client.SortListMessage(datos, "Artista");
            }
            else if (e.Column.ToString() == "2")//Album
            {
                client.SortListMessage(datos, "Album");
            }

            XmlDocument response = client.GetMessage();

            String opcode = response.SelectSingleNode("Message/opcode").InnerText;

            if (opcode.Equals("008"))
            {
                XmlNodeList nodeList = response.SelectNodes("Message/Data");
                listView1.Items.Clear();

                foreach (XmlNode nodes in nodeList)
                {
                    itm = new ListViewItem(nodes.SelectSingleNode("titulo").InnerText);//
                    itm.SubItems.Add(nodes.SelectSingleNode("artista").InnerText);/// Agregar datos a un la columna
                    itm.SubItems.Add(nodes.SelectSingleNode("album").InnerText);
                    itm.SubItems.Add(nodes.SelectSingleNode("year").InnerText);
                    itm.SubItems.Add(nodes.SelectSingleNode("duracion").InnerText);
                    listView1.Items.Add(itm);
                }
            }
        }

        /// <summary>
        /// Evento del boton de Agregarinfo
        /// Toma los datos de la cancion selecciona
        /// abre la venta de agregar info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarInfo_Click(object sender, EventArgs e)
        {
            if (cont ==0)
            {
                MessageBox.Show("Debe elegir una cancion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //obtiene cancion seleccionado
                String cancion = listView1.Items[i].SubItems[0].Text;
                //obtiene artista seleccionado
                String artista = listView1.Items[i].SubItems[1].Text;
                EditarInfo editarInfo = new EditarInfo(client,cancion,artista);
                editarInfo.Show();
            }

        }

        /// <summary>
        /// Evento del boton eliminar
        /// Toma los datos de la cancion selecciona
        /// envia al server el codigo para eliminar dicha cancion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (cont == 0)
            {
                MessageBox.Show("Debe elegir una cancion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //obtiene cancion seleccionado
                String cancion = listView1.Items[i].SubItems[0].Text;
                //obtiene artista seleccionado
                String artista = listView1.Items[i].SubItems[1].Text;
                String album = listView1.Items[i].SubItems[2].Text;
                client.DeleteSongMessage(cancion, artista, album);
                listView1.Items[i].Remove();
            }   
        }

        
    }
}
    