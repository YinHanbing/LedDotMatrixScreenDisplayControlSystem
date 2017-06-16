using LedDotMatrixScreenDisplayControlSystemOnPC;
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
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            DrawKit.InitCanvas(pbPicInput);
        }

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            DrawKit.Draw(pbPicInput, serialCommunications.ReceiveData());
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
                DotMatrix16 dotMatrix16 = new DotMatrix16();
                dotMatrix16 = StringToDotMatrix16(tbTextInput.Text);
                serialCommunications.SendData(dotMatrix16);
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
        private DotMatrix16 StringToDotMatrix16(string str)
        {
            DotMatrix16 dotMatrix16 = null;
            return dotMatrix16;
        }
    }
}