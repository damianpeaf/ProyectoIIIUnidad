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

namespace InicioSesion
{
    public partial class InicioSesion : Form
    {

        


        public InicioSesion()
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
                String[] datosUsuario = usuario.validarUsuario(txtUsuario.Text, txtContraseña.Text);

                if (datosUsuario != null)
                {
                    if (datosUsuario[3] == "1")
                    {
                        Ingresar.Inicio.Menu frm = new Ingresar.Inicio.Menu();
                        this.Hide();
                        frm.Show();
                        //sincronizar
                    }
                    else
                    {
                        MessageBox.Show("Bienvenido "+ datosUsuario[1]);
                        Ingresar.Inicio.App frm = new Ingresar.Inicio.App();
                        this.Hide();
                        frm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }

            }
            catch (MySqlException ex)
            {
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Contraseña";
                txtContraseña.ForeColor = Color.LightGray;
            }
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
