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
            this.btnReceiveData = new System.Windows.Forms.Button();
            this.tbDataInput = new System.Windows.Forms.TextBox();
            this.lbDataInput = new System.Windows.Forms.Label();
            this.tbDataReceive = new System.Windows.Forms.TextBox();
            this.lbDataReceive = new System.Windows.Forms.Label();
            this.lbSerialPort = new System.Windows.Forms.Label();
            this.cbSerialPort = new System.Windows.Forms.ComboBox();
            this.btnPicture = new System.Windows.Forms.Button();
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
            // btnReceiveData
            // 
            this.btnReceiveData.Location = new System.Drawing.Point(509, 225);
            this.btnReceiveData.Name = "btnReceiveData";
            this.btnReceiveData.Size = new System.Drawing.Size(75, 23);
            this.btnReceiveData.TabIndex = 6;
            this.btnReceiveData.Text = "接收数据";
            this.btnReceiveData.UseVisualStyleBackColor = true;
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
            this.lbDataInput.Location = new System.Drawing.Point(18, 69);
            this.lbDataInput.Name = "lbDataInput";
            this.lbDataInput.Size = new System.Drawing.Size(94, 23);
            this.lbDataInput.TabIndex = 4;
            this.lbDataInput.Text = "请输入数据：";
            // 
            // tbDataReceive
            // 
            this.tbDataReceive.Location = new System.Drawing.Point(319, 95);
            this.tbDataReceive.Multiline = true;
            this.tbDataReceive.Name = "tbDataReceive";
            this.tbDataReceive.Size = new System.Drawing.Size(265, 124);
            this.tbDataReceive.TabIndex = 3;
            // 
            // lbDataReceive
            // 
            this.lbDataReceive.Location = new System.Drawing.Point(317, 69);
            this.lbDataReceive.Name = "lbDataReceive";
            this.lbDataReceive.Size = new System.Drawing.Size(100, 23);
            this.lbDataReceive.TabIndex = 2;
            this.lbDataReceive.Text = "当前显示内容：";
            // 
            // lbSerialPort
            // 
            this.lbSerialPort.Location = new System.Drawing.Point(18, 9);
            this.lbSerialPort.Name = "lbSerialPort";
            this.lbSerialPort.Size = new System.Drawing.Size(100, 23);
            this.lbSerialPort.TabIndex = 1;
            this.lbSerialPort.Text = "选择串口：";
            // 
            // cbSerialPort
            // 
            this.cbSerialPort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSerialPort.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSerialPort.FormattingEnabled = true;
            this.cbSerialPort.Items.AddRange(new object[] {
            "com1",
            "com2",
            "com3"});
            this.cbSerialPort.Location = new System.Drawing.Point(20, 35);
            this.cbSerialPort.Name = "cbSerialPort";
            this.cbSerialPort.Size = new System.Drawing.Size(265, 20);
            this.cbSerialPort.TabIndex = 0;
            // 
            // btnPicture
            // 
            this.btnPicture.Location = new System.Drawing.Point(509, 33);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(75, 23);
            this.btnPicture.TabIndex = 8;
            this.btnPicture.Text = "图形模式";
            this.btnPicture.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 262);
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.cbSerialPort);
            this.Controls.Add(this.lbSerialPort);
            this.Controls.Add(this.lbDataReceive);
            this.Controls.Add(this.tbDataReceive);
            this.Controls.Add(this.lbDataInput);
            this.Controls.Add(this.tbDataInput);
            this.Controls.Add(this.btnReceiveData);
            this.Controls.Add(this.btnSendData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "LED点阵屏显示控制系统";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Button btnReceiveData;
        private System.Windows.Forms.TextBox tbDataInput;
        private System.Windows.Forms.Label lbDataInput;
        private System.Windows.Forms.TextBox tbDataReceive;
        private System.Windows.Forms.Label lbDataReceive;
        private System.Windows.Forms.Label lbSerialPort;
        private System.Windows.Forms.ComboBox cbSerialPort;
        private System.Windows.Forms.Button btnPicture;
    }
}

