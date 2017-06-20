namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    partial class FormMonitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FormMonitor.pbMonitor = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(FormMonitor.pbMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMonitor
            // 
            FormMonitor.pbMonitor.Location = new System.Drawing.Point(12, 12);
            FormMonitor.pbMonitor.Name = "pbMonitor";
            FormMonitor.pbMonitor.Size = new System.Drawing.Size(257, 257);
            FormMonitor.pbMonitor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            FormMonitor.pbMonitor.TabIndex = 0;
            FormMonitor.pbMonitor.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(194, 275);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "更新数据";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // FormMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 305);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(FormMonitor.pbMonitor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "监视点阵屏";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMonitor_FormClosed);
            this.Load += new System.EventHandler(this.FormMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(FormMonitor.pbMonitor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public static System.Windows.Forms.PictureBox pbMonitor;
        private System.Windows.Forms.Button btnUpdate;
    }
}