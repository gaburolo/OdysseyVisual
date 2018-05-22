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

namespace proyecto
{
    public partial class Form1 : Form
    {
        private Client client;
        // BTN = BOTON
        List<byte[]> canciones = new List<byte[]>();
        string nombreCancion;
        private string path = "";

        ListViewItem itm;

        int i = 0;
        private WaveOut waveOut;

        public Form1(Client client)
        {
            this.client = client;
            InitializeComponent();
        }

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

                        //using (myStream)
                        //{
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
                       
                        //string ruta = @"C:\Users\USUARIO\Desktop\AQUIBytes.txt";//donde se guarda los bytes
                        var bytes = File.ReadAllBytes(path);//toma los bytes del archivo en ruta "direccion"
                        nombreCancion = openFileDialog1.SafeFileName;//Obtine el nombre del archivo
                        itm = new ListViewItem(nombreCancion);//
                        itm.SubItems.Add("Linkin Park");/// Agregar datos a un la columna
                        itm.SubItems.Add("Hybrid Theory");
                        itm.SubItems.Add("2000");
                        itm.SubItems.Add("183.6");
                        listView1.Items.Add(itm);                         
                        canciones.Add(bytes);

                        String titulo = listView1.SelectedItems[i].SubItems[0].Text;
                        String artista = listView1.SelectedItems[i].SubItems[1].Text;
                               
                            
                                //string i = BitConverter.ToString(bytes);//Convierte los bytes en String
                                //long i = BitConverter.ToInt64(bytes, 0);//Covierte los bytes a enteros en formato 64



                                //Guardar datos en txt
                                /*using (StreamWriter logs = File.AppendText(ruta))
                                {
                                    logs.Write("  ");
                                    logs.Write("Con var: "+i);
                                    logs.Write(" Stream: " + myStream.Read(fileBytes, 0, fileBytes.Length));
                                    logs.Close();
                                }*/




                          //  }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }


        }



        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            String BuscarTexto = BoxBuscar.Text;
            String BuscarCategoria = BoxCategorias.Text;// Usa el dato que se elija

            client.SearchSongMessage("Artista", BuscarTexto);

            XmlDocument response = client.GetMessage();

            String opcode = response.SelectSingleNode("Message/opcode").InnerText;

            if (opcode.Equals("008"))
            {
                XmlNodeList nodeList = response.SelectNodes("Message/Data");

                foreach (XmlNode nodes in nodeList)
                {
                    listView1.Items.Clear();

                    itm = new ListViewItem(nodes.SelectSingleNode("titulo").InnerText);//
                    itm.SubItems.Add(nodes.SelectSingleNode("artista").InnerText);/// Agregar datos a un la columna
                    itm.SubItems.Add(nodes.SelectSingleNode("album").InnerText);
                    itm.SubItems.Add("2000");
                    itm.SubItems.Add("183.6");
                    listView1.Items.Add(itm);  

                    //String read = nodes.SelectSingleNode("titulo").InnerText;
                    //String read2 = nodes.SelectSingleNode("album").InnerText;
                    //Console.WriteLine("Titulo: " + read);
                    //Console.WriteLine("Album: " + read2);
                }
            }
            else if (opcode.Equals("002")){
                MessageBox.Show("Debe ingresar un tipo para la busqueda", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReproducir_Click(object sender, EventArgs e)
        {
            //String artista = "", cancion = "";

            //obtiene cancion seleccionado
            String cancion = listView1.SelectedItems[i].SubItems[0].Text;
            //obtiene artista seleccionado
            String artista = listView1.SelectedItems[i].SubItems[1].Text;

            client.PlaySongMessage(cancion, artista);

            XmlDocument response = client.GetMessage();
            String opcode = response.SelectSingleNode("Message/opcode").InnerText;

            if (opcode.Equals("004"))
            {
                String bytes = response.SelectSingleNode("Message/Data/bytes").InnerText;

                byte[] toStream = Convert.FromBase64String(bytes);
                PlaySong(toStream);
            }

            var rd = new Mp3FileReader(path);
            waveOut = new WaveOut();
            waveOut.Init(rd);
            waveOut.Play();
        }

        private void BtnPausa_Click(object sender, EventArgs e)
        {

            waveOut.Stop();
            
        }

        private void ListaCanciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)////DEvuelve el INDICE de la posicion que se selecciono 
            {
                ListViewItem lv = listView1.SelectedItems[0];
                i = lv.Index;               
                byte[] cancion = canciones[i];
                
            }  
        }

        private void PlaySong(byte[] mp3Array)
        {
            //byte[] copy = File.ReadAllBytes("torero.mp3");
            //TagLib.File file = TagLib.File.Create("torero.mp3");
            //Console.WriteLine(file.Tag.Title);
            //Console.WriteLine(file.Tag.Album);

            using (var mp3Stream = new MemoryStream(mp3Array))
            {
                using (var mp3FileReader = new Mp3FileReader(mp3Stream))
                {
                    using (var wave32 = new WaveChannel32(mp3FileReader, 0.1f, 1f))
                    {
                        using (var ds = new DirectSoundOut())
                        {
                            ds.Init(wave32);
                            ds.Play();
                            Thread.Sleep(30000 * 5);
                        }
                    }
                }

            }
        }

        private void Column_Click(object sender, ColumnClickEventArgs e)
        {
            if (e.Column.ToString() == "0")
            {

            }
            else if(e.Column.ToString() == "1")
            {

            }
            else if (e.Column.ToString() == "2")
            {

            }
        }
    }
}
    