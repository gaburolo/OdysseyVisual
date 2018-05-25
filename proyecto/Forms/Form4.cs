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

namespace proyecto
{
    public partial class Reproductor : Form
    {
        private Client client;
        private String cancion, artista;
        private byte[] toStream;
        private DirectSoundOut ds;
        private int seconds;

        private void Play_Click(object sender, EventArgs e)
        {

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
                        
                        Thread.Sleep(90000);
                        
                    }
                }
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            ds.Pause();
        }


        public Reproductor(Client client, String cancion, String artista)
        {
            this.client=client;
            this.cancion = cancion;
            this.artista = artista;
            InitializeComponent();
            Reproducir();


            
        }

        private void Stop_Click_1(object sender, EventArgs e)
        {
            ds.Stop();
        }

        private void Reproducir()
        {
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
        

        private void UpdateBar()
        {
            
            //int num = toStream.Length;
            BarraProgreso.Maximum = 224;


            timer1.Start();
            
               // label1.Text = BarraProgreso.Value.ToString();
            /*while (true)
            {
                Thread.Sleep(1000);
                seconds++;

                if (seconds == 236)
                {
                    Thread.CurrentThread.Abort();
                }

                BarraProgreso.Value += 1;
            */
                
                //Thread.Sleep(1000);
                

                /*                BarraProgreso.Value = (unchecked((int) ds.GetPosition()) * 100) / num;


                                if (unchecked((int) ds.GetPosition()) == num)
                                {
                                    Thread.CurrentThread.Abort();

                                    break;
                                }

            }*/

        }
    }
}
