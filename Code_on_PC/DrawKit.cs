using System.Drawing;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplaySystemOnPC
{
    class DrawKit
    {
        private delegate void UpdateUI();

        public static void InitCanvas(PictureBox pictureBox)
        {
            pictureBox.Invoke(new UpdateUI(() =>
            {
                Graphics graphics = pictureBox.CreateGraphics();
                graphics.DrawRectangle(new Pen(Brushes.Black), new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
                graphics.Clear(Color.Black);
                System.Console.WriteLine("draw");
            }));
        }

        public static void Draw(PictureBox pictureBox, byte data)
        {

        }
    }
}
