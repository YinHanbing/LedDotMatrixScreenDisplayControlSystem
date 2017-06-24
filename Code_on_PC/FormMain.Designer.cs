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
            this.btnSendText = new System.Windows.Forms.Button();
            this.btnSendPic = new System.Windows.Forms.Button();
            this.tbTextInput = new System.Windows.Forms.TextBox();
            this.lbTextInput = new System.Windows.Forms.Label();
            this.lbPicInput = new System.Windows.Forms.Label();
            this.lbSerialPort = new System.Windows.Forms.Label();
            this.cbSerialPort = new System.Windows.Forms.ComboBox();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.lbBautRate = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.pbPicInput = new System.Windows.Forms.PictureBox();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.btnCleanPic = new System.Windows.Forms.Button();
            this.btnCleanText = new System.Windows.Forms.Button();
            this.btnUpMove = new System.Windows.Forms.Button();
            this.btnDownMove = new System.Windows.Forms.Button();
            this.btnLeftMove = new System.Windows.Forms.Button();
            this.btnRightMove = new System.Windows.Forms.Button();
            this.timerSpeed = new System.Windows.Forms.Timer(this.components);
            this.nUDSpeed = new System.Windows.Forms.NumericUpDown();
            this.toolTipSpeed = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPicInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.SerialPort_ErrorReceived);
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // btnSendText
            // 
            this.btnSendText.Location = new System.Drawing.Point(20, 366);
            this.btnSendText.Name = "btnSendText";
            this.btnSendText.Size = new System.Drawing.Size(66, 23);
            this.btnSendText.TabIndex = 5;
            this.btnSendText.Text = "发送文字";
            this.btnSendText.UseVisualStyleBackColor = true;
            this.btnSendText.Click += new System.EventHandler(this.BtnSendText_Click);
            // 
            // btnSendPic
            // 
            this.btnSendPic.Location = new System.Drawing.Point(319, 366);
            this.btnSendPic.Name = "btnSendPic";
            this.btnSendPic.Size = new System.Drawing.Size(66, 23);
            this.btnSendPic.TabIndex = 7;
            this.btnSendPic.Text = "发送图片";
            this.btnSendPic.UseVisualStyleBackColor = true;
            this.btnSendPic.Click += new System.EventHandler(this.BtnSendPic_Click);
            // 
            // tbTextInput
            // 
            this.tbTextInput.Location = new System.Drawing.Point(20, 95);
            this.tbTextInput.MaxLength = 500;
            this.tbTextInput.Multiline = true;
            this.tbTextInput.Name = "tbTextInput";
            this.tbTextInput.Size = new System.Drawing.Size(257, 257);
            this.tbTextInput.TabIndex = 4;
            // 
            // lbTextInput
            // 
            this.lbTextInput.AutoSize = true;
            this.lbTextInput.Location = new System.Drawing.Point(18, 80);
            this.lbTextInput.Name = "lbTextInput";
            this.lbTextInput.Size = new System.Drawing.Size(77, 12);
            this.lbTextInput.TabIndex = 3;
            this.lbTextInput.Text = "文本输入区：";
            // 
            // lbPicInput
            // 
            this.lbPicInput.AutoSize = true;
            this.lbPicInput.Location = new System.Drawing.Point(317, 80);
            this.lbPicInput.Name = "lbPicInput";
            this.lbPicInput.Size = new System.Drawing.Size(77, 12);
            this.lbPicInput.TabIndex = 4;
            this.lbPicInput.Text = "图案绘制区：";
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
            "没有可用串口"});
            this.cbSerialPort.Location = new System.Drawing.Point(20, 39);
            this.cbSerialPort.Name = "cbSerialPort";
            this.cbSerialPort.Size = new System.Drawing.Size(174, 20);
            this.cbSerialPort.TabIndex = 0;
            this.cbSerialPort.SelectedValueChanged += new System.EventHandler(this.CbSerialPort_SelectedValueChanged);
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "115200",
            "57600",
            "19200",
            "9600",
            "4800",
            "2400"});
            this.cbBaudRate.Location = new System.Drawing.Point(319, 39);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(174, 20);
            this.cbBaudRate.TabIndex = 2;
            this.cbBaudRate.SelectedIndexChanged += new System.EventHandler(this.CbBaudRate_SelectedIndexChanged);
            // 
            // lbBautRate
            // 
            this.lbBautRate.AutoSize = true;
            this.lbBautRate.Location = new System.Drawing.Point(317, 20);
            this.lbBautRate.Name = "lbBautRate";
            this.lbBautRate.Size = new System.Drawing.Size(77, 12);
            this.lbBautRate.TabIndex = 2;
            this.lbBautRate.Text = "选择波特率：";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(211, 37);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(66, 23);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "扫描串口";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.BtnScan_Click);
            // 
            // pbPicInput
            // 
            this.pbPicInput.Location = new System.Drawing.Point(319, 95);
            this.pbPicInput.Name = "pbPicInput";
            this.pbPicInput.Size = new System.Drawing.Size(257, 257);
            this.pbPicInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPicInput.TabIndex = 12;
            this.pbPicInput.TabStop = false;
            this.pbPicInput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbPicInput_MouseClick);
            this.pbPicInput.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbPicInput_MouseMove);
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(510, 37);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(66, 23);
            this.btnMonitor.TabIndex = 3;
            this.btnMonitor.Text = "监视点阵";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.BtnMonitor_Click);
            // 
            // btnCleanPic
            // 
            this.btnCleanPic.Location = new System.Drawing.Point(510, 366);
            this.btnCleanPic.Name = "btnCleanPic";
            this.btnCleanPic.Size = new System.Drawing.Size(66, 23);
            this.btnCleanPic.TabIndex = 8;
            this.btnCleanPic.Text = "清除图案";
            this.btnCleanPic.UseVisualStyleBackColor = true;
            this.btnCleanPic.Click += new System.EventHandler(this.BtnCleanPic_Click);
            // 
            // btnCleanText
            // 
            this.btnCleanText.Location = new System.Drawing.Point(211, 366);
            this.btnCleanText.Name = "btnCleanText";
            this.btnCleanText.Size = new System.Drawing.Size(66, 23);
            this.btnCleanText.TabIndex = 6;
            this.btnCleanText.Text = "清空文字";
            this.btnCleanText.UseVisualStyleBackColor = true;
            this.btnCleanText.Click += new System.EventHandler(this.BtnCleanText_Click);
            // 
            // btnUpMove
            // 
            this.btnUpMove.Location = new System.Drawing.Point(283, 144);
            this.btnUpMove.Name = "btnUpMove";
            this.btnUpMove.Size = new System.Drawing.Size(30, 23);
            this.btnUpMove.TabIndex = 13;
            this.btnUpMove.Text = "↑";
            this.btnUpMove.UseVisualStyleBackColor = true;
            this.btnUpMove.Click += new System.EventHandler(this.BtnUpMove_Click);
            // 
            // btnDownMove
            // 
            this.btnDownMove.Location = new System.Drawing.Point(283, 173);
            this.btnDownMove.Name = "btnDownMove";
            this.btnDownMove.Size = new System.Drawing.Size(30, 23);
            this.btnDownMove.TabIndex = 14;
            this.btnDownMove.Text = "↓";
            this.btnDownMove.UseVisualStyleBackColor = true;
            this.btnDownMove.Click += new System.EventHandler(this.BtnDownMove_Click);
            // 
            // btnLeftMove
            // 
            this.btnLeftMove.Location = new System.Drawing.Point(283, 202);
            this.btnLeftMove.Name = "btnLeftMove";
            this.btnLeftMove.Size = new System.Drawing.Size(30, 23);
            this.btnLeftMove.TabIndex = 15;
            this.btnLeftMove.Text = "←";
            this.btnLeftMove.UseVisualStyleBackColor = true;
            this.btnLeftMove.Click += new System.EventHandler(this.BtnLeftMove_Click);
            // 
            // btnRightMove
            // 
            this.btnRightMove.Location = new System.Drawing.Point(283, 231);
            this.btnRightMove.Name = "btnRightMove";
            this.btnRightMove.Size = new System.Drawing.Size(30, 23);
            this.btnRightMove.TabIndex = 16;
            this.btnRightMove.Text = "→";
            this.btnRightMove.UseVisualStyleBackColor = true;
            this.btnRightMove.Click += new System.EventHandler(this.BtnRightMove_Click);
            // 
            // timerSpeed
            // 
            this.timerSpeed.Interval = 300;
            this.timerSpeed.Tick += new System.EventHandler(this.TimerSpeed_Tick);
            // 
            // nUDSpeed
            // 
            this.nUDSpeed.Location = new System.Drawing.Point(283, 260);
            this.nUDSpeed.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nUDSpeed.Name = "nUDSpeed";
            this.nUDSpeed.ReadOnly = true;
            this.nUDSpeed.Size = new System.Drawing.Size(29, 21);
            this.nUDSpeed.TabIndex = 17;
            this.toolTipSpeed.SetToolTip(this.nUDSpeed, "调速");
            this.nUDSpeed.ValueChanged += new System.EventHandler(this.NUDSpeed_ValueChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 410);
            this.Controls.Add(this.nUDSpeed);
            this.Controls.Add(this.btnRightMove);
            this.Controls.Add(this.btnLeftMove);
            this.Controls.Add(this.btnDownMove);
            this.Controls.Add(this.btnUpMove);
            this.Controls.Add(this.btnCleanText);
            this.Controls.Add(this.btnCleanPic);
            this.Controls.Add(this.btnMonitor);
            this.Controls.Add(this.pbPicInput);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.lbTextInput);
            this.Controls.Add(this.lbBautRate);
            this.Controls.Add(this.cbBaudRate);
            this.Controls.Add(this.cbSerialPort);
            this.Controls.Add(this.lbSerialPort);
            this.Controls.Add(this.tbTextInput);
            this.Controls.Add(this.btnSendPic);
            this.Controls.Add(this.btnSendText);
            this.Controls.Add(this.lbPicInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LED点阵屏显示控制系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPicInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnSendText;
        private System.Windows.Forms.Button btnSendPic;
        private System.Windows.Forms.TextBox tbTextInput;
        private System.Windows.Forms.Label lbTextInput;
        private System.Windows.Forms.Label lbPicInput;
        private System.Windows.Forms.Label lbSerialPort;
        private System.Windows.Forms.ComboBox cbSerialPort;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label lbBautRate;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.PictureBox pbPicInput;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.Button btnCleanPic;
        private System.Windows.Forms.Button btnCleanText;
        private System.Windows.Forms.Button btnUpMove;
        private System.Windows.Forms.Button btnDownMove;
        private System.Windows.Forms.Button btnLeftMove;
        private System.Windows.Forms.Button btnRightMove;
        private System.Windows.Forms.Timer timerSpeed;
        private System.Windows.Forms.NumericUpDown nUDSpeed;
        private System.Windows.Forms.ToolTip toolTipSpeed;
    }
}

