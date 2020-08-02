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

namespace Ingresar.Inicio
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        int wh = 20;
        Color ct = Color.Blue, cb = Color.Orange;


        public int BoderRadius
        {
            get{ return wh; }
            set { wh = value; Invalidate(); }
        }

        public Color colorTop
        {
            get { return ct; }
            set { ct = value; Invalidate(); }
        }

        public Color colorBottom
        {
            get { return cb; }
            set { cb = value; Invalidate(); }
        }


        protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                GraphicsPath gp = new GraphicsPath();
                gp.AddArc(new Rectangle(0, 0, wh, wh), 180, 90);
                gp.AddArc(new Rectangle(Width-wh, 0, wh, wh), -90, 90);
                gp.AddArc(new Rectangle(Width - wh, Height-wh , wh, wh), 0, 90);
                gp.AddArc(new Rectangle(0, Height-wh, wh, wh), 90, 90);

            e.Graphics.FillPath(new LinearGradientBrush(ClientRectangle, ct, cb, 45), gp);
                base.OnPaint(e);
            }


    }
}
