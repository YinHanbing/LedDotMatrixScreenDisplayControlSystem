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

        // 打印矩阵
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

        public DotMatrix16 ExchangeCode(DotMatrix16 dotMatrix16)
        {
            DotMatrix16 newDotMatrix16 = new DotMatrix16();

            return newDotMatrix16;
        }
    }
}