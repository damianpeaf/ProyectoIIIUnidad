using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Ingresar.Varios
{
    public partial class UserControl2 :  Panel
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        public Color ColorTop { get; set; }
        public Color ColorBottom { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush lgb = new
            LinearGradientBrush(this.ClientRectangle, this.ColorTop,this.ColorBottom, 0F);
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, this.ClientRectangle);
            base.OnPaint(e);
        }

    }
}
