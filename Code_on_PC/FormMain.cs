using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public partial class FormMain : Form
    {
        private SerialCommunications serialCommunications;
        private delegate void UpdateUI();

        public FormMain()
        {
            InitializeComponent();
            cbBaudRate.SelectedIndex = 12;
            serialCommunications = new SerialCommunications(serialPort, cbSerialPort, cbBaudRate);
            serialCommunications.ScanSerial();
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {

        }

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            tbDataReceive.Invoke(new UpdateUI(() => { tbDataReceive.AppendText(serialCommunications.ReceiveData()); }));
        }

        private void SerialPort_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {

        }

        private void SerialPort_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
        {

        }

        private void BtnSendData_Click(object sender, System.EventArgs e)
        {
            serialCommunications.SendData(tbDataInput.Text);
        }

        private void TbDataInput_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void BtnPicture_Click(object sender, System.EventArgs e)
        {
            FormPicture fp = new FormPicture(this);
            this.Enabled = false;
            fp.Show();
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
            serialCommunications.OpenSerial();
        }

        private void BtnClearData_Click(object sender, System.EventArgs e)
        {
            tbDataReceive.Clear();
        }

        private void CbBaudRate_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialCommunications.CloseSerial();
                serialCommunications.OpenSerial(); 
            }
        }
    }
}
