using System.IO.Ports;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public partial class FormMonitor : Form
    {
        public FormMonitor(SerialPort serialPort)
        {
            InitializeComponent();
            this.serialPort = serialPort;
        }

        private void FormMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain.isFormMonitorShown = false;
        }

        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void SerialPort1_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {

        }

        private void SerialPort1_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
        {

        }
    }
}
