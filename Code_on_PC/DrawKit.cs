using System.Drawing;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    class DrawKit
    {
        private delegate void UpdateUI();

        public const string FLAG_DRAW = "DRAW";
        public const string FLAG_ERASER = "ERASER";

        public static void InitCanvas(PictureBox pictureBox)
        {
            pictureBox.Invoke(new UpdateUI(() =>
            {
                Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                // 画背景
                graphics.Clear(Color.White);

                // 画点阵屏
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        graphics.DrawEllipse(Pens.Black, i * 16, j * 16, 16, 16);
                    }
                }
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        graphics.FillEllipse(Brushes.Red, i * 16, j * 16, 16, 16);
                    }
                }
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        graphics.FillEllipse(Brushes.White, i * 16, j * 16, 16, 16);
                    }
                }

                graphics.Dispose();
                pictureBox.Image = bitmap;
                System.Console.WriteLine("draw");
            }));
        }

        public static void Draw(PictureBox pictureBox, DotMatrix16 data)
        {

        }

        public static void DrawDot(PictureBox pictureBox, int x, int y, string flag)
        {
            if (x >= 0 && x <= 15 && y >= 0 && y <= 15)
            {
                pictureBox.Invoke(new UpdateUI(() =>
                   {
                       Bitmap bitmap = new Bitmap(pictureBox.Image);
                       Graphics graphics = Graphics.FromImage(bitmap);
                       Rectangle[,] rect = new Rectangle[16, 16];
                       graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                       // 画点
                       for (int i = 0; i < 16; i++)
                       {
                           for (int j = 0; j < 16; j++)
                           {
                               rect[i, j] = new Rectangle(i * 16, j * 16, 16, 16);
                           }
                       }
                       if (flag == FLAG_DRAW)
                       {
                           graphics.FillEllipse(Brushes.Red, rect[x, y]);
                       }
                       else if (flag == FLAG_ERASER)
                       {
                           graphics.FillEllipse(Brushes.White, rect[x, y]);
                       }
                       graphics.Dispose();
                       pictureBox.Image = bitmap;
                       System.Console.WriteLine("draw");
                   }));
            }
        }
    }
}
