using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public partial class FormMain : Form
    {
        private SerialCommunications serialCommunications;
        private DotMatrix16 dotMatrix16_Send;
        private byte[] textString;
        private int textStringCount;
        private int textStringShowCount;
        private int oldNUDSpeed;
        public static bool isFormMonitorShown;
        public static DotMatrix16 dotMatrix16_Receive;

        public FormMain()
        {
            InitializeComponent();
            cbBaudRate.SelectedIndex = 1;
            oldNUDSpeed = (int)nUDSpeed.Value;
            serialCommunications = new SerialCommunications(serialPort, cbSerialPort, cbBaudRate);
            serialCommunications.ScanSerial();
            isFormMonitorShown = false;
            dotMatrix16_Send = new DotMatrix16();
            dotMatrix16_Receive = new DotMatrix16();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DrawKit.InitCanvas(pbPicInput, dotMatrix16_Send);
            DotMatrix16 d = new DotMatrix16();
            d.DotMatrix = new byte[32]
            {
            0x00,0x00,0x00,0x00,0x0C,0x33,0x0C,0x33,0x0C,0x33,0x0C,0x03,0x0C,0x33,0xFC,0x33,
0xFC,0x33,0x0C,0x33,0x0C,0x33,0x0C,0x33,0x0C,0x33,0x0C,0x33,0x00,0x00,0x00,0x00,
            };
            dotMatrix16_Send = d.ExchangeCode();
            DrawKit.Draw(pbPicInput, dotMatrix16_Send);
        }

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            dotMatrix16_Receive = serialCommunications.ReceiveData();
            if (isFormMonitorShown && FormMonitor.pbMonitor != null)
            {
                DrawKit.Draw(FormMonitor.pbMonitor, dotMatrix16_Receive.ExchangeCode());
            }
        }

        private void SerialPort_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
            System.Console.WriteLine(e);
        }

        private void BtnScan_Click(object sender, EventArgs e)
        {
            serialCommunications.ScanSerial();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialCommunications.CloseSerial();
        }

        private void CbSerialPort_SelectedValueChanged(object sender, EventArgs e)
        {
            if (serialCommunications != null)
            {
                serialCommunications.CloseSerial();
                serialCommunications.OpenSerial();
            }
        }

        private void CbBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialCommunications != null)
            {
                serialCommunications.CloseSerial();
                serialCommunications.OpenSerial();
            }
        }

        private void BtnSendText_Click(object sender, EventArgs e)
        {
            if (tbTextInput.Text.Length != 0)
            {
                if (tbTextInput.Text.Length == 1)
                {
                    timerSpeed.Stop();
                    DotMatrix16[] dotMatrix16s = new DotMatrix16[tbTextInput.Text.Length];
                    dotMatrix16s = StringToDotMatrix16(tbTextInput.Text);

                    if (dotMatrix16s.Length != 0)
                    {
                        serialCommunications.SendData(dotMatrix16s[0].ExchangeCode());
                    }
                    dotMatrix16_Send = dotMatrix16s[0];
                    dotMatrix16_Send.PrintMatrix16();
                    DrawKit.Draw(pbPicInput, dotMatrix16_Send);
                }
                else
                {
                    textStringCount = tbTextInput.Text.Length;
                    DotMatrix16[] dotMatrix16s = new DotMatrix16[tbTextInput.Text.Length];
                    dotMatrix16s = StringToDotMatrix16(tbTextInput.Text);
                    dotMatrix16_Send = dotMatrix16s[0];
                    DrawKit.Draw(pbPicInput, dotMatrix16_Send);
                    textString = new byte[(textStringCount + 2) * 32];
                    for (int i = 0; i < 32; i++)
                    {
                        textString[i] = 0;
                    }
                    for (int i = 0; i < textStringCount; i++)
                    {
                        for (int j = 0; j < 32; j++)
                        {
                            textString[(i + 1) * 32 + j] = dotMatrix16s[i].DotMatrix[j];
                        }
                    }
                    for (int i = 0; i < 32; i++)
                    {
                        textString[(textStringCount + 1) * 32 + i] = 0;
                    }

                    textStringShowCount = 0;
                    timerSpeed.Start();
                }
            }
        }

        private void BtnMonitor_Click(object sender, EventArgs e)
        {
            FormMonitor fm = new FormMonitor(serialCommunications);
            if (!isFormMonitorShown)
            {
                fm.Show();
                isFormMonitorShown = true;
            }
        }

        private void PbPicInput_MouseClick(object sender, MouseEventArgs e)
        {
            GetPointOnDotMatrix(e, out int x, out int y);
            if (x != -1 && y != -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    DrawKit.DrawDot(pbPicInput, dotMatrix16_Send, x, y, DrawKit.FLAG_DRAW);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    DrawKit.DrawDot(pbPicInput, dotMatrix16_Send, x, y, DrawKit.FLAG_ERASE);
                }
            }
        }

        private void BtnCleanPic_Click(object sender, EventArgs e)
        {
            DrawKit.InitCanvas(pbPicInput, dotMatrix16_Send);
        }

        private void BtnCleanText_Click(object sender, EventArgs e)
        {
            tbTextInput.Text = "";
        }

        private void BtnSendPic_Click(object sender, EventArgs e)
        {
            timerSpeed.Stop();
            serialCommunications.SendData(dotMatrix16_Send.ExchangeCode());
        }

        private void BtnUpMove_Click(object sender, EventArgs e)
        {
            dotMatrix16_Send.UpMove();
            DrawKit.Draw(pbPicInput, dotMatrix16_Send);
            serialCommunications.SendData(dotMatrix16_Send.ExchangeCode());
        }

        private void BtnDownMove_Click(object sender, EventArgs e)
        {
            dotMatrix16_Send.DownMove();
            DrawKit.Draw(pbPicInput, dotMatrix16_Send);
            serialCommunications.SendData(dotMatrix16_Send.ExchangeCode());
        }

        private void BtnLeftMove_Click(object sender, EventArgs e)
        {
            dotMatrix16_Send.LeftMove();
            DrawKit.Draw(pbPicInput, dotMatrix16_Send);
            serialCommunications.SendData(dotMatrix16_Send.ExchangeCode());
        }

        private void BtnRightMove_Click(object sender, EventArgs e)
        {
            dotMatrix16_Send.RightMove();
            DrawKit.Draw(pbPicInput, dotMatrix16_Send);
            serialCommunications.SendData(dotMatrix16_Send.ExchangeCode());
        }

        private void TimerSpeed_Tick(object sender, EventArgs e)
        {
            if (textStringShowCount < (textStringCount + 1) * 32)
            {
                DotMatrix16 dotMatrix16 = new DotMatrix16();
                for (int i = 0; i < 32; i++)
                {
                    dotMatrix16.DotMatrix[i] = textString[i + textStringShowCount];
                }
                serialCommunications.SendData(dotMatrix16.ExchangeCode());
                textStringShowCount += 2;
            }
            else
            {
                textStringShowCount = 0;
            }
        }

        private void NUDSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (nUDSpeed.Value > oldNUDSpeed)
            {
                timerSpeed.Interval = timerSpeed.Interval - 20;
            }
            else
            {
                timerSpeed.Interval = timerSpeed.Interval + 20;
            }
            oldNUDSpeed = (int)nUDSpeed.Value;
        }

        private void PbPicInput_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                GetPointOnDotMatrix(e, out int x, out int y);
                if (x != -1 && y != -1)
                {
                    DrawKit.DrawDot(pbPicInput, dotMatrix16_Send, x, y, DrawKit.FLAG_DRAW);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                GetPointOnDotMatrix(e, out int x, out int y);
                if (x != -1 && y != -1)
                {
                    DrawKit.DrawDot(pbPicInput, dotMatrix16_Send, x, y, DrawKit.FLAG_ERASE);
                }
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
            string[] stringTarget = new string[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                Bitmap bmp = new Bitmap(16, 16);
                Graphics g = Graphics.FromImage(bmp);
                g.FillRectangle(Brushes.White, new Rectangle() { X = 0, Y = 0, Height = 16, Width = 16 });
                string wordstring = tbTextInput.Text.Substring(i, 1);
                if (Regex.IsMatch(wordstring, "[\u4e00-\u9fa5]"))
                {
                    g.DrawString(wordstring, tbTextInput.Font, Brushes.Black, new PointF() { X = Convert.ToSingle(0), Y = Convert.ToSingle(2) });
                }
                else if (Regex.IsMatch(wordstring, "[0-9]"))
                {
                    g.DrawString(wordstring, tbTextInput.Font, Brushes.Black, new PointF() { X = Convert.ToSingle(4), Y = Convert.ToSingle(2) });
                }
                else
                {
                    g.DrawString(wordstring, tbTextInput.Font, Brushes.Black, new PointF() { X = Convert.ToSingle(3), Y = Convert.ToSingle(0) });
                }

                stringTarget[i] = string.Join("", Enumerable.Range(0, 256).Select(a => new { x = a % 16, y = a / 16 })
                    .Select(x => bmp.GetPixel(x.x, x.y).GetBrightness() > 0.5f ? "0" : "1"));
                Console.WriteLine(stringTarget[i]);
                dotMatrix16s[i] = new DotMatrix16();
                for (int j = 0; j < 32; j++)
                {
                    int intbyte = 0;
                    for (int k = 0; k < 8; k++)
                    {
                        intbyte += Convert.ToInt16((stringTarget[i].Substring(j * 8, 8).Substring(k, 1))) * (int)Math.Pow(2, 7 - k);
                    }
                    dotMatrix16s[i].DotMatrix[j] = Convert.ToByte(intbyte);
                }
                dotMatrix16s[i].PrintMatrix16();
            }

            return dotMatrix16s;
        }

        /// <summary>
        /// 得到鼠标在点阵中的位置
        /// </summary>
        /// <param name="e"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void GetPointOnDotMatrix(MouseEventArgs e, out int x, out int y)
        {
            // 初始化位置
            x = y = -1;
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
        }
    }
}