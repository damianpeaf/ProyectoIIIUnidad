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
            progressBar1.Increment(2);

            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                Menu frm = new Menu();
                this.Hide();
                frm.Show();
            }
        }
    }
}
