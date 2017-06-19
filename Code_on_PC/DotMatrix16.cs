namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public class DotMatrix16
    {
        private byte[] dotMatrix16;

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

        public byte[] DotMatrix { get => dotMatrix16; set => dotMatrix16 = value; }

        public void SetDot(int x, int y, string flag)
        {
            if (flag == DrawKit.FLAG_DRAW)
            {

            }
            else if (flag == DrawKit.FLAG_ERASER)
            {

            }

        }

        public bool GetDot(int x, int y)
        {
            return true;
        }
    }
}