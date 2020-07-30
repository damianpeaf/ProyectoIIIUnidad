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
using Clases;
using Dominio;

namespace Ingresar.Inicio
{
    public partial class Menu : Form
    {

        public Menu()
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
            Ingresar.IngresarEvento form = new Ingresar.IngresarEvento();
            form.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ingresar.IngresarPost form = new Ingresar.IngresarPost();
            form.Show();
            this.Hide();
        }

        public int xClick = 0, yClick = 0;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        DataSet ds;


        private void button7_Click(object sender, EventArgs e)
        {

            if (tabla != null)
            {

                String id = txtId.Text.ToString();

                DominioPost post = new DominioPost();
                ds = post.mostrarPost(tabla, id);

                dataGridView1.DataSource = ds.Tables[0];

            }
        }

        int tabla;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabla = comboBox1.SelectedIndex;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActualizarPost form = new ActualizarPost(null);
            this.Hide();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;

            if (n != -1)
            {
                string id = dataGridView1.Rows[n].Cells[0].Value.ToString();
                string tablaNombre = dataGridView1.Columns[0].HeaderText;

                if (tablaNombre == "idPost")
                {

                    ActualizarPost form = new ActualizarPost(id);
                    this.Hide();
                    form.Show();

                    
                }else if (tablaNombre == "idEvento")
                {

                    ActualizarEvento form = new ActualizarEvento(id);
                    this.Hide();
                    form.Show();

                }
                else
                {
                    MessageBox.Show("tabla no seleccionada");
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EliminarPost form = new EliminarPost();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EliminarEvento form = new EliminarEvento();
            form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActualizarEvento form = new ActualizarEvento(null);
            form.Show();
            this.Hide();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            //
        }
    }
}
