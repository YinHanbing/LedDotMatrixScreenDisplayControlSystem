using System.IO.Ports;
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

        public void InitSerial()
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
                System.Console.WriteLine("s");
            }

            // 串口设置默认选择项  
            cbSerial.SelectedIndex = 0;         // 设置cbSerial的默认选项  
        }

        public void Open()
        {
            serialPort.PortName = cbSerial.SelectedItem.ToString();//串口名  
            serialPort.BaudRate = (int)cbBautRate.SelectedValue;
            serialPort.DataBits = (int)8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.Open();
        }
    }
}