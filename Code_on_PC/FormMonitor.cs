using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public partial class FormMonitor : Form
    {
        private SerialCommunications serialCommunications;

        public FormMonitor(SerialCommunications serialCommunications)
        {
            InitializeComponent();
            this.serialCommunications = serialCommunications;
        }

        private void FormMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain.isFormMonitorShown = false;
        }

        private void FormMonitor_Load(object sender, System.EventArgs e)
        {
            DrawKit.Draw(FormMonitor.pbMonitor, FormMain.dotMatrix16_Receive.ExchangeCode());
        }
    }
}
