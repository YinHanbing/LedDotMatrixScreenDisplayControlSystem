using System.Drawing;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    class DrawKit
    {
        private static DotMatrix16 dotMatrix16;

        public const string FLAG_DRAW = "DRAW";
        public const string FLAG_ERASE = "ERASE";

        public static DotMatrix16 DotMatrix16 { get => dotMatrix16; set => dotMatrix16 = value; }

        /// <summary>
        /// 初始化画布
        /// </summary>
        /// <param name="pictureBox">绘图区域</param>
        /// <param name="dotMatrix16">点阵数据</param>
        public static void InitCanvas(PictureBox pictureBox, DotMatrix16 dotMatrix16)
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

            // 初始化dotMatrix16
            dotMatrix16.DotMatrix = new byte[32];
            dotMatrix16.PrintMatrix16();
            System.Console.WriteLine("InitCanvas");
        }

        /// <summary>
        /// 根据点阵数据直接绘图
        /// </summary>
        /// <param name="pictureBox">绘图区域</param>
        /// <param name="dotMatrix16">绘图数据</param>
        public static void Draw(PictureBox pictureBox, DotMatrix16 dotMatrix16)
        {
            InitCanvas(pictureBox, new DotMatrix16());
            Bitmap bitmap = new Bitmap(pictureBox.Image);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (dotMatrix16.GetDot(j, i))
                    {
                        graphics.FillEllipse(Brushes.Red, new Rectangle(j * 16, i * 16, 16, 16));
                    }
                }
            }
            graphics.Dispose();
            pictureBox.Image = bitmap;
            dotMatrix16.PrintMatrix16();
            System.Console.WriteLine("Draw");
        }

        /// <summary>
        /// 在pictureBox中画点
        /// </summary>
        /// <param name="pictureBox">绘图区域</param>
        /// <param name="dotMatrix16">点阵数据</param>
        /// <param name="x">列：0 <= x <= 15</param>
        /// <param name="y">行：0 <= y <= 15</param>
        /// <param name="flag">DrawKit.</param>
        public static void DrawDot(PictureBox pictureBox, DotMatrix16 dotMatrix16, int x, int y, string flag)
        {
            if (x >= 0 && x <= 15 && y >= 0 && y <= 15)
            {
                Bitmap bitmap = new Bitmap(pictureBox.Image);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // 画点
                if (flag == FLAG_DRAW)
                {
                    if (!dotMatrix16.GetDot(x, y))
                    {
                        System.Console.WriteLine(dotMatrix16.GetDot(x, y));
                        graphics.FillEllipse(Brushes.Red, new Rectangle(x * 16, y * 16, 16, 16));
                        dotMatrix16.SetDot(x, y, FLAG_DRAW);
                        System.Console.WriteLine("DrawDot");
                    }
                }
                else if (flag == FLAG_ERASE)
                {
                    if (dotMatrix16.GetDot(x, y))
                    {
                        System.Console.WriteLine(dotMatrix16.GetDot(x, y));
                        graphics.FillEllipse(Brushes.White, new Rectangle(x * 16, y * 16, 16, 16));
                        dotMatrix16.SetDot(x, y, FLAG_ERASE);
                        System.Console.WriteLine("EraseDot");
                    }
                }
                graphics.Dispose();
                pictureBox.Image = bitmap;
            }
        }
    }
}
