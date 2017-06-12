using System.Resources;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public partial class FormMain : Form
    {
        private ResourceManager res = new ResourceManager(typeof(FormMain));

        public FormMain()
        {
            InitializeComponent();
            this.Text = Res.GetString("StringAppName");
        }

        private ResourceManager Res { get => res; }
    }
}
