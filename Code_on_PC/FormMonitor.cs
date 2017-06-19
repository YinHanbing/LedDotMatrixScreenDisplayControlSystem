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

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            DotMatrix16 dotMatrix16 = serialCommunications.ReceiveData();
            pbMonitor.Invoke(new UpdateUI(() =>
            {
                DrawKit.Draw(pbMonitor, dotMatrix16);
            }));
        }

        private void SerialPort_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {

        }

        private void SerialPort_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
        {

        }

        private void FormMonitor_Load(object sender, System.EventArgs e)
        {
            DrawKit.InitCanvas(pbMonitor,DrawKit.DotMatrix16);
        }

        private void BtnUpdate_Click(object sender, System.EventArgs e)
        {
            serialCommunications.SendUpdate();
        }
    }
}
