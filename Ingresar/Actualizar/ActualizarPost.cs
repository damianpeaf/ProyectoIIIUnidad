using Clases;
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
    public partial class ActualizarPost : Form
    {



        public ActualizarPost(String idCampo)
        {
            InitializeComponent();

            if (idCampo != string.Empty)
            {
                txtId.Text = idCampo;
                Buscar();

            }

            comboBox1.Text = "Categoria";
            ObtenerCategoria();

        }


        int idCategoria;


        private void ObtenerCategoria()
        {
            try
            {
                MySqlConnection cn = new Conexion().IniciarConexion();


                MySqlCommand comando = new MySqlCommand("SELECT nombre, idCategoria From Categoria", cn);
                MySqlDataReader reader =  comando.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0).ToString());
                }

                cn.Close();
                reader.Close();


            }
            catch (MySqlException ex)
            {
                Console.WriteLine("NI");
                MessageBox.Show("error"+ ex);
            }

        }


        public int xClick = 0, yClick = 0;

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "Titulo")
            {
                txtTitulo.Text = "";
                txtTitulo.ForeColor = Color.LightGray;
            }
        }

        private void txtTitulo_Leave(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "")
            {
                txtTitulo.Text = "Titulo";
                txtTitulo.ForeColor = Color.White;
            }
        }

        private void txtContenido_Enter(object sender, EventArgs e)
        {
            if (txtContenido.Text == "Contenido")
            {
                txtContenido.Text = "";
                txtContenido.ForeColor = Color.LightGray;
            }
        }

        private void txtContenido_Leave(object sender, EventArgs e)
        {
            if (txtContenido.Text == "")
            {
                txtContenido.Text = "Contenido";
                txtContenido.ForeColor = Color.White;
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
                post.ActualizarPost(txtId.Text, txtTitulo.Text, txtContenido.Text, idCategoria);
                MessageBox.Show("actualizado Correctamente");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Registro no actualizado");

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCategoria = comboBox1.SelectedIndex+1;
            //MessageBox.Show(idCategoria + "");
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


        private void button2_Click(object sender, EventArgs e)
        {
            Buscar();
        }


        void Buscar()
        {
            try
            {
                DominioPost post = new DominioPost();
                String[] datos = post.BuscarPost(txtId.Text);

                txtId.Text = datos[0];
                txtTitulo.Text = datos[1];
                txtHora.Text = datos[2];
                txtContenido.Text = datos[3];

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Registro no encontrado");

            }
        }

        private void txtId_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                txtId.Text = "id";
                txtId.ForeColor = Color.White;
            }
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
