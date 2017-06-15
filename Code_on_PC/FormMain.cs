using LedDotMatrixScreenDisplaySystemOnPC;
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
            byte data = serialCommunications.ReceiveData();
            DrawKit.Draw(pbPicInput, data);
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
                if (serialPort.IsOpen)
                {
                    serialCommunications.CloseSerial();
                    serialCommunications.OpenSerial();
                }
                else
                {
                    serialCommunications.OpenSerial();
                }
            }
        }

        private void CbBaudRate_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (serialCommunications != null)
            {
                if (serialPort.IsOpen)
                {
                    serialCommunications.CloseSerial();
                    serialCommunications.OpenSerial();
                }
                else
                {
                    serialCommunications.OpenSerial();
                } 
            }
        }

        private void BtnSendText_Click(object sender, System.EventArgs e)
        {
            if (tbTextInput.Text.Length != 0)
            {
                serialCommunications.SendData(tbTextInput.Text);
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
    }
}