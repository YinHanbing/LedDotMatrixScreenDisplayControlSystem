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
    }
}