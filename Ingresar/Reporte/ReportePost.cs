using Dominio;
using Microsoft.Reporting.WinForms;
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

namespace Reporte
{
    public partial class ReportePost : Form
    {



        public ReportePost()
        {
            InitializeComponent();
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

        private void ReportePost_Load(object sender, EventArgs e)
        {
            DominioPost post = new DominioPost();
            DataTable ds = post.ReportePost();

            reportViewer2.LocalReport.DataSources.Clear();

            reportViewer2.LocalReport.ReportPath = @"..\..\..\Reporte\InformePost.rdlc";
            ReportDataSource rp = new ReportDataSource("Post", ds);
            reportViewer2.LocalReport.DataSources.Add(rp);

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Ingresar.Inicio.Menu frm = new Ingresar.Inicio.Menu();
            this.Hide();
            frm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Ingresar.Inicio.Menu frm = new Ingresar.Inicio.Menu();
            this.Hide();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DominioPost post = new DominioPost();
            DataTable ds = post.ReportePost();

            reportViewer2.LocalReport.DataSources.Clear();

            reportViewer2.LocalReport.ReportPath = @"..\..\..\Reporte\InformePost.rdlc";
            ReportDataSource rp = new ReportDataSource("Post", ds);
            reportViewer2.LocalReport.DataSources.Add(rp);

            reportViewer2.RefreshReport();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DominioEvento evento = new DominioEvento();
            DataTable ds2 = evento.RerpoteEvento();

            reportViewer2.LocalReport.ReportPath = @"..\..\..\Reporte\InformeEvento.rdlc";

            ReportDataSource rp2 = new ReportDataSource("DataSet1", ds2);
            reportViewer2.LocalReport.DataSources.Add(rp2);

            reportViewer2.RefreshReport();
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
