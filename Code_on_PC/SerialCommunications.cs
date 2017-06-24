using System.IO.Ports;
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

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data">DotMatrix16</param>
        public void SendData(DotMatrix16 data)
        {
            if (data != null && serialPort.IsOpen)
            {
                serialPort.Write(data.DotMatrix, 0, 32);
                System.Console.WriteLine("Sent");
            }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <returns>DotMatrix16</returns>
        public DotMatrix16 ReceiveData()
        {
            DotMatrix16 dotMatrix16 = new DotMatrix16();
            if (serialPort.IsOpen)
            {
                byte[] m_recvBytes = new byte[32];//定义缓冲区大小
                try
                {
                    int result = serialPort.Read(m_recvBytes, 0, m_recvBytes.Length);//从串口读取数据 
                    System.Console.WriteLine(result);
                    if (result == 32)
                    {
                        dotMatrix16.DotMatrix = m_recvBytes;
                    }
                    else if (result == 31)
                    {
                        dotMatrix16.DotMatrix[0] = 0;
                        for (int i = 0; i < 31; i++)
                        {
                            dotMatrix16.DotMatrix[i + 1] = m_recvBytes[i];
                        }
                    }
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("IO Error");
                    serialPort.DiscardInBuffer();
                }
            }

            System.Console.WriteLine("Received");
            dotMatrix16.PrintMatrix16();

            return dotMatrix16;
        }

        /// <summary>
        /// 扫描串口
        /// </summary>
        public void ScanSerial()
        {
            cbSerial.SelectedIndex = 0;
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

        /// <summary>
        /// 开启串口
        /// </summary>
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
                    if (serialPort.PortName.Contains("COM"))
                    {
                        if (!serialPort.IsOpen)
                        {
                            serialPort.Open();
                        }
                    }
                }).Start();
                System.Console.WriteLine("opened");
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void CloseSerial()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
    }
}