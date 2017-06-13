using System.IO.Ports;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplaySystem
{
    public class SerialCommunications
    {
        private SerialPort serialPort;
        private ComboBox cbSerial;

        private SerialPort SerialPort { get => serialPort; set => serialPort = value; }
        private ComboBox CbSerial { get => cbSerial; set => cbSerial = value; }

        public SerialCommunications(SerialPort sp, ComboBox cb)
        {
            SerialPort = sp;
            CbSerial = cb;
        }

        public void SendData(string data)
        {
            SerialPort.Write(data);
        }

        public void InitSerial()
        {
            //检查是否含有串口  
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "错误");
                return;
            }

            //添加串口项目  
            foreach (string s in SerialPort.GetPortNames())
            {
                //获取有多少个COM口  
                CbSerial.Items.Add(s);
            }

            //串口设置默认选择项  
            CbSerial.SelectedIndex = 0;         //设置cbSerial的默认选项  
        }
    }
}