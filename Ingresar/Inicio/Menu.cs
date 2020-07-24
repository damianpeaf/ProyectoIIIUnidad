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
using Clases;

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



                try
                {
                    MySqlConnection cn = new Conexion().IniciarConexion();


                    string comando;

                    switch (tabla)
                    {
                        case 0:
                            comando = "SELECT * FROM evento";

                            break;

                        case 1:
                            comando = "SELECT * FROM post";
                            break;

                        default:
                            comando = "SELECT * FROM evento";
                            break;

                    }

                    string id = textBox1.Text.ToString();

                    if (id == "")
                    {
                        comando = comando + "";
                    }
                    else
                    {
                        if (tabla == 0)
                        {
                            comando = comando + $" where idEvento = '{id}'";
                        }
                        else if (tabla == 1)
                        {
                            comando = comando + $" where idPost = '{id}'";

                        }
                    }


                    MySqlCommand datos = new MySqlCommand(comando, cn);

                    MySqlDataAdapter m_datos = new MySqlDataAdapter(datos);
                    ds = new DataSet();
                    m_datos.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];

                }
                catch (MySqlException ex)
                {

                    throw;
                }

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

                    
                }        

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EliminarPost form = new EliminarPost();
            form.Show();
            this.Hide();
        }

        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            //
        }
    }
}
