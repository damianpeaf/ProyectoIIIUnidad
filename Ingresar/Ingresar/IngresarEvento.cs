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
    public partial class IngresarEvento : Form
    {

        


        public IngresarEvento()
        {
            InitializeComponent();
            ObtenerCategoria();

            txtInicio.Format = DateTimePickerFormat.Custom;
            txtInicio.CustomFormat = "yyyy-MM-dd hh:mm:ss";

            txtFinal.Format = DateTimePickerFormat.Custom;
            txtFinal.CustomFormat = "yyyy-MM-dd hh:mm:ss";


        }


        int idCategoria;


        private void ObtenerCategoria()
        {
            try
            {
                DominioCategoria categoria = new DominioCategoria();

                comboBox1.DataSource = categoria.ObtenerCategoria();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error" + ex);
            }

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


        //ACCION DEL BOTON INGRESAR
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                String idUsuario = Comun.info_usuario.idUsuario;
                DominioEvento post = new DominioEvento();
                post.InsertarEvento(txtInicio.Text, txtFinal.Text, txtTitulo.Text, txtDescripcion.Text, idCategoria, idUsuario);
                MessageBox.Show("Registro insertado");

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Registro no insertado");

            }
        }


        //-----------------------------------------------------

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void txtContenido_Enter_1(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Descripcion")
            {
                txtDescripcion.Text = "";
                txtDescripcion.ForeColor = Color.LightGray;
            }
        }

        private void txtTitulo_Enter(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "Titulo")
            {
                txtTitulo.Text = "";
                txtTitulo.ForeColor = Color.LightGray;
            }
        }

        private void txtTitulo_Leave_1(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "")
            {
                txtTitulo.Text = "Titulo";
                txtTitulo.ForeColor = Color.White;
            }
        }

        private void txtContenido_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Descripcion";
                txtDescripcion.ForeColor = Color.White;
            }
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            idCategoria = comboBox1.SelectedIndex + 1;

        }

        private void IngresarEvento_Load(object sender, EventArgs e)
        {

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
