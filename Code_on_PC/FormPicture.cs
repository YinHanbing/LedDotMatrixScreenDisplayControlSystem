using System;
using System.Drawing;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public partial class FormPicture : Form
    {
        private Form formPrevious;

        public FormPicture(Form formPrevious)
        {
            InitializeComponent();
            this.formPrevious = formPrevious;
        }

        private void FormPicture_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(picDraw.Width, picDraw.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawRectangle(new Pen(Brushes.Black), new Rectangle() { X = 0, Y = 0, Height = picDraw.Height, Width = picDraw.Width });
            picDraw.Image = bmp;
        }

        private void FormPicture_FormClosed(object sender, FormClosedEventArgs e)
        {
            formPrevious.Enabled = true;
        }
    }
}
