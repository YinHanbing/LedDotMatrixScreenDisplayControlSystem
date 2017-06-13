using System;
using System.Drawing;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplaySystem
{
    public partial class FormPicture : Form
    {
        public FormPicture()
        {
            InitializeComponent();
        }

        private void FormPicture_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(16, 16);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, new Rectangle() { X = 0, Y = 0, Height = 16, Width = 16 });
            picDraw.Image = bmp;
        }
    }
}
