using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyecto.Cliente;
using proyecto.Forms;

namespace proyecto
{
    static class Program
    {
        
        [STAThread]
        static void Main(string[] args)
        {
            Client client = new Client();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 login = new Form1(client);
            login.Show();
            Application.Run();
            
        }
    }
}
