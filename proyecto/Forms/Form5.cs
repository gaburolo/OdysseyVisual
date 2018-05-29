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
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="client"></param>
        public Letra(Client client)
        {
            InitializeComponent();
        }
        /// <summary>
        /// Muestra la letra de la cancion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Letra_Load(object sender, EventArgs e)
        {
            textBox1.Text=(@"I'm tired of being what 
you want me to be
feeling so faithless,
lost under the surface

I don't know what 
you're expecting of me 
put under the pressure
of walking in your shoes... 
caught in the undertow,
just caught in the undertow... 

Every step that I take is
another mistake to you... 
caught in the undertow,
just caught in the undertow... 
I've become so numb, 
I can't feel you there 
I've become so tired, 
so much more aware
by becoming this
all i want to do
is be more like me
and be less like you

Can't you see that 
you're,smothering me? 
holding too tightly, 
afraid to lose control
cuz everything that
you thought I would be
has fallen apart
right in front of you...
caught in the undertow,
just caught in the undertow... 
every step that i take
is another mistake to you... 
caught in the undertow,
just caught in the undertow... 
And every second i waste is more than I can take!

I've become so numb, 
I can't feel you there 
I've become so tired, 
so much more aware
by becoming this all i want to do
is be more like me
and be less like you
And I know I may end the failing too
but i know you were just like me
with someone disappointed in you...

I've become so numb, 
I can't feel you there 
I've become so tired, 
so much more aware
by becoming this all I want to do
is be more like me
and be less like you

I've become so numb, 
I can't feel you there 
I'm tired of being what you want me... 
I've become so numb, 
I can't feel you there 
I'm tired of being 
what you want me...") ;
        }
    }
}
