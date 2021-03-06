﻿using System;
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
using Comun;
using Reporte;

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

        private void label7_Click(object sender, EventArgs e)
        {
            InicioSesion.InicioSesion frm = new InicioSesion.InicioSesion();
            this.Hide();
            frm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            InicioSesion.InicioSesion frm = new InicioSesion.InicioSesion();
            this.Hide();
            frm.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (info_usuario.idTipoUsuario == "1")
            {
                
            }else if (info_usuario.idTipoUsuario == "2")
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;


            }
            else if (info_usuario.idTipoUsuario == "3")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
            }
            else if (info_usuario.idTipoUsuario == "4")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
            }
            else if (info_usuario.idTipoUsuario == "5")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button8.Enabled = false;
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ReportePost frm = new ReportePost();
            this.Hide();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            IngresarUsuario frm = new IngresarUsuario();
            this.Hide();
            frm.Show();
        }

        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
