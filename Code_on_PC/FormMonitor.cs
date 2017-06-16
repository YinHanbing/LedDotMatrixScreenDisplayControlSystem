using LedDotMatrixScreenDisplayControlSystemOnPC;
using System.IO.Ports;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public partial class FormMonitor : Form
    {
        private SerialCommunications serialCommunications;

        private delegate void UpdateUI();

        public FormMonitor(SerialPort serialPort, SerialCommunications serialCommunications)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.serialCommunications = serialCommunications;
        }

        private void FormMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain.isFormMonitorShown = false;
        }

        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            serialCommunications.ReceiveData();
            pbMonitor.Invoke(new UpdateUI(() =>
            {
            }));
        }

        private void SerialPort1_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {

        }

        private void SerialPort1_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
        {

        }

        private void FormMonitor_Load(object sender, System.EventArgs e)
        {
            DrawKit.InitCanvas(pbMonitor);
        }
    }
}
