namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.btnSendData = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.tbDataInput = new System.Windows.Forms.TextBox();
            this.lbDataInput = new System.Windows.Forms.Label();
            this.tbDataReceive = new System.Windows.Forms.TextBox();
            this.lbDataReceive = new System.Windows.Forms.Label();
            this.lbSerialPort = new System.Windows.Forms.Label();
            this.cbSerialPort = new System.Windows.Forms.ComboBox();
            this.btnPicture = new System.Windows.Forms.Button();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.lbBautRate = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.SerialPort_ErrorReceived);
            this.serialPort.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(this.SerialPort_PinChanged);
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(210, 225);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(75, 23);
            this.btnSendData.TabIndex = 7;
            this.btnSendData.Text = "发送数据";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.BtnSendData_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(509, 225);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(75, 23);
            this.btnClearData.TabIndex = 6;
            this.btnClearData.Text = "清除数据";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.BtnClearData_Click);
            // 
            // tbDataInput
            // 
            this.tbDataInput.Location = new System.Drawing.Point(20, 95);
            this.tbDataInput.Multiline = true;
            this.tbDataInput.Name = "tbDataInput";
            this.tbDataInput.Size = new System.Drawing.Size(265, 124);
            this.tbDataInput.TabIndex = 5;
            this.tbDataInput.TextChanged += new System.EventHandler(this.TbDataInput_TextChanged);
            // 
            // lbDataInput
            // 
            this.lbDataInput.AutoSize = true;
            this.lbDataInput.Location = new System.Drawing.Point(18, 80);
            this.lbDataInput.Name = "lbDataInput";
            this.lbDataInput.Size = new System.Drawing.Size(77, 12);
            this.lbDataInput.TabIndex = 4;
            this.lbDataInput.Text = "请输入数据：";
            // 
            // tbDataReceive
            // 
            this.tbDataReceive.BackColor = System.Drawing.SystemColors.Window;
            this.tbDataReceive.Location = new System.Drawing.Point(319, 95);
            this.tbDataReceive.Multiline = true;
            this.tbDataReceive.Name = "tbDataReceive";
            this.tbDataReceive.ReadOnly = true;
            this.tbDataReceive.Size = new System.Drawing.Size(265, 124);
            this.tbDataReceive.TabIndex = 3;
            // 
            // lbDataReceive
            // 
            this.lbDataReceive.AutoSize = true;
            this.lbDataReceive.Location = new System.Drawing.Point(317, 80);
            this.lbDataReceive.Name = "lbDataReceive";
            this.lbDataReceive.Size = new System.Drawing.Size(89, 12);
            this.lbDataReceive.TabIndex = 2;
            this.lbDataReceive.Text = "当前显示内容：";
            // 
            // lbSerialPort
            // 
            this.lbSerialPort.AutoSize = true;
            this.lbSerialPort.Location = new System.Drawing.Point(18, 20);
            this.lbSerialPort.Name = "lbSerialPort";
            this.lbSerialPort.Size = new System.Drawing.Size(65, 12);
            this.lbSerialPort.TabIndex = 1;
            this.lbSerialPort.Text = "选择串口：";
            // 
            // cbSerialPort
            // 
            this.cbSerialPort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSerialPort.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSerialPort.FormattingEnabled = true;
            this.cbSerialPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3"});
            this.cbSerialPort.Location = new System.Drawing.Point(20, 39);
            this.cbSerialPort.Name = "cbSerialPort";
            this.cbSerialPort.Size = new System.Drawing.Size(174, 20);
            this.cbSerialPort.TabIndex = 0;
            this.cbSerialPort.SelectedValueChanged += new System.EventHandler(this.CbSerialPort_SelectedValueChanged);
            // 
            // btnPicture
            // 
            this.btnPicture.Location = new System.Drawing.Point(509, 37);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(75, 23);
            this.btnPicture.TabIndex = 8;
            this.btnPicture.Text = "图形模式";
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.BtnPicture_Click);
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "864000",
            "691200",
            "576000",
            "460800",
            "256000",
            "128000",
            "115200",
            "56700",
            "38400",
            "28800",
            "19200",
            "9600",
            "4800"});
            this.cbBaudRate.Location = new System.Drawing.Point(319, 39);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(174, 20);
            this.cbBaudRate.TabIndex = 9;
            this.cbBaudRate.SelectedIndexChanged += new System.EventHandler(this.CbBaudRate_SelectedIndexChanged);
            // 
            // lbBautRate
            // 
            this.lbBautRate.AutoSize = true;
            this.lbBautRate.Location = new System.Drawing.Point(317, 20);
            this.lbBautRate.Name = "lbBautRate";
            this.lbBautRate.Size = new System.Drawing.Size(77, 12);
            this.lbBautRate.TabIndex = 10;
            this.lbBautRate.Text = "选择波特率：";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(210, 37);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 11;
            this.btnScan.Text = "扫描串口";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.BtnScan_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 262);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.lbDataInput);
            this.Controls.Add(this.lbBautRate);
            this.Controls.Add(this.cbBaudRate);
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.cbSerialPort);
            this.Controls.Add(this.lbSerialPort);
            this.Controls.Add(this.tbDataReceive);
            this.Controls.Add(this.tbDataInput);
            this.Controls.Add(this.btnClearData);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.lbDataReceive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LED点阵屏显示控制系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.TextBox tbDataInput;
        private System.Windows.Forms.Label lbDataInput;
        private System.Windows.Forms.TextBox tbDataReceive;
        private System.Windows.Forms.Label lbDataReceive;
        private System.Windows.Forms.Label lbSerialPort;
        private System.Windows.Forms.ComboBox cbSerialPort;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label lbBautRate;
        private System.Windows.Forms.Button btnScan;
    }
}

