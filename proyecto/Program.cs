using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyecto.Cliente;

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
            Form2 login = new Form2(client);
            login.Show();
            Application.Run();
            
        }
    }
}
