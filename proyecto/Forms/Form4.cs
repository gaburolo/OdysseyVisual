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
        private Client client;
        private String cancion, artista;
        private byte[] toStream;
        private DirectSoundOut ds;
        private string duracion;
        private int duracionInt;

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
        private void Play_Click(object sender, EventArgs e)
        {
            timer1.Start();
            ds.Play();

        }
        private void PlaySong()
        {
            //byte[] copy = File.ReadAllBytes("torero.mp3");
            //TagLib.File file = TagLib.File.Create("torero.mp3");
            //Console.WriteLine(file.Tag.Title);
            //Console.WriteLine(file.Tag.Album);

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

        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            ds.Pause();
        }


        

        

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

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            BarraProgreso.Value += 1;
            if (BarraProgreso.Value == BarraProgreso.Maximum)
            {
                timer1.Stop();
            }
            label1.Text = BarraProgreso.Value.ToString();
        }

        private void CloseRepro(object sender, FormClosedEventArgs e)
        {
            ds.Stop();
            
        }
        /**
         * 
         * Abre la letra de la cancion
         * */
        private void letra_Click(object sender, EventArgs e)
        {
            Letra letra = new Letra(client);
            letra.Show();
        }

        /**
         * 
         * Le da un maxico a la barra de duracion
         * Inicia el relog
         * */
        private void UpdateBar()
        {
            
            
            BarraProgreso.Maximum =duracionInt;


            timer1.Start();
            
          

        }
    }
}
