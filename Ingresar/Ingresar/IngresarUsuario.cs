using Dominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingresar
{
    public partial class IngresarUsuario : Form
    {

        


        public IngresarUsuario()
        {
            InitializeComponent();
            obtenerTipo();

        }




        private void obtenerTipo()
        {
            try
            {
                DominioUsuario usuario = new DominioUsuario();

                comboBox1.DataSource = usuario.tipoUsuario();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error"+ ex);
            }

        }


        public int xClick = 0, yClick = 0;


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        //ACCION DEL BOTON INGRESAR
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DominioUsuario usuario = new DominioUsuario();

                usuario.crearUsuario(txtNombre.Text, txtCorreo.Text, txtUsuario.Text, txtContraseña.Text, idTipo);

                MessageBox.Show("USUARIO REGISTRADO");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Registro no insertado");

            }
        }

        int idTipo;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idTipo = comboBox1.SelectedIndex+1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Inicio.Menu Form = new Inicio.Menu();
            Form.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Inicio.Menu Form = new Inicio.Menu();
            Form.Show();
            this.Hide();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
    }


    

}
