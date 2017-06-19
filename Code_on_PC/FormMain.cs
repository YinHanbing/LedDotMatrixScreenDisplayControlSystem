using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public partial class FormMain : Form
    {
        private SerialCommunications serialCommunications;
        private delegate void UpdateUI();
        public static bool isFormMonitorShown;

        public FormMain()
        {
            InitializeComponent();
            cbBaudRate.SelectedIndex = 2;
            serialCommunications = new SerialCommunications(serialPort, cbSerialPort, cbBaudRate);
            serialCommunications.ScanSerial();
            isFormMonitorShown = false;
            DrawKit.DotMatrix16 = new DotMatrix16();
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            DrawKit.InitCanvas(pbPicInput, DrawKit.DotMatrix16);
        }

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void SerialPort_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
            System.Console.WriteLine(e);
        }

        private void BtnScan_Click(object sender, System.EventArgs e)
        {
            serialCommunications.ScanSerial();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialCommunications.CloseSerial();
        }

        private void CbSerialPort_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (serialCommunications != null)
            {
                serialCommunications.CloseSerial();
                serialCommunications.OpenSerial();
            }
        }

        private void CbBaudRate_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (serialCommunications != null)
            {
                serialCommunications.CloseSerial();
                serialCommunications.OpenSerial();
            }
        }

        private void BtnSendText_Click(object sender, System.EventArgs e)
        {
            if (tbTextInput.Text.Length != 0)
            {
                DotMatrix16[] dotMatrix16s = new DotMatrix16[tbTextInput.Text.Length];
                dotMatrix16s = StringToDotMatrix16(tbTextInput.Text);
                for (int i = 0; i < tbTextInput.Text.Length; i++)
                {
                    if (dotMatrix16s.Length != 0)
                    {
                        serialCommunications.SendData(dotMatrix16s[i]);
                    }
                }
            }
        }

        private void BtnMonitor_Click(object sender, System.EventArgs e)
        {
            FormMonitor fm = new FormMonitor(serialPort, serialCommunications);
            if (!isFormMonitorShown)
            {
                fm.Show();
                isFormMonitorShown = true;
            }
        }

        /// <summary>
        /// 将字符串转换成点阵数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns>DotMatrix16</returns>
        private DotMatrix16[] StringToDotMatrix16(string str)
        {
            DotMatrix16[] dotMatrix16s = new DotMatrix16[str.Length];
            Bitmap bmp = new Bitmap(16, 16);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, new Rectangle() { X = 0, Y = 0, Height = 16, Width = 16 });
            g.DrawString(tbTextInput.Text, tbTextInput.Font, Brushes.Black, new PointF() { X = Convert.ToSingle(0), Y = Convert.ToSingle(0) });
            string stringbin = string.Join("", Enumerable.Range(0, 256).Select(a => new { x = a % 16, y = a / 16 })
                .Select(x => bmp.GetPixel(x.x, x.y).GetBrightness() > 0.5f ? "0" : "1"));
            Console.WriteLine(stringbin);

            string[] stringTarget = new string[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                stringTarget[i] = stringbin.Substring(i * 256, (i + 1) * 256);
                //dotMatrix16s[i].DotMatrix = Byte
            }
            return dotMatrix16s;
        }

        private void PbPicInput_MouseClick(object sender, MouseEventArgs e)
        {
            int x = -1, y = -1; // 初始化位置

            // 确定鼠标位置
            for (int i = 0; i < 16; i++)
            {
                if (i * 16 <= e.Y && e.Y <= (i + 1) * 16)
                {
                    y = i;
                    break;
                }
            }
            for (int j = 0; j < 16; j++)
            {
                if (j * 16 <= e.X && e.X <= (j + 1) * 16)
                {
                    x = j;
                    break;
                }
            }
            if (x != -1 && y != -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    DrawKit.DrawDot(pbPicInput, DrawKit.DotMatrix16, x, y, DrawKit.FLAG_DRAW);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    DrawKit.DrawDot(pbPicInput, DrawKit.DotMatrix16, x, y, DrawKit.FLAG_ERASE);
                }
            }
        }

        private void BtnClean_Click(object sender, System.EventArgs e)
        {
            DrawKit.InitCanvas(pbPicInput, DrawKit.DotMatrix16);
        }

        private void BtnCleanText_Click(object sender, System.EventArgs e)
        {
            tbTextInput.Text = "";
        }

        private void BtnSendPic_Click(object sender, System.EventArgs e)
        {
            serialCommunications.SendData(DrawKit.DotMatrix16);
        }
    }
}