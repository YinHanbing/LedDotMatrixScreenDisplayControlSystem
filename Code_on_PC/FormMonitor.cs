using System.IO.Ports;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public partial class FormMonitor : Form
    {
        private SerialCommunications serialCommunications;

        private delegate void UpdateUI();

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
            DrawKit.InitCanvas(pbMonitor,new DotMatrix16());
            DrawKit.Draw(FormMonitor.pbMonitor, DrawKit.DotMatrix16);
        }

        private void BtnUpdate_Click(object sender, System.EventArgs e)
        {
            serialCommunications.SendUpdate();
        }
    }
}
