using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using NAudio.Wave;
using proyecto.Cliente;
using proyecto.Forms;

namespace proyecto
{
    public partial class Reproductor : Form
    {   
        //Variables de la clase Reproductor
        private Client client;
        private String cancion, artista;
        private byte[] toStream;
        private DirectSoundOut ds;
        private string duracion;
        private int duracionInt;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="client"></param> Client
        /// <param name="cancion"></param>String con el nombre de la cancion
        /// <param name="artista"></param>String con el nombre del artista
        /// <param name="duracion"></param> String con la duracion de la cancion
        public Reproductor(Client client, String cancion, String artista, string duracion)
        {
            
            this.client = client;
            this.cancion = cancion;
            this.artista = artista;
            this.duracion = duracion;
            duracionInt = Convert.ToInt32(double.Parse(duracion));
            InitializeComponent();
            Reproducir();



        }
          
        /// <summary>
        /// Evento del boton play
        /// Reanuda la cancion desde donde se haya detenido
        /// Reanuda el timer donde se detuvo
        /// </summary>
        private void Play_Click(object sender, EventArgs e)
        {
            timer1.Start();
            ds.Play();

        }
        
        /// <summary>
        /// Reproduce la cancion
        /// </summary>
        private void PlaySong()
        {

            using (var mp3Stream = new MemoryStream(toStream))
            {
                using (var mp3FileReader = new Mp3FileReader(mp3Stream))
                {
                    using (var wave32 = new WaveChannel32(mp3FileReader, 0.1f, 1f))
                    {
                        ds = new DirectSoundOut();
                        ds.Init(wave32);
                        ds.Play();

                        Thread.Sleep(-1);
                        
                    }
                }
            }
        }


        /// <summary>
        /// Evento del boton stop
        /// Detiene la reproduccion de la cancion 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            ds.Pause();
        }



        /// <summary>
        /// Envia al server los datos de las cancion
        /// Reproduce la cancion deseada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reproducir()
        {
            duracionM.Text = duracionInt.ToString();
            client.PlaySongMessage(cancion, artista);



            XmlDocument response = client.GetMessage();

            //Quitar cargando

            String opcode = response.SelectSingleNode("Message/opcode").InnerText;

            if (opcode.Equals("004"))
            {
                String bytes = response.SelectSingleNode("Message/Data/bytes").InnerText;

                toStream = Convert.FromBase64String(bytes);

                Thread t = new Thread(new ThreadStart(PlaySong));
                t.Start();
                Console.Read();

                Thread t2 = new Thread(new ThreadStart(UpdateBar));
                t2.Start();
                Console.Read();

            }
        }




        /// <summary>
        /// ///Inicia el contrador del timer
        ///Agrega los valores a la barra de progreso
        ///Detiene el timer al llegar al maximo de la barra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            BarraProgreso.Value += 1;
            if (BarraProgreso.Value == BarraProgreso.Maximum)
            {
                timer1.Stop();
            }
            label1.Text = BarraProgreso.Value.ToString();
        }

        /// <summary>
        /// Detiene la reproduccion de la cancion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void CloseRepro(object sender, FormClosedEventArgs e)
        {
            ds.Stop();
            
        }
       
        /// <summary>
        /// Abre la letra de la cancion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void letra_Click(object sender, EventArgs e)
        {
            Letra letra = new Letra(client);
            letra.Show();
        }

        
        /// <summary>
        /// Le da un maxico a la barra de duracion
        /// Inicia el relog
        /// </summary>
        private void UpdateBar()
        {
            
            
            BarraProgreso.Maximum =duracionInt;


            timer1.Start();
            
          

        }
    }
}
