using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public partial class FormMain : Form
    {
        private SerialCommunications serialCommunications;

        public FormMain()
        {
            InitializeComponent();
            cbBaudRate.SelectedIndex = 11;
            serialCommunications = new SerialCommunications(serialPort, cbSerialPort, cbBaudRate);
            serialCommunications.InitSerial();
        }


        private void CbSerialPort_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            serialPort.Open();
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {

        }

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void SerialPort_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {

        }

        private void SerialPort_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
        {

        }

        private void BtnSendData_Click(object sender, System.EventArgs e)
        {

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
    }
}
