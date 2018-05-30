using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using NAudio.Wave;

namespace proyecto.Cliente
{
    public class Client
    {   //Variables de la clase
        private TcpClient tcpClient;
        private NetworkStream stream;
        private XmlDocument message;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Client()
        {
            //Casa  192.168.100.5
            //Celular 192.168.43.42
            tcpClient = new TcpClient("172.18.239.149", 8000);
            //Convierte a String el Xml
            stream = tcpClient.GetStream();
            message = new XmlDocument();
        }
        /// <summary>
        /// Reproduce la cancion
        /// </summary>
        /// <param name="mp3Array"></param>
        private void PlaySong(byte[] mp3Array)
        {
            byte[] copy = File.ReadAllBytes("torero.mp3");
            TagLib.File file = TagLib.File.Create("torero.mp3");
            Console.WriteLine(file.Tag.Title);
            Console.WriteLine(file.Tag.Album);

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
        /// <summary>
        /// Pasar de xml a String
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public string Serialize(XmlDocument xml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(xml.GetType());

            using (StringWriter text = new StringWriter())
            {
                xmlSerializer.Serialize(text, xml);
                return text.ToString();
            }

        }
        /// <summary>
        /// Envia al server la informacion de la cancion para guardarla 
        /// </summary>
        /// <param name="path"></param>
        public void SendSongMessage(String path)
        {
            TagLib.File file = TagLib.File.Create(path);
            byte[] copy = File.ReadAllBytes(path);

            XmlDocument xml = new XmlDocument();
            XmlNode rootNode = xml.CreateElement("Message");
            xml.AppendChild(rootNode);

            XmlNode opcode = xml.CreateElement("opcode");
            opcode.InnerText = "005";
            rootNode.AppendChild(opcode);
            
            XmlNode data = xml.CreateElement("Data");
            XmlNode song = xml.CreateElement("cancion");
            song.InnerText = file.Tag.Title;
            XmlNode artist = xml.CreateElement("artista");
            artist.InnerText = file.Tag.FirstPerformer;
            XmlNode album = xml.CreateElement("album");
            album.InnerText = file.Tag.Album;
            XmlNode gnere = xml.CreateElement("genero");
            gnere.InnerText = file.Tag.FirstGenre;
            XmlNode lyrics = xml.CreateElement("letra");
            lyrics.InnerText = file.Tag.Lyrics;
            XmlNode year = xml.CreateElement("year");
            year.InnerText=file.Tag.Year.ToString();
            XmlNode duracion = xml.CreateElement("duracion");
            duracion.InnerText=file.Properties.Duration.TotalSeconds.ToString();
            
            XmlNode bytes = xml.CreateElement("bytes");
            bytes.InnerText = Convert.ToBase64String(copy);

            data.AppendChild(song);
            data.AppendChild(artist);
            data.AppendChild(album);
            data.AppendChild(gnere);
            data.AppendChild(year);
            data.AppendChild(duracion);
            data.AppendChild(lyrics);
            data.AppendChild(bytes);
            

            rootNode.AppendChild(data);
            Send(xml);
        }
        /// <summary>
        /// Envia mensaje al server para obtener los bytes de la cancion
        /// </summary>
        /// <param name="cancion"></param>
        /// <param name="artista"></param>
        public void PlaySongMessage(String cancion, String artista)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode rootNode = xml.CreateElement("Message");
            xml.AppendChild(rootNode);

            XmlNode opcode = xml.CreateElement("opcode");
            opcode.InnerText = "004";
            rootNode.AppendChild(opcode);

            XmlNode data = xml.CreateElement("Data");
            XmlNode song = xml.CreateElement("cancion");
            song.InnerText = cancion;
            XmlNode artist = xml.CreateElement("artista");
            artist.InnerText = artista;
            data.AppendChild(song);
            data.AppendChild(artist);

            rootNode.AppendChild(data);
            Send(xml);
        }
        /// <summary>
        /// Envia un mensaje al server para registrar los datos del usuario
        /// </summary>
        /// <param name="username"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="password"></param>
        public void SignInMessage(String username, String name, String surname, String age, String password)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode rootNode = xml.CreateElement("Message");
            xml.AppendChild(rootNode);

            XmlNode opcode = xml.CreateElement("opcode");
            opcode.InnerText = "000";
            rootNode.AppendChild(opcode);

            XmlNode data = xml.CreateElement("Data");
            XmlNode username1 = xml.CreateElement("username");
            username1.InnerText = username;
            XmlNode name1 = xml.CreateElement("name");
            name1.InnerText = name;
            XmlNode surname1 = xml.CreateElement("surname");
            surname1.InnerText = surname;
            XmlNode age1 = xml.CreateElement("age");
            age1.InnerText = age;
            XmlNode password1 = xml.CreateElement("password");
            password1.InnerText = password;

            data.AppendChild(username1);
            data.AppendChild(name1);
            data.AppendChild(surname1);
            data.AppendChild(age1);
            data.AppendChild(password1);

            rootNode.AppendChild(data);
            Send(xml);
        }


        /// <summary>
        /// Envia un mensaje al server con los datos de usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public void LogInMessage(String user, String password)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode rootNode = xml.CreateElement("Message");
            xml.AppendChild(rootNode);

            XmlNode opcode = xml.CreateElement("opcode");
            opcode.InnerText = "001";
            rootNode.AppendChild(opcode);

            XmlNode data = xml.CreateElement("Data");
            XmlNode username1 = xml.CreateElement("username");
            username1.InnerText = user;
            XmlNode password1 = xml.CreateElement("password");
            password1.InnerText = password;

            data.AppendChild(username1);
            data.AppendChild(password1);

            rootNode.AppendChild(data);
            Send(xml);
        }


        /// <summary>
        /// Envia mensaje al server buscando una canciones especificas 
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="text"></param>
        public void SearchSongMessage(String tipo, String text)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode rootNode = xml.CreateElement("Message");
            xml.AppendChild(rootNode);

            XmlNode opcode = xml.CreateElement("opcode");
            if (tipo.Equals("Letra")){
                opcode.InnerText = "015";
            } else
            {
                opcode.InnerText = "007";
            }
            rootNode.AppendChild(opcode);

            XmlNode data = xml.CreateElement("Data");
            XmlNode type = xml.CreateElement("type");
            type.InnerText = tipo;
            XmlNode texto = xml.CreateElement("text");
            texto.InnerText = text;

            data.AppendChild(type);
            data.AppendChild(texto);

            rootNode.AppendChild(data);
            Send(xml);
        }


        /// <summary>
        /// Envia mensaje al server para ordenar las canciones
        /// </summary>
        /// <param name="array"></param>
        /// <param name="tipo"></param>
        public void SortListMessage(String[,] array, String tipo)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode rootNode = xml.CreateElement("Message");
            xml.AppendChild(rootNode);

            XmlNode opcode = xml.CreateElement("opcode");
            if (tipo.Equals("Album"))
                opcode.InnerText = "009";
            else if (tipo.Equals("Artista"))
                opcode.InnerText = "010";
            else if (tipo.Equals("Titulo"))
                opcode.InnerText = "011";

            rootNode.AppendChild(opcode);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                XmlNode data = xml.CreateElement("Data");

                XmlNode titulo = xml.CreateElement("titulo");
                titulo.InnerText = array[i, 0];
                XmlNode artista = xml.CreateElement("artista");
                artista.InnerText = array[i, 1];
                XmlNode album = xml.CreateElement("album");
                album.InnerText = array[i, 2];
                XmlNode year = xml.CreateElement("year");
                year.InnerText = array[i, 3];
                XmlNode duracion = xml.CreateElement("duracion");
                duracion.InnerText = array[i, 4];


                data.AppendChild(titulo);
                data.AppendChild(artista);
                data.AppendChild(album);
                data.AppendChild(year);
                data.AppendChild(duracion);

                rootNode.AppendChild(data);
            }
            Send(xml);
        }

        /// <summary>
        /// Enviar mensajes al server
        /// </summary>
        /// <param name="message"></param>
        private void Send(XmlDocument message)
        {
            StreamWriter writer = new StreamWriter(stream);
            String xml = Serialize(message).Replace(System.Environment.NewLine, String.Empty);

            writer.WriteLine(xml);
            writer.Flush();

            Receive();
        }

        /// <summary>
        /// Recibe mensajes enviados por el server
        /// </summary>
        private void Receive()
        {
            StreamReader reader = new StreamReader(stream);
            String data = reader.ReadLine();

            //Todavia no lo lee como xml pero sí como string 
            if (data != null)
            {
                message.LoadXml(data);

               
            }
        }

        /// <summary>
        /// Obtiene el mensaje
        /// </summary>
        /// <returns></returns>
        public XmlDocument GetMessage()
        {
            return message;
        }

        /// <summary>
        /// Envia el mensaje al server para eliminar una cancion
        /// </summary>
        /// <param name="cancion"></param>
        /// <param name="artista"></param>
        /// <param name="album"></param>
        public void DeleteSongMessage(String cancion, String artista, String album)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode rootNode = xml.CreateElement("Message");
            xml.AppendChild(rootNode);

            XmlNode opcode = xml.CreateElement("opcode");
            opcode.InnerText = "012";
            rootNode.AppendChild(opcode);

            XmlNode data = xml.CreateElement("Data");
            XmlNode song = xml.CreateElement("cancion");
            song.InnerText = cancion;
            XmlNode artist = xml.CreateElement("artista");
            artist.InnerText = artista;
            XmlNode albumNode = xml.CreateElement("album");
            albumNode.InnerText = album;

            data.AppendChild(song);
            data.AppendChild(artist);
            data.AppendChild(albumNode);

            rootNode.AppendChild(data);

            Send(xml);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="cancion"></param>
        /// <param name="artista"></param>
        /// <param name="newInfo"></param>
        public void SetMetadataMessage(String tipo, String cancion, String artista, String newInfo)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode rootNode = xml.CreateElement("Message");
            xml.AppendChild(rootNode);

            XmlNode opcode = xml.CreateElement("opcode");
            opcode.InnerText = "014";
            rootNode.AppendChild(opcode);

            XmlNode data = xml.CreateElement("Data");
            XmlNode type = xml.CreateElement("type");
            type.InnerText = tipo;
            XmlNode song = xml.CreateElement("cancion");
            song.InnerText = cancion;
            XmlNode artist = xml.CreateElement("artista");
            artist.InnerText = artista;
            XmlNode text = xml.CreateElement("text");
            text.InnerText = newInfo.Replace(System.Environment.NewLine, String.Empty);

            data.AppendChild(type);
            data.AppendChild(song);
            data.AppendChild(artist);
            data.AppendChild(text);

            rootNode.AppendChild(data);
            Send(xml);
        }
    }
}
