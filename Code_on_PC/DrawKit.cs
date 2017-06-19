using System.Drawing;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    class DrawKit
    {
        private delegate void UpdateUI();
        private static DotMatrix16 dotMatrix16;

        public const string FLAG_DRAW = "DRAW";
        public const string FLAG_ERASER = "ERASER";

        public static DotMatrix16 DotMatrix16 { get => dotMatrix16; set => dotMatrix16 = value; }

        /// <summary>
        /// 初始化画布
        /// </summary>
        /// <param name="pictureBox"></param>
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
            }));

            // 初始化DotMatrix16
            DotMatrix16 = new DotMatrix16();
            DotMatrix16.PrintMatrix16();
            System.Console.WriteLine("drawCanvas");
        }

        /// <summary>
        /// 根据点阵数据直接绘图
        /// </summary>
        /// <param name="pictureBox">绘图区域</param>
        /// <param name="data">绘图数据</param>
        public static void Draw(PictureBox pictureBox, DotMatrix16 data)
        {
            InitCanvas(pictureBox);
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (data.GetDot(j, i))
                    {
                        DrawDot(pictureBox, j, i, FLAG_DRAW);
                    }
                }
            }
        }

        /// <summary>
        /// 在pictureBox中画点
        /// </summary>
        /// <param name="pictureBox">画图区域</param>
        /// <param name="x">列：0 <= x <= 15</param>
        /// <param name="y">行：0 <= y <= 15</param>
        /// <param name="flag">DrawKit.</param>
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
                           if (!DotMatrix16.GetDot(x, y))
                           {
                               System.Console.WriteLine(DotMatrix16.GetDot(x, y));
                               graphics.FillEllipse(Brushes.Red, rect[x, y]);
                               DotMatrix16.SetDot(x, y, FLAG_DRAW);
                           }
                       }
                       else if (flag == FLAG_ERASER)
                       {
                           if (DotMatrix16.GetDot(x, y))
                           {
                               System.Console.WriteLine(DotMatrix16.GetDot(x, y));
                               graphics.FillEllipse(Brushes.White, rect[x, y]);
                               DotMatrix16.SetDot(x, y, FLAG_ERASER);
                           }
                       }
                       graphics.Dispose();
                       pictureBox.Image = bitmap;
                       System.Console.WriteLine("drawDot");
                   }));
            }
        }
    }
}
