using System;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public class DotMatrix16
    {
        private byte[] dotMatrix;

        public DotMatrix16()
        {
            DotMatrix = new byte[32]
            {
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
                0x00,0x00,
            };
        }

        public byte[] DotMatrix { get => dotMatrix; set => dotMatrix = value; }

        /// <summary>
        /// 设置点阵中的某个点的值
        /// </summary>
        /// <param name="x">列：0 <= x <= 15</param>
        /// <param name="y">行：0 <= y <= 15</param>
        /// <param name="flag">DrawKit.</param>
        public void SetDot(int x, int y, string flag)
        {
            if (0 <= x && x <= 15 && 0 <= y && y <= 15)
            {
                if (flag == DrawKit.FLAG_DRAW)
                {
                    DotMatrix[y * 2 + x / 8] = (byte)(DotMatrix[y * 2 + x / 8] | (0x0100 >> (x % 8 + 1)));
                }
                else if (flag == DrawKit.FLAG_ERASE)
                {
                    DotMatrix[y * 2 + x / 8] = (byte)(DotMatrix[y * 2 + x / 8] & (0xfeff >> (x % 8 + 1)));
                }

                // 打印矩阵
                PrintMatrix16();
            }
        }

        /// <summary>
        /// 打印矩阵
        /// </summary>
        public void PrintMatrix16()
        {
            System.Console.Write("=================\n");
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    System.Console.Write((DotMatrix[i * 2 + j / 8] >> (7 - j % 8)) & 0x01);
                    if (j == 7)
                    {
                        System.Console.Write(" ");
                    }
                }
                System.Console.WriteLine();
            }
        }

        /// <summary>
        /// 获取点阵中的某个点的值
        /// </summary>
        /// <param name="x">列：0 <= x <= 15</param>
        /// <param name="y">行：0 <= y <= 15</param>
        /// <returns></returns>
        public bool GetDot(int x, int y)
        {
            if (0 <= x && x <= 15 && 0 <= y && y <= 15)
            {
                if (((DotMatrix[y * 2 + x / 8] >> (7 - x % 8)) & 0x01) != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 将该点阵数据换为与之对应的另一设备上的点阵数据
        /// </summary>
        /// <returns>DotMatrix16</returns>
        public DotMatrix16 ExchangeCode()
        {
            DotMatrix16 newDotMatrix16 = new DotMatrix16();

            for (int i = 0; i < 32; i++)
            {
                int intbyte = 0;
                for (int j = 7; j >= 0; j--)
                {
                    intbyte += Convert.ToInt16((DotMatrix[i] >> j) & 0x01) * (int)Math.Pow(2, 7 - j);
                }
                newDotMatrix16.DotMatrix[i] = Convert.ToByte(intbyte);
            }

            return newDotMatrix16;
        }

        /// <summary>
        /// 向上移动
        /// </summary>
        public void UpMove()
        {
            byte byte0 = DotMatrix[0];
            byte byte1 = DotMatrix[1];
            for (int i = 0; i < 30; i++)
            {
                DotMatrix[i] = DotMatrix[i + 2];
            }
            DotMatrix[30] = byte0;
            DotMatrix[31] = byte1;
        }

        /// <summary>
        /// 向下移动
        /// </summary>
        public void DownMove()
        {
            byte byte30 = DotMatrix[30];
            byte byte31 = DotMatrix[31];
            for (int i = 31; i >= 2; i--)
            {
                DotMatrix[i] = DotMatrix[i - 2];
            }
            DotMatrix[0] = byte30;
            DotMatrix[1] = byte31;
        }

        /// <summary>
        /// 向左移动
        /// </summary>
        public void LeftMove()
        {
            for (int i = 0; i < 32; i += 2)
            {
                int head1 = DotMatrix[i] >> 7;
                int head2 = DotMatrix[i + 1] >> 7;
                DotMatrix[i] = (byte)((DotMatrix[i] << 1) + head2);
                DotMatrix[i + 1] = (byte)((DotMatrix[i + 1] << 1) + head1);
            }
        }

        /// <summary>
        /// 向右移动
        /// </summary>
        public void RightMove()
        {
            for (int i = 0; i < 32; i += 2)
            {
                int tail1 = DotMatrix[i] & 0x01;
                int tail2 = DotMatrix[i + 1] & 0x01;
                DotMatrix[i] = (byte)((DotMatrix[i] >> 1) + tail2 * Math.Pow(2, 7));
                DotMatrix[i + 1] = (byte)((DotMatrix[i + 1] >> 1) + tail1 * Math.Pow(2, 7));
            }
        }
    }
}