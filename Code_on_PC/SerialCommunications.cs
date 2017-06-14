using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public class SerialCommunications
    {
        private SerialPort serialPort;
        private ComboBox cbSerial;
        private ComboBox cbBautRate;

        public SerialCommunications(SerialPort serialPort, ComboBox cbSerial, ComboBox cbBautRate)
        {
            this.serialPort = serialPort;
            this.cbSerial = cbSerial;
            this.cbBautRate = cbBautRate;
        }

        public void SendData(string data)
        {
            serialPort.Write(data);
        }

        public string ReceiveData()
        {
            string data = "";
            System.Threading.Thread.Sleep(100);
            byte[] m_recvBytes = new byte[serialPort.BytesToRead];//定义缓冲区大小
            int result = serialPort.Read(m_recvBytes, 0, m_recvBytes.Length);//从串口读取数据
            if (result <= 0)
                return data;
            data = Encoding.ASCII.GetString(m_recvBytes, 0, m_recvBytes.Length);//对数据进行转换
            serialPort.DiscardInBuffer();
            return data;
        }

        public void ScanSerial()
        {

            cbSerial.Items.Clear();
            // 检查是否含有串口  
            string[] str = SerialPort.GetPortNames();
            if (str.Length == 0)
            {
                cbSerial.Items.Add("没有可用串口");
            }

            // 添加串口项目  
            foreach (string s in SerialPort.GetPortNames())
            {
                // 获取有多少个COM口  
                cbSerial.Items.Add(s);
            }

            // 串口设置默认选择项  
            cbSerial.SelectedIndex = 0;         // 设置cbSerial的默认选项  
        }

        public void OpenSerial()
        {
            if (!serialPort.IsOpen)
            {
                serialPort.PortName = cbSerial.SelectedItem.ToString();//串口名  
                System.Console.WriteLine(cbBautRate.SelectedItem);
                serialPort.BaudRate = int.Parse(cbBautRate.SelectedItem.ToString());
                serialPort.DataBits = 8;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                serialPort.Open();
                System.Console.WriteLine("opened");
            }
        }

        public void CloseSerial()
        {
            serialPort.Close();
        }
    }
}