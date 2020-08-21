using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;
using Dominio;
using Ingresar.Inicio;
namespace Ingresar.Inicio
{
    public partial class App : Form
    {

        public App()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IngresarEvento form = new IngresarEvento();
            form.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IngresarPost form = new IngresarPost();
            form.Show();
            this.Hide();
        }

        public int xClick = 0, yClick = 0;

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            InicioSesion.InicioSesion frm = new InicioSesion.InicioSesion();
            this.Hide();
            frm.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            InicioSesion.InicioSesion frm = new InicioSesion.InicioSesion();
            this.Hide();
            frm.Show();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }


    }
}
