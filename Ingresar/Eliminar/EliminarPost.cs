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
    public partial class EliminarPost : Form
    {

        //String idCampo

        public EliminarPost()
        {
            InitializeComponent();

            //if (idCampo != string.Empty)
            //{

            //    txtId.Text = idCampo;
                buscar();
            //}


        }


        int idCategoria;


        private void ObtenerCategoria(string id)
        {
            try
            {
                DominioCategoria categoria = new DominioCategoria();

                txtCategoria.Text = categoria.BuscarCategoria(id);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error" + ex);
            }

        }


        public int xClick = 0, yClick = 0;

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtTitulo_Leave(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "")
            {
                txtTitulo.Text = "Titulo";
                txtTitulo.ForeColor = Color.White;
            }
        }


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
                DominioPost post = new DominioPost();
                post.EliminarPost(txtId.Text);
                MessageBox.Show("Registro eliminado");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Registro no encontrado");

            }
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

        public void buscar()
        {
            try
            {
                DominioPost post = new DominioPost();
                String[] datos = post.BuscarPost(txtId.Text);


                if (datos[0] != null) { 

                    txtId.Text = datos[0];
                txtTitulo.Text = datos[1];
                txtHora.Text = datos[2];
                txtContenido.Text = datos[3];
                ObtenerCategoria(datos[4]);
            }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Registro no encontrado");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void txtId_Enter(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "id")
            {
                txtTitulo.Text = "";
                txtTitulo.ForeColor = Color.LightGray;
            }
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                txtId.Text = "id";
                txtId.ForeColor = Color.White;
            }
        }

        private void EliminarPost_Load(object sender, EventArgs e)
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
