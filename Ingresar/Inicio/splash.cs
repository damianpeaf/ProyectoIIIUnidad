using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingresar.Inicio
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(4);

            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                InicioSesion.InicioSesion frm = new InicioSesion.InicioSesion();
                this.Hide();
                frm.Show();
            }
        }
    }
}
