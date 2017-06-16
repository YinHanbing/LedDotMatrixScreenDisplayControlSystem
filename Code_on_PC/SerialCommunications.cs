using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    public class SerialCommunications
    {
        private SerialPort serialPort;
        private ComboBox cbSerial;
        private ComboBox cbBautRate;
        private Thread Worker;

        private delegate void UpdateUI();

        public SerialCommunications(SerialPort serialPort, ComboBox cbSerial, ComboBox cbBautRate)
        {
            this.serialPort = serialPort;
            this.cbSerial = cbSerial;
            this.cbBautRate = cbBautRate;
        }

        public void SendData(DotMatrix16 data)
        {
            if (data != null)
            {
                serialPort.Write(data.DotMatrix, 0, 32); 
            }
        }

        public DotMatrix16 ReceiveData()
        {
            DotMatrix16 dotMatrix16 = null;
            byte[] m_recvBytes = new byte[serialPort.BytesToRead];//定义缓冲区大小
            for (int i = 0; i < 32; i++)
            {
                System.Threading.Thread.Sleep(100);
                int result = serialPort.Read(m_recvBytes, 0, m_recvBytes.Length);//从串口读取数据 
            }
            serialPort.DiscardInBuffer();
            dotMatrix16.DotMatrix = m_recvBytes;

            System.Console.WriteLine(dotMatrix16.DotMatrix);

            return dotMatrix16;
        }

        public void ScanSerial()
        {
            if (Worker == null)
            {
                Worker = new Thread(() =>
                    {
                        while (true)
                        {
                            if (cbSerial.IsHandleCreated)
                            {
                                int oldPortNamesLength = 0;
                                while (true)
                                {
                                    if (SerialPort.GetPortNames().Length != oldPortNamesLength)
                                    {
                                        cbSerial.BeginInvoke(new UpdateUI(() =>
                                        {
                                            cbSerial.Items.Clear();
                                        }));
                                        // 检查是否含有串口  
                                        string[] str = SerialPort.GetPortNames();
                                        if (str.Length == 0)
                                        {
                                            cbSerial.BeginInvoke(new UpdateUI(() =>
                                            {
                                                cbSerial.Items.Add("没有可用串口");
                                            }));
                                        }

                                        // 添加串口项目  
                                        foreach (string s in SerialPort.GetPortNames())
                                        {
                                            // 获取有多少个COM口  
                                            cbSerial.BeginInvoke(new UpdateUI(() =>
                                            {
                                                cbSerial.Items.Add(s);
                                            }));
                                        }

                                        // 更新oldPortNamesLengt
                                        oldPortNamesLength = SerialPort.GetPortNames().Length;

                                        // 串口设置默认选择项  
                                        cbSerial.BeginInvoke(new UpdateUI(() =>
                                        {
                                            cbSerial.SelectedIndex = 0;         // 设置cbSerial的默认选项  
                                        }));
                                    }
                                    Thread.Sleep(500);
                                }
                            }
                        }
                    })
                {
                    IsBackground = true,
                    Name = "Worker"
                };
                Worker.Start();
            }
        }

        public void OpenSerial()
        {
            if (!serialPort.IsOpen && SerialPort.GetPortNames().Length != 0)
            {
                serialPort.PortName = cbSerial.SelectedItem.ToString();//串口名  
                System.Console.WriteLine(cbBautRate.SelectedItem);
                serialPort.BaudRate = int.Parse(cbBautRate.SelectedItem.ToString());
                serialPort.DataBits = 8;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                new Thread(() =>
                {
                    serialPort.Open();
                }).Start();
                System.Console.WriteLine("opened");
            }
        }

        public void CloseSerial()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
    }
}