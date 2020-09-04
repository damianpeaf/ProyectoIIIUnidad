using Dominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecuperarContraseña
{
    public partial class RecuperarContraseña : Form
    {

        


        public RecuperarContraseña()
        {
            InitializeComponent();

        }




        //----------------------------------------------------------------------------------------------


        public int xClick = 0, yClick = 0;

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
            try
            {
                DominioUsuario usuario = new DominioUsuario();

                string msg = usuario.recuperarContraseña(txtUsuario.Text);
                MessageBox.Show(msg);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Correo")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Correo";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

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

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        //----------------------------------------------------


    }


    

}
